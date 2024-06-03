using MedicalDocumentationManager.Domain.Implementation;

namespace MedicalDocumentationManager.Tests;

[TestFixture]
public class ConsoleMessageHandlerTests
{
    [Test]
    public void HandleMessage_WritesMessageToConsole_WhenMessageIsValid()
    {
        // Arrange
        var messageHandler = new ConsoleMessageHandler();
        const string expectedMessage = "Test message";
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        messageHandler.HandleMessage(expectedMessage);
        var actualOutput = consoleOutput.ToString().Trim();

        // Assert
        actualOutput.Should().Contain($"Message received: {expectedMessage}");
    }

    [Test]
    public void HandleMessage_ThrowsArgumentNullException_WhenMessageIsEmpty()
    {
        // Arrange
        var messageHandler = new ConsoleMessageHandler();
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => messageHandler.HandleMessage(""));
    }

    [Test]
    public void HandleMessage_ThrowsArgumentNullException_WhenMessageIsNull()
    {
        // Arrange
        var messageHandler = new ConsoleMessageHandler();
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => messageHandler.HandleMessage(null!));
    }
}