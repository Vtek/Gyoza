using System.Threading.Tasks;

namespace Gyoza.Tests.ExternalLib2
{
    public class ExternalHandler2 : IHandler<ExternalMessage2>
    {
        public Task<IResult> HandleAsync(ExternalMessage2 message)
        {
            throw new System.NotImplementedException();
        }
    }
}
