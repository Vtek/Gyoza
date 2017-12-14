using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Gyoza.Tests.Context;
using Moq;
using Xunit;

namespace Gyoza.Tests
{
    public class DispatcherTests
    {
        static Random Rand = new Random();

        [Fact]
        public async Task ShouldReturnAnResult_WhenDispatchAMessage()
        {
            var expected = new Result();

            var mockedHandler = new Mock<IHandler<Message>>();
            mockedHandler.Setup(m => m.HandleAsync(It.IsAny<Message>())).Returns(() => Task.FromResult(expected as IResult));

            var mockedServiceProvider = new Mock<IServiceProvider>();
            mockedServiceProvider.Setup(m => m.GetService(It.IsAny<Type>())).Returns(() => mockedHandler.Object);

            IDispatcher dispatcher = new Dispatcher(mockedServiceProvider.Object);
            var actual = await dispatcher.DispatchAsync(new Message());

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task ShouldReturnAResultWithATechnicalErrorState_WhenNoHandlerFound()
        {
            var expected = new ValueResult(State.TechnicalError, "No handler found");

            var mockedServiceProvider = new Mock<IServiceProvider>();
            mockedServiceProvider.Setup(m => m.GetService(It.IsAny<Type>())).Returns(() => null);

            IDispatcher dispatcher = new Dispatcher(mockedServiceProvider.Object);
            var actual = await dispatcher.DispatchAsync(new Message()) as ValueResult;

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task ShouldValidateMessage_WhenValidatorIsFound()
        {
            var mockedValidator = new Mock<IValidator<Message>>();

            var mockedServiceProvider = new Mock<IServiceProvider>();
            mockedServiceProvider.Setup(m => m.GetService(It.IsAny<Type>())).Returns(() => mockedValidator.Object);

            IDispatcher dispatcher = new Dispatcher(mockedServiceProvider.Object);
            await dispatcher.DispatchAsync(new Message());

            mockedValidator.Verify(m => m.ValidateAsync(It.IsAny<Message>()), Times.Once);
        }

        [Fact]
        public async Task ShouldReturnDomainErrors_WhenMessageIsNotValid()
        {
            var messages = new List<(string property, string error)>();
            for (int i = 0, l = (Rand.Next(byte.MaxValue) + 1); i < l; i++)
            {
                messages.Add((nameof(Message), Guid.NewGuid().ToString()));
            }

            var expected = new ValueResult(State.DomainError, messages);

            var mockedValidator = new Mock<IValidator<Message>>();
            mockedValidator.Setup(m => m.ValidateAsync(It.IsAny<Message>())).Returns(() => Task.FromResult(messages.AsEnumerable()));

            var mockedServiceProvider = new Mock<IServiceProvider>();
            mockedServiceProvider.Setup(m => m.GetService(It.IsAny<Type>())).Returns(() => mockedValidator.Object);

            IDispatcher dispatcher = new Dispatcher(mockedServiceProvider.Object);
            var actual = await dispatcher.DispatchAsync(new Message()) as ValueResult;

            actual.Should().BeEquivalentTo(expected);
        }
    }
}