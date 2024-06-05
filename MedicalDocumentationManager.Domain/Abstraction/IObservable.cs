namespace MedicalDocumentationManager.Domain.Abstraction;

public interface IObservable
{
    event EventHandler<MessageEventArgs>? Updated;
}