namespace MedicalDocumentationManager.Database.Entities;

public class PatientEntity
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public long AddressId { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string InsuranceProvider { get; set; }
    public required string InsurancePolicyNumber { get; set; }

    public virtual AddressEntity AddressEntity { get; set; } = null!;
    public virtual ICollection<MedicalRecordEntity>? MedicalRecords { get; set; }
    public virtual ICollection<SubscriptionEntity>? Subscriptions { get; set; }
}