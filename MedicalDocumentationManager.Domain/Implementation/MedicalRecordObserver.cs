using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Implementation;

public class MedicalRecordObserver : IMedicalRecordObserver
{
    private readonly MedicalRecord _record;
    public event EventHandler<MessageEventArgs>? OnNotifyEvent;

    public MedicalRecordObserver(MedicalRecord record)
    {
        _record = record ?? throw new ArgumentNullException(nameof(record));
    }

    public void Unsubscribe()
    {
        if (!_record.IsRegistered(OnMedicalRecordUpdated))
            throw new InvalidOperationException(
                $"The observer is not subscribed to the {nameof(OnMedicalRecordUpdated)} event.");

        _record.Updated -= OnMedicalRecordUpdated;
    }

    public void Subscribe()
    {
        if (_record.IsRegistered(OnMedicalRecordUpdated))
            throw new InvalidOperationException(
                $"The observer is already subscribed to the {nameof(OnMedicalRecordUpdated)} event.");

        _record.Updated += OnMedicalRecordUpdated;
    }

    private void OnMedicalRecordUpdated(object? sender, MessageEventArgs e)
    {
        e.Message = $"Medical history was updated: {e.Message}";
        OnNotifyEvent?.Invoke(this, e);
    }

    public bool IsRegistered(Delegate prospectiveHandler)
    {
        return OnNotifyEvent != null
               && OnNotifyEvent.GetInvocationList()
                   .Any(existingHandler => existingHandler.Method == prospectiveHandler.Method);
    }
}