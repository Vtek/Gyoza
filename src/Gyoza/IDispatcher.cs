using System.Threading.Tasks;

namespace Gyoza
{
    public interface IDispatcher
    {
        Task<IResult> DispatchAsync<TMessage>(TMessage message)
            where TMessage : IMessage;
    }
}