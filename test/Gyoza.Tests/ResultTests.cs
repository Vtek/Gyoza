using System;
using FluentAssertions;
using Xunit;

namespace Gyoza.Tests
{
    public class ResultTest
    {
        [Fact]
        public void ShouldHaveAnEmptyState_WhenInitializeWithoutParameters()
        {
            //Arrange
            var expected = State.Empty;

            //Act
            IResult result = new Result();
            var actual = result.State;

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(State.DomainError)]
        [InlineData(State.Empty)]
        [InlineData(State.None)]
        [InlineData(State.Success)]
        [InlineData(State.TechnicalError)]
        public void ShouldHaveAState_WhenInitializeWithAState(State expected)
        {
            //Act
            var result = new Result(expected);
            var actual = result.State;

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
