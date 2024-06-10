namespace MedicalDocumentationManager.Database.Entities;

public class AddressEntity
{
    public long Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Zip { get; set; }

    public virtual ICollection<PatientEntity>? Patients { get; set; }
    public virtual ICollection<DoctorEntity>? Doctors { get; set; }
}