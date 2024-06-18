using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.Domain.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.Domain.Tests;

[TestFixture]
public class DependencyInjectionTests
{
    [Test]
    public void AddDomainServices_RegistersServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddDomainServices();

        // Assert
        services.Should().Contain(sd => sd.ServiceType == typeof(IMessageHandler));
        services.Should().Contain(sd => sd.ServiceType == typeof(IMedicalRecordNotifier));
        services.Should().Contain(sd => sd.ServiceType == typeof(IMedicalRecordObserver));
        services.Should().Contain(sd => sd.ServiceType == typeof(ILoggerFactoryProvider));
        services.Should().Contain(sd => sd.ServiceType == typeof(ILoggerFactory));
        services.Should().Contain(sd => sd.ServiceType == typeof(ILogger));
    }
    
    [Test]
    public void AddDomainServices_RegistersExpectedServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddDomainServices();

        // Assert
        services.Should().Contain(descriptor =>
            descriptor.ServiceType == typeof(IMessageHandler) &&
            descriptor.ImplementationType == typeof(ConsoleMessageHandler) &&
            descriptor.Lifetime == ServiceLifetime.Scoped);
    }
    
    [Test]
    public void GetConsoleLoggerFactory_ReturnsCorrectLoggerFactory()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["Logger:Type"].Returns("ConsoleLogger");

        var provider = new LoggerFactoryProvider(configMock);

        // Act
        var factory = provider.GetFactory();

        // Assert
        factory.Should().BeOfType<ConsoleLoggerFactory>();
    }
    
    [Test]
    public void GetFileLoggerFactory_ReturnsCorrectLoggerFactory()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["Logger:Type"].Returns("FileLogger");

        var provider = new LoggerFactoryProvider(configMock);

        // Act
        var factory = provider.GetFactory();

        // Assert
        factory.Should().BeOfType<FileLoggerFactory>();
    }
    
    [Test]
    public void CreateConsoleLogger_ReturnsCorrectLogger()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["Logger:Type"].Returns("ConsoleLogger");

        var services = new ServiceCollection();
        services.AddSingleton(configMock);
        services.AddDomainServices();

        var serviceProvider = services.BuildServiceProvider();

        // Act
        var logger = serviceProvider.GetRequiredService<ILogger>();

        // Assert
        logger.Should().NotBeNull();
    }
    
    [Test]
    public void CreateFileLogger_ReturnsCorrectLogger()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["Logger:Type"].Returns("FileLogger");

        var services = new ServiceCollection();
        services.AddSingleton(configMock);
        services.AddDomainServices();

        var serviceProvider = services.BuildServiceProvider();

        // Act
        var logger = serviceProvider.GetRequiredService<ILogger>();

        // Assert
        logger.Should().NotBeNull();
    }
}