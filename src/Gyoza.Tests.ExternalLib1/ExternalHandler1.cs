using System.Threading.Tasks;

namespace Gyoza.Tests.ExternalLib1
{

    public class ExternalHandler1 : IHandler<ExternalMessage1>
    {
        public Task<IResult> HandleAsync(ExternalMessage1 message)
        {
            throw new System.NotImplementedException();
        }
    }
}
