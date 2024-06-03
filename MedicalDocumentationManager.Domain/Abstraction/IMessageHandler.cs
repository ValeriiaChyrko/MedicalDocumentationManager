namespace MedicalDocumentationManager.Domain.Abstraction;

public interface IMessageHandler
{
    void HandleMessage(string message);
}