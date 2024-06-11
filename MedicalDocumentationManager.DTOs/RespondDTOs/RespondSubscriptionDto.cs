namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondSubscriptionDto
{
    public long Id { get; init; }
    public Guid PatientId { get; init; }
    public Guid MedicalRecordId { get; init; }
    public required string SubscriptionType { get; init; }
}