namespace MedicalDocumentationManager.Domain.Abstraction.Contracts;

public interface IMessageHandler
{
    void HandleMessage(string message);
}