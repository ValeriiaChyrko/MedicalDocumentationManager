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

    public event EventHandler<MessageEventArgs>? Updated;

    private MedicalRecord(Guid id, Guid patientId, Guid doctorId, string record, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        PatientId = patientId;
        DoctorId = doctorId;
        Record = record;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static MedicalRecord Create(Guid id, Guid patientId, Guid doctorId, string record)
    {
        var currentDateTime = DateTime.Now;
        var newRecord = new MedicalRecord(id, patientId, doctorId, record, currentDateTime, currentDateTime);

        return newRecord;
    }

    public void Update(Guid patientId, Guid doctorId, string record)
    {
        PatientId = patientId;
        DoctorId = doctorId;
        Record = record;
        UpdatedAt = DateTime.Now;

        Updated?.Invoke(this, new MessageEventArgs(Record));
    }

    public bool IsRegistered(Delegate prospectiveHandler)
    {
        return Updated != null
               && Updated.GetInvocationList()
                   .Any(existingHandler => existingHandler.Method == prospectiveHandler.Method);
    }
}