namespace MedicalDocumentationManager.Domain.Abstraction;

public interface ILoggerFactory
{
    ILogger CreateLogger();
}
