using System.Threading.Tasks;

namespace Gyoza
{
    /// <summary>
    /// Define a handler
    /// </summary>
    public interface IHandler<in TMessage> where TMessage: IMessage
    {
        /// <summary>
        /// Handle a message
        /// </summary>
        /// <param name="message">Message to handle</param>
        /// <returns>Result</returns>
        Task<IResult> HandleAsync(TMessage message);
    }
}