using System;
using FluentAssertions;
using Xunit;

namespace Gyoza.Tests
{
    public class ValueResultTest
    {
        [Theory]
        [InlineData(State.DomainError)]
        [InlineData(State.Empty)]
        [InlineData(State.None)]
        [InlineData(State.Success)]
        [InlineData(State.TechnicalError)]
        public void ShouldHaveAStateAndAValue_WhenInitializeWithAStateAndAValue(State expectedState)
        {
            //Arrange
            var expectedValue = Guid.NewGuid().ToString();

            //Act
            var result = new ValueResult(expectedState, expectedValue);
            var actualState = result.State;
            var actualValue = result.Value;

            //Assert
            actualState.Should().BeEquivalentTo(expectedState);
            actualValue.Should().BeEquivalentTo(expectedValue);
        }
    }
}