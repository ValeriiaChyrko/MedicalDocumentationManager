namespace MedicalDocumentationManager.Domain.Abstraction;

public interface INotifiable
{
    event EventHandler<MessageEventArgs>? OnNotifyEvent;
}