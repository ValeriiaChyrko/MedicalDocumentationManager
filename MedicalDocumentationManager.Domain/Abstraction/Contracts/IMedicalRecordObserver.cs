namespace MedicalDocumentationManager.Domain.Abstraction.Contracts;

public interface IMedicalRecordObserver : INotifiable
{
    void Subscribe();
    void Unsubscribe();
}