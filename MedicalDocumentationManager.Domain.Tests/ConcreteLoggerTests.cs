using MedicalDocumentationManager.Domain.Implementation;

namespace MedicalDocumentationManager.Tests;

[TestFixture]
public class ConcreteLoggerTests
{
    [Test]
    public void ConsoleLogger_Log_MessageIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var logger = new ConsoleLogger();

        // Act and Assert
        logger.Invoking(l => l.Log(null!)).Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void ConsoleLog_MessageIsValid_WritesMessageToConsole()
    {
        // Arrange
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        var consoleLogger = new ConsoleLogger();
        const string message = "Initial message";

        // Act
        consoleLogger.Log(message);

        // Assert
        consoleOutput.ToString().Should().Be(message + Environment.NewLine);
    }

    [Test]
    public void FileLogger_Log_MessageIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var logger = new FileLogger(string.Empty);

        // Act and Assert
        logger.Invoking(l => l.Log(null!)).Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void FileLog_MessageIsValid_WritesMessageToFile()
    {
        // Arrange
        const string message = "Initial message";
        const string filePath = "test.log";
        var logger = new FileLogger(filePath);

        // Act
        logger.Log(message);

        // Assert
        File.ReadAllText(filePath).Should().Be(message + Environment.NewLine);
        File.Delete(filePath);
    }

    [Test]
    public void FileLog_MessageIsValid_WritesMessageWithCorrectLineEnding()
    {
        // Arrange
        const string filePath = "test.log";
        var logger = new FileLogger(filePath);
        const string initialMessage = "Initial message";
        const string additionalMessage = "Additional message";

        // Act
        logger.Log(initialMessage);
        logger.Log(additionalMessage);

        // Assert
        File.ReadAllText(filePath).Should().Be(initialMessage + Environment.NewLine + additionalMessage + Environment.NewLine);
        File.Delete(filePath);
    }

    [Test]
    public void FileLog_FileExists_AppendsMessageToEndOfFile()
    {
        // Arrange
        const string filePath = "test.log";
        var logger = new FileLogger(filePath);
        const string initialMessage = "Initial message";
        const string additionalMessage = "Additional message";

        // Act
        File.WriteAllText(filePath, initialMessage + Environment.NewLine);
        logger.Log(additionalMessage);

        // Assert
        File.ReadAllText(filePath).Should().Be(initialMessage + Environment.NewLine + additionalMessage + Environment.NewLine);
        File.Delete(filePath);
    }

    [Test]
    public void FileLog_MessageIsValid_ClosesFileAfterWriting()
    {
        // Arrange
        const string filePath = "test.log";
        var logger = new FileLogger(filePath);
        const string message = "Initial message";

        // Act
        logger.Log(message);

        // Assert
        File.Exists(filePath).Should().BeTrue();
        File.Delete(filePath);
    }
}