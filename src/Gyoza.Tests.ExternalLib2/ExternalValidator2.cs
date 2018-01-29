using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gyoza.Tests.ExternalLib2
{
    public class ExternalValidator2 : IValidator<ExternalMessage2>
    {
        public Task<IEnumerable<(string property, string error)>> ValidateAsync(ExternalMessage2 message)
        {
            throw new System.NotImplementedException();
        }
    }
}
