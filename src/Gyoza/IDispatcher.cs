using System.Threading.Tasks;

namespace Gyoza
{
    /// <summary>
    /// Define a message dispatcher
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Dispatch a message
        /// </summary>
        /// <param name="message">Message to dispatch</param>
        /// <returns>Dispatch result</returns>
        Task<IResult> DispatchAsync<TMessage>(TMessage message)
            where TMessage : IMessage;
    }
}