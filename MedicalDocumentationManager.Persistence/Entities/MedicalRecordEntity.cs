namespace MedicalDocumentationManager.Persistence.Entities;

public class MedicalRecordEntity
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public required string Record { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public virtual PatientEntity PatientEntity { get; set; } = null!;
    public virtual DoctorEntity DoctorEntity { get; set; } = null!;
    public virtual ICollection<SubscriptionEntity>? Subscriptions { get; set; }
}