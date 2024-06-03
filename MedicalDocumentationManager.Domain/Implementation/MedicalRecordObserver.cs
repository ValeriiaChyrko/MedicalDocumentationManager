using MedicalDocumentationManager.Domain.Abstraction;

namespace MedicalDocumentationManager.Domain.Implementation;

public class MedicalRecordObserver : IMedicalRecordObserver
{
    private readonly MedicalRecord _record;
    private readonly IMessageHandler _messageHandler;

    public MedicalRecordObserver(MedicalRecord record, IMessageHandler messageHandler)
    {
        _record = record ?? throw new ArgumentNullException(nameof(record));
        _messageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler));
    }
    
    public void Unsubscribe()
    {
        _record.Updated -= OnMedicalRecordUpdated;
    }

    public void Subscribe()
    {
        _record.Updated += OnMedicalRecordUpdated;
    }
    
    private void OnMedicalRecordUpdated(object? sender, MessageEventArgs e)
    {
        var message = e.Message;
        _messageHandler.HandleMessage(message);
    }
    
    public void Notify(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException(nameof(message));
        }
        _messageHandler.HandleMessage(message);
    }
}