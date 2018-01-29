using Gyoza.Tests.Context;
using Gyoza.Tests.ExternalLib1;
using Gyoza.Tests.ExternalLib2;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Gyoza.Tests
{
    public class ServiceCollectionExtensionsTests
    {
        [Fact]
        public void ShouldAddDispatcher_WhenCallAddHandlersExtensionMethod()
        {
            //Arrange
            var expected = new ServiceDescriptor(typeof(IDispatcher), typeof(Dispatcher), ServiceLifetime.Scoped);
            var mockedServiceCollection = new Mock<IServiceCollection>();

            //Act
            mockedServiceCollection.Object.AddGyoza();

            //Assert
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == expected.ServiceType && actual.ImplementationType == expected.ImplementationType && actual.Lifetime == expected.Lifetime)), Times.Once);
        }

        [Fact]
        public void ShouldAddHandlersFromCallingAssemblies_WhenCallAddHandlersExtensionMethod()
        {
            //Arrange
            var expected = new ServiceDescriptor(typeof(Gyoza.IHandler<Message>), typeof(ValidHandler), ServiceLifetime.Scoped);
            var unexpected = new ServiceDescriptor(typeof(Context.IHandler<Message>), typeof(InvalidHandler), ServiceLifetime.Scoped);

            var mockedServiceCollection = new Mock<IServiceCollection>();

            //Act
            mockedServiceCollection.Object.AddGyoza();

            //Assert
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == expected.ServiceType && actual.ImplementationType == expected.ImplementationType && actual.Lifetime == expected.Lifetime)), Times.Once);
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == unexpected.ServiceType && actual.ImplementationType == unexpected.ImplementationType && actual.Lifetime == expected.Lifetime)), Times.Never);
        }

        [Fact]
        public void ShouldAddValidatorsFromCallingAssemblies_WhenCallAddHandlersExtensionMethod()
        {
            //Arrange
            var expected = new ServiceDescriptor(typeof(Gyoza.IValidator<Message>), typeof(ValidValidator), ServiceLifetime.Scoped);
            var unexpected = new ServiceDescriptor(typeof(Context.IValidator<Message>), typeof(InvalidValidator), ServiceLifetime.Scoped);

            var mockedServiceCollection = new Mock<IServiceCollection>();

            //Act
            mockedServiceCollection.Object.AddGyoza();

            //Assert
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == expected.ServiceType && actual.ImplementationType == expected.ImplementationType && actual.Lifetime == expected.Lifetime)), Times.Once);
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == unexpected.ServiceType && actual.ImplementationType == unexpected.ImplementationType && actual.Lifetime == expected.Lifetime)), Times.Never);
        }

        [Fact]
        public void ShouldAddHandlersFromReferencesAssemblies_WhenCallAddHandlersExtensionMethod()
        {
            //Arrange
            var expected1 = new ServiceDescriptor(typeof(IHandler<ExternalMessage1>), typeof(ExternalHandler1), ServiceLifetime.Scoped);
            var expected2 = new ServiceDescriptor(typeof(IHandler<ExternalMessage2>), typeof(ExternalHandler2), ServiceLifetime.Scoped);

            var mockedServiceCollection = new Mock<IServiceCollection>();

            //Act
            mockedServiceCollection.Object.AddGyoza();

            //Assert
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == expected1.ServiceType && actual.ImplementationType == expected1.ImplementationType && actual.Lifetime == expected1.Lifetime)), Times.Once);
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == expected2.ServiceType && actual.ImplementationType == expected2.ImplementationType && actual.Lifetime == expected2.Lifetime)), Times.Once);
        }

        [Fact]
        public void ShouldAddValidatorsFromReferencesAssemblies_WhenCallAddHandlersExtensionMethod()
        {
            //Arrange
            var expected1 = new ServiceDescriptor(typeof(IValidator<ExternalMessage1>), typeof(ExternalValidator1), ServiceLifetime.Scoped);
            var expected2 = new ServiceDescriptor(typeof(IValidator<ExternalMessage2>), typeof(ExternalValidator2), ServiceLifetime.Scoped);

            var mockedServiceCollection = new Mock<IServiceCollection>();

            //Act
            mockedServiceCollection.Object.AddGyoza();

            //Assert
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == expected1.ServiceType && actual.ImplementationType == expected1.ImplementationType && actual.Lifetime == expected1.Lifetime)), Times.Once);
            mockedServiceCollection.Verify(m => m.Add(It.Is<ServiceDescriptor>(actual => actual.ServiceType == expected2.ServiceType && actual.ImplementationType == expected2.ImplementationType && actual.Lifetime == expected2.Lifetime)), Times.Once);
        }
    }
}