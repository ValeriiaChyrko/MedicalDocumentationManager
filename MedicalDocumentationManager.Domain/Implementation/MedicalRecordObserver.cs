using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Implementation;

public class MedicalRecordObserver : IMedicalRecordObserver
{
    private readonly IObservable _medicalRecord;
    public event EventHandler<MessageEventArgs>? OnNotifyEvent;

    public MedicalRecordObserver(IObservable medicalRecord)
    {
        _medicalRecord = medicalRecord ?? throw new ArgumentNullException(nameof(medicalRecord));
    }

    public void Unsubscribe()
    {
        if (!_medicalRecord.IsObserverRegistered(OnMedicalMedicalRecordOnUpdateEvent))
            throw new InvalidOperationException(
                $"The observer is not subscribed to the {nameof(OnMedicalMedicalRecordOnUpdateEvent)} event.");

        _medicalRecord.OnUpdateEvent -= OnMedicalMedicalRecordOnUpdateEvent;
    }

    public void Subscribe()
    {
        if (_medicalRecord.IsObserverRegistered(OnMedicalMedicalRecordOnUpdateEvent))
            throw new InvalidOperationException(
                $"The observer is already subscribed to the {nameof(OnMedicalMedicalRecordOnUpdateEvent)} event.");

        _medicalRecord.OnUpdateEvent += OnMedicalMedicalRecordOnUpdateEvent;
    }

    private void OnMedicalMedicalRecordOnUpdateEvent(object? sender, MessageEventArgs e)
    {
        e.Message = $"Medical history was updated: {e.Message}";
        OnNotifyEvent?.Invoke(this, e);
    }

    public bool IsObserverRegistered(Delegate prospectiveObserver)
    {
        return OnNotifyEvent != null
               && OnNotifyEvent.GetInvocationList()
                   .Any(existingHandler => existingHandler.Method == prospectiveObserver.Method);
    }
}