using System;
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
            var handler = ServiceProvider.GetService(typeof(IHandler<TMessage>)) as IHandler<TMessage>;

            if (handler == null)
                return new ValueResult(State.TechnicalError, "No handler found");

            return await handler.HandleAsync(message);
        }
    }
}