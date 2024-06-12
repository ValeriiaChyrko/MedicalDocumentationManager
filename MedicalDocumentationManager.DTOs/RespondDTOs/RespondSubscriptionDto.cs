namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondSubscriptionDto
{
    public long Id { get; set; }
    public Guid PatientId { get; set; }
    public Guid MedicalRecordId { get; set; }
    public required string SubscriptionType { get; set; }
}