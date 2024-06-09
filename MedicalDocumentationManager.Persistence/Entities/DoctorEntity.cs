namespace MedicalDocumentationManager.Persistence.Entities;

public class DoctorEntity
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public long AddressId { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Specialization { get; set; }
    public required long ExperienceInYears { get; set; }
    public required string Education { get; set; }
    public required string RoomNumber { get; set; }

    public virtual AddressEntity AddressEntity { get; set; } = null!;
    public virtual ICollection<MedicalRecordEntity>? MedicalRecords { get; set; }
}