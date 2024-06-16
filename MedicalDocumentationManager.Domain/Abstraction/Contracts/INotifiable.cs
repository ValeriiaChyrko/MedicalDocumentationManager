namespace MedicalDocumentationManager.Domain.Abstraction.Contracts;

public interface INotifiable
{
    event EventHandler<MessageEventArgs>? OnNotifyEvent;
    bool IsObserverRegistered(Delegate prospectiveObserver);
}