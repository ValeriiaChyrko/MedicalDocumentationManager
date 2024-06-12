namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondMedicalRecordDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public required string Record { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}