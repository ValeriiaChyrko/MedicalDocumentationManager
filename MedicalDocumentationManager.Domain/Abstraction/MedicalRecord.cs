using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Abstraction;

public class MedicalRecord : IObservable
{
    public Guid Id { get; }
    public Guid PatientId { get; private set; }
    public Guid DoctorId { get; private set; }
    public string Record { get; private set; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; private set; }

    public event EventHandler<MessageEventArgs>? OnUpdateEvent;

    public MedicalRecord(Guid id, Guid patientId, Guid doctorId, string record, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        PatientId = patientId;
        DoctorId = doctorId;
        Record = record;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static MedicalRecord Create(Guid id, Guid patientId, Guid doctorId, string record,
        DateTime createdAt, DateTime updatedAt)
    {
        var newRecord = new MedicalRecord(id, patientId, doctorId, record, createdAt, updatedAt);

        return newRecord;
    }

    public void Update(Guid patientId, Guid doctorId, string record)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        Record = record;
        UpdatedAt = DateTime.Now;

        OnUpdateEvent?.Invoke(this, new MessageEventArgs(Record));
    }

    public bool IsObserverRegistered(Delegate prospectiveObserver)
    {
        return OnUpdateEvent != null
               && OnUpdateEvent.GetInvocationList()
                   .Any(existingHandler => existingHandler.Method == prospectiveObserver.Method);
    }
}