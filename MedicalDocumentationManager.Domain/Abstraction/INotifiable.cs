namespace MedicalDocumentationManager.Domain.Abstraction;

public interface INotifiable
{
    void Notify(string message);
}