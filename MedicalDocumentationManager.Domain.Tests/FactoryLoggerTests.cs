using System.Reflection;
using MedicalDocumentationManager.Domain.Implementation;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Domain.Tests;

[TestFixture]
public class FactoryLoggerTests
{
    [Test]
    public void CreateConsoleLogger_ReturnsNotNull()
    {
        // Arrange
        var factory = new ConsoleLoggerFactory();

        // Act
        var logger = factory.CreateLogger();

        // Assert
        logger.Should().NotBeNull();
    }

    [Test]
    public void CreateConsoleLogger_ReturnsInstanceOfConsoleLogger()
    {
        // Arrange
        var factory = new ConsoleLoggerFactory();

        // Act
        var logger = factory.CreateLogger();

        // Assert
        logger.Should().NotBeNull();
        logger.Should().BeOfType<ConsoleLogger>();
    }

    [Test]
    public void CreateFileLogger_ReturnsNotNull()
    {
        // Arrange
        var filePath = string.Empty;
        var fileLoggerFactory = new FileLoggerFactory(filePath);

        // Act
        var logger = fileLoggerFactory.CreateLogger();

        // Assert
        logger.Should().NotBeNull();
    }

    [Test]
    public void CreateFileLogger_ReturnsInstanceOfFileLogger()
    {
        // Arrange
        var filePath = string.Empty;
        var fileLoggerFactory = new FileLoggerFactory(filePath);

        // Act
        var logger = fileLoggerFactory.CreateLogger();

        // Assert
        logger.Should().NotBeNull();
        logger.Should().BeOfType<FileLogger>();
    }

    [Test]
    public void FileLoggerFactory_Constructor_SetsFilePathToDefaultValueIfFilePathIsNullOrEmpty()
    {
        // Arrange
        var filePath = string.Empty;
        var fileLoggerFactory = new FileLoggerFactory(filePath);

        // Act
        var factory = fileLoggerFactory;

        // Assert
        var filePathField = factory.GetType().GetField("_filePath", BindingFlags.Instance | BindingFlags.NonPublic);
        var filePathValue = filePathField?.GetValue(factory);
        filePathValue.Should().NotBeNull();
        File.Exists((string)filePathValue).Should().BeTrue();
    }

    [Test]
    public void FileLoggerFactory_Constructor_SetsFilePathToProvidedValueIfFilePathIsNotNull()
    {
        // Arrange
        const string filePath = "log_test.txt";
        var fileLoggerFactory = new FileLoggerFactory(filePath);

        // Act
        var factory = fileLoggerFactory;

        // Assert
        var filePathField = factory.GetType().GetField("_filePath", BindingFlags.Instance | BindingFlags.NonPublic);
        var filePathValue = filePathField?.GetValue(factory);
        filePathValue.Should().NotBeNull();
        filePathValue.Should().Be(filePath);
        File.Exists((string)filePathValue).Should().BeTrue();
    }

    [Test]
    public void FileLoggerFactory_Constructor_CreatesFileIfFilePathDoesNotExist()
    {
        // Arrange
        var filePath = Path.Combine(Path.GetTempPath(), "log_test.txt");
        var fileLoggerFactory = new FileLoggerFactory(filePath);

        // Act
        var factory = fileLoggerFactory;

        // Assert
        var filePathField = factory.GetType().GetField("_filePath", BindingFlags.Instance | BindingFlags.NonPublic);
        var filePathValue = filePathField?.GetValue(factory);
        filePathValue.Should().NotBeNull();
        filePathValue.Should().Be(filePath);
        File.Exists((string)filePathValue).Should().BeTrue();
    }

    [Test]
    public void FileLoggerFactory_Constructor_CreatesFileIfFilePathIsProvided()
    {
        // Arrange
        var filePath = Path.Combine(Path.GetTempPath(), "log_test.txt");

        // Act
        var unused = new FileLoggerFactory(filePath);

        // Assert
        File.Exists(filePath).Should().BeTrue();

        // Clean up
        File.Delete(filePath);
    }

    [Test]
    public void GetFactory_ReturnsConsoleLoggerFactory_WhenLoggerTypeIsConsoleLogger()
    {
        // Arrange
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("Logger:Type", "ConsoleLogger")
            }!)
            .Build();

        var provider = new LoggerFactoryProvider(config);

        // Act
        var factory = provider.GetFactory();

        // Assert
        factory.Should().BeOfType<ConsoleLoggerFactory>();
    }

    [Test]
    public void GetFactory_ReturnsFileLoggerFactory_WhenLoggerTypeIsFileLogger()
    {
        // Arrange
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("Logger:Type", "FileLogger"),
                new KeyValuePair<string, string>("Logger:FilePath", "log.txt")
            }!)
            .Build();

        var provider = new LoggerFactoryProvider(config);

        // Act
        var factory = provider.GetFactory();

        // Assert
        factory.Should().BeOfType<FileLoggerFactory>();
    }

    [Test]
    public void GetFactory_ThrowsArgumentException_WhenLoggerTypeIsInvalid()
    {
        // Arrange
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("Logger:Type", "InvalidLoggerType")
            }!)
            .Build();

        var provider = new LoggerFactoryProvider(config);

        // Act and Assert
        Assert.Throws<ArgumentException>(() => provider.GetFactory());
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenConfigIsNull()
    {
        // Act
        // ReSharper disable once ObjectCreationAsStatement
        void TestDelegate()
        {
            new LoggerFactoryProvider(null!);
        }

        // Assert
        Assert.Throws<ArgumentNullException>(TestDelegate);
    }
}