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

        Task<IResult> IDispatcher.DispatchAsync<TMessage>(TMessage message)
        {
            throw new System.NotImplementedException();
        }
    }
}