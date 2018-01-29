using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gyoza.Tests.Context
{
    public class ValidValidator : Gyoza.IValidator<Message>
    {
        public Task<IEnumerable<(string property, string error)>> ValidateAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}