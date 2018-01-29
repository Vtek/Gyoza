using System.Linq;
using System.Reflection;
using Gyoza;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGyoza(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDispatcher, Dispatcher>();

            var assemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
            var callingAssembly = Assembly.GetCallingAssembly();
            assemblies.Add(callingAssembly);

            var types = assemblies.SelectMany(x => x.GetTypes()).ToList();

            foreach (var t in types)
            {
                if (t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHandler<>)))
                    serviceCollection.AddScoped(t.GetInterface(typeof(IHandler<>).Name), t);

                if (t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)))
                    serviceCollection.AddScoped(t.GetInterface(typeof(IValidator<>).Name), t);
            }

            return serviceCollection;
        }
    }
}