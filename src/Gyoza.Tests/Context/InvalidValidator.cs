namespace Gyoza.Tests.Context
{
    public interface IValidator<in TMessage> where TMessage : IMessage
    {

    }

    public class InvalidValidator : IValidator<Message>
    {
    }
}