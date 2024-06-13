namespace MedicalDocumentationManager.DTOs.SharedDTOs;

public class SubscriptionDto
{
    public long Id { get; set; }
    public Guid PatientId { get; init; }
    public Guid MedicalRecordId { get; init; }
    public required string SubscriptionType { get; init; }
}