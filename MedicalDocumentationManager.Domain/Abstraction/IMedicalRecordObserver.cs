namespace MedicalDocumentationManager.Domain.Abstraction;

public interface IMedicalRecordObserver : INotifiable
{
    void Subscribe();
    void Unsubscribe();
}