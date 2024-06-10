namespace MedicalDocumentationManager.Domain.Abstraction.Contracts;

public interface IMedicalRecordNotifier
{
    void Subscribe();
    void Unsubscribe();
}