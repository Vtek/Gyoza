namespace Gyoza.Tests.Context
{
    public interface IHandler<in TMessage> where TMessage : IMessage
    {

    }

    public class InvalidHandler : IHandler<Message>
    {
    }
}