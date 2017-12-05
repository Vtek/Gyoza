using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gyoza
{
    /// <summary>
    /// Define a message validator
    /// </summary>
    public interface IValidator<in TMessage>
        where TMessage : IMessage
    {
        /// <summary>
        /// Validate a message
        /// </summary>
        /// <param name="message">Message to validate</param>
        /// <returns>Validation error messages</returns>
        Task<IEnumerable<(string property, string error)>> ValidateAsync(TMessage message);
    }
}