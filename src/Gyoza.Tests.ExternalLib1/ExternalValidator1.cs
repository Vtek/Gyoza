using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gyoza.Tests.ExternalLib1
{
    public class ExternalValidator1 : IValidator<ExternalMessage1>
    {
        public Task<IEnumerable<(string property, string error)>> ValidateAsync(ExternalMessage1 message)
        {
            throw new System.NotImplementedException();
        }
    }
}
