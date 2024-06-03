using MedicalDocumentationManager.Domain.Abstraction;

namespace MedicalDocumentationManager.Domain.Implementation;

public class ConsoleLoggerFactory : ILoggerFactory
{
    public ILogger CreateLogger()
    {
        return new ConsoleLogger();
    }
}
