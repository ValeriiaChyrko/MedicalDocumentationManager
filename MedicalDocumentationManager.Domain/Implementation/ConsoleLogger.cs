using MedicalDocumentationManager.Domain.Abstraction;

namespace MedicalDocumentationManager.Domain.Implementation;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "The message cannot be null.");
        }
        
        Console.WriteLine(message);
    }
}