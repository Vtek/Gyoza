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
            var result = new Result();
            var actual = result.State;

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
