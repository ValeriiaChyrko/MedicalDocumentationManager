namespace MedicalDocumentationManager.Domain.Abstraction.Contracts;

public interface IMedicalRecordObserver : INotifiable
{
    void Subscribe();
    void Unsubscribe();

    bool IsRegistered(Delegate prospectiveHandler);
}