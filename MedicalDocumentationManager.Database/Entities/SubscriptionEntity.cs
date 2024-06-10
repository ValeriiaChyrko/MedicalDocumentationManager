namespace MedicalDocumentationManager.Database.Entities;

public class SubscriptionEntity
{
    public long Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid MedicalRecordId { get; set; }
    public required string SubscriptionType { get; set; } // "Observer", "Notifier"

    public virtual PatientEntity PatientEntity { get; set; } = null!;
    public virtual MedicalRecordEntity MedicalRecordEntity { get; set; } = null!;
}