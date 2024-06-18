namespace MedicalDocumentationManager.Domain.Abstraction.Contracts;

public interface ILoggerFactoryProvider
{
    ILoggerFactory GetFactory();
}