using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gyoza
{
    public class Dispatcher : IDispatcher
    {
        private IServiceProvider ServiceProvider { get; }

        public Dispatcher(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        async Task<IResult> IDispatcher.DispatchAsync<TMessage>(TMessage message)
        {
            var validator = ServiceProvider.GetService(typeof(IValidator<TMessage>)) as IValidator<TMessage>;

            if (validator != null)
            {
                var errors = await validator.ValidateAsync(message);

                if (errors.Count() > 0)
                    return new ValueResult(State.DomainError, errors);
            }

            var handler = ServiceProvider.GetService(typeof(IHandler<TMessage>)) as IHandler<TMessage>;

            if (handler == null)
                return new ValueResult(State.TechnicalError, "No handler found");

            return await handler.HandleAsync(message);
        }
    }
}