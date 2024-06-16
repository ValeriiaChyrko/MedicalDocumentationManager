namespace MedicalDocumentationManager.Domain.Abstraction.Contracts;

public interface IObservable
{
    event EventHandler<MessageEventArgs>? OnUpdateEvent;
    bool IsObserverRegistered(Delegate prospectiveObserver);
}