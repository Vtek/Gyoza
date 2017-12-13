using System;
using System.Threading.Tasks;
using FluentAssertions;
using Gyoza.Tests.Context;
using Moq;
using Xunit;

namespace Gyoza.Tests
{
    public class DispatcherTests
    {
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
    }
}