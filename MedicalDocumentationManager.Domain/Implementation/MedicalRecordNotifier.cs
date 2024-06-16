using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Implementation;

public class MedicalRecordNotifier : IMedicalRecordNotifier
{
    private readonly IMedicalRecordObserver _recordObserver;
    private readonly IMessageHandler _messageHandler;

    public MedicalRecordNotifier(IMedicalRecordObserver recordObserver, IMessageHandler messageHandler)
    {
        _recordObserver = recordObserver ?? throw new ArgumentNullException(nameof(recordObserver));
        _messageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler));
    }

    public void Unsubscribe()
    {
        if (!_recordObserver.IsObserverRegistered(Notify))
            throw new InvalidOperationException($"The observer is not subscribed to the {nameof(Notify)} event.");

        _recordObserver.OnNotifyEvent -= Notify;
    }

    public void Subscribe()
    {
        if (_recordObserver.IsObserverRegistered(Notify))
            throw new InvalidOperationException($"The observer is already subscribed to the {nameof(Notify)} event.");

        _recordObserver.OnNotifyEvent += Notify;
    }

    private void Notify(object? sender, MessageEventArgs messageEventArgs)
    {
        if (messageEventArgs == null) throw new ArgumentNullException(nameof(messageEventArgs));

        _messageHandler.HandleMessage(messageEventArgs.Message);
    }
}