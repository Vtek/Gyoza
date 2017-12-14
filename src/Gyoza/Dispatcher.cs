using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gyoza
{
    /// <summary>
    /// Message dispatcher
    /// </summary>
    public class Dispatcher : IDispatcher
    {
        /// <summary>
        /// Service provider
        /// </summary>
        private IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Create a new instance of Dispatcher class
        /// </summary>
        /// <param name="serviceProvider">Service provider, need to be injected</param>
        public Dispatcher(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        /// <summary>
        /// Dispatch a message asynchronously
        /// </summary>
        /// <param name="message">Message to dispatch</param>
        /// <returns>Dispatch result</returns>
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