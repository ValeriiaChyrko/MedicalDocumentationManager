using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Implementation;

public class ConsoleLoggerFactory : ILoggerFactory
{
    public ILogger CreateLogger()
    {
        return new ConsoleLogger();
    }
}