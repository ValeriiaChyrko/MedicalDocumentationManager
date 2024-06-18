using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace MedicalDocumentationManager.Database.Tests;

[TestFixture]
public class DependencyInjectionTests
{
    [Test]
    public void AddDatabaseServices_RegistersExpectedServices()
    {
        // Arrange
        var services = new ServiceCollection();
        Substitute.For<IConfiguration>();

        // Act
        services.AddDatabaseServices();

        // Assert
        services.Should().ContainSingle(descriptor =>
            descriptor.ServiceType == typeof(IMedicalDocumentationManagerDbContextProvider) &&
            descriptor.Lifetime == ServiceLifetime.Singleton);

        services.Should().ContainSingle(descriptor =>
            descriptor.ServiceType == typeof(IMedicalDocumentationManagerDbContextFactory) &&
            descriptor.Lifetime == ServiceLifetime.Singleton);

        services.Should().ContainSingle(descriptor =>
            descriptor.ServiceType == typeof(IMedicalDocumentationManagerDbContext) &&
            descriptor.Lifetime == ServiceLifetime.Singleton);
    }
    
    [Test]
    public void GetFactory_ReturnsCorrectFactory_ForInMemoryDbContext()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["DbContext:Type"].Returns("InMemory");

        var services = new ServiceCollection();
        services.AddSingleton(configMock);
        services.AddDatabaseServices();

        var serviceProvider = services.BuildServiceProvider();

        // Act
        var factory = serviceProvider.GetRequiredService<IMedicalDocumentationManagerDbContextFactory>();

        // Assert
        factory.Should().NotBeNull();
        factory.Should().BeOfType<MedicalDocumentationManagerInMemoryDbContextFactory>();
    }

    [Test]
    public void GetFactory_ReturnsCorrectFactory_ForPostgresSqlDbContext()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["DbContext:Type"].Returns("PostgresSql");

        var services = new ServiceCollection();
        services.AddSingleton(configMock);
        services.AddDatabaseServices();

        var serviceProvider = services.BuildServiceProvider();

        // Act
        var factory = serviceProvider.GetRequiredService<IMedicalDocumentationManagerDbContextFactory>();

        // Assert
        factory.Should().NotBeNull();
        factory.Should().BeOfType<MedicalDocumentationManagerPostgresSqlDbContextFactory>();
    }

    [Test]
    public void GetFactory_ThrowsException_ForInvalidDbContextType()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["DbContext:Type"].Returns("InvalidType");
        
        var services = new ServiceCollection();
        services.AddSingleton(configMock);
        services.AddDatabaseServices();

        var serviceProvider = services.BuildServiceProvider();

        // Act & Assert
        Action act = () => serviceProvider.GetRequiredService<IMedicalDocumentationManagerDbContextFactory>();
        act.Should().Throw<ArgumentException>();
    }
    
    [Test]
    public void AddDatabaseServices_RegistersCorrectDbContextInstance()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["DbContext:Type"].Returns("InMemory"); 

        var services = new ServiceCollection();
        services.AddSingleton(configMock);
        services.AddDatabaseServices();

        var serviceProvider = services.BuildServiceProvider();

        // Act
        var dbContext = serviceProvider.GetRequiredService<IMedicalDocumentationManagerDbContext>();

        // Assert
        dbContext.Should().NotBeNull();
        dbContext.Should().BeOfType<MedicalDocumentationManagerDbContext>();
    }
}