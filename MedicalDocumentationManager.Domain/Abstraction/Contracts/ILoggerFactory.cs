namespace MedicalDocumentationManager.Domain.Abstraction.Contracts;

public interface ILoggerFactory
{
    ILogger CreateLogger();
}