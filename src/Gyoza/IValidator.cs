using System.Collections.Generic;

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
        IEnumerable<(string property, string error)> Validate(TMessage message);
    }
}