namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondMedicalRecordDto
{
    public Guid Id { get; init; }
    public Guid PatientId { get; init; }
    public Guid DoctorId { get; init; }
    public required string Record { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}