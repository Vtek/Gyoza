using System.Threading.Tasks;

namespace Gyoza.Tests.Context
{
    public class ValidHandler : Gyoza.IHandler<Message>
    {
        public Task<IResult> HandleAsync(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}