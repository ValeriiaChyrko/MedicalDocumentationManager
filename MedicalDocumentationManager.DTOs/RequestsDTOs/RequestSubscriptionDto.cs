namespace MedicalDocumentationManager.DTOs.RequestsDTOs;

public class RequestSubscriptionDto
{
    public Guid PatientId { get; init; }
    public Guid MedicalRecordId { get; init; }
    public required string SubscriptionType { get; init; }
}