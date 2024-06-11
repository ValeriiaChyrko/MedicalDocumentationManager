namespace MedicalDocumentationManager.DTOs.RequestsDTOs;

public class RequestMedicalRecordDto
{
    public Guid PatientId { get; init; }
    public Guid DoctorId { get; init; }
    public required string Record { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}