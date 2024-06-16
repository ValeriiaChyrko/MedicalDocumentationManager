using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Implementation;

public class ConsoleMessageHandler : IMessageHandler
{
    public void HandleMessage(string message)
    {
        if (string.IsNullOrEmpty(message)) throw new ArgumentNullException(nameof(message));

        Console.WriteLine($"Message received: {message}");
    }
}