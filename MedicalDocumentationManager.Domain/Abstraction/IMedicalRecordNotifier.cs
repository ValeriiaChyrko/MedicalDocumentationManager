namespace MedicalDocumentationManager.Domain.Abstraction;

public interface IMedicalRecordNotifier
{
    void Subscribe();
    void Unsubscribe();
}