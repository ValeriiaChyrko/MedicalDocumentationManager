using MediatR;
using MedicalDocumentationManager.Persistence.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.Persistence.Tests;

[TestFixture]
public class DependencyInjectionTests
{
    [Test]
    public void AddPersistenceServices_RegistersMediatR()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddPersistenceServices();

        // Assert
        var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(IMediator));
        descriptor.Should().NotBeNull();
        descriptor.ImplementationType.Should().Be(typeof(Mediator));
    }

    [Test]
    public void AddPersistenceServices_RegistersValidationBehavior()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddPersistenceServices();

        // Assert
        var descriptor = services.FirstOrDefault(d =>
            d.ServiceType.IsGenericType &&
            d.ServiceType.GetGenericTypeDefinition() == typeof(IPipelineBehavior<,>) &&
            d.ImplementationType == typeof(ValidationBehavior<,>));

        descriptor.Should().NotBeNull();
    }

    [Test]
    public void AddPersistenceServices_RegistersDatabaseErrorBehavior()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddPersistenceServices();

        // Assert
        var descriptor = services.FirstOrDefault(d =>
            d.ServiceType.IsGenericType &&
            d.ServiceType.GetGenericTypeDefinition() == typeof(IPipelineBehavior<,>) &&
            d.ImplementationType == typeof(DatabaseErrorBehavior<,>));

        descriptor.Should().NotBeNull();
    }
}