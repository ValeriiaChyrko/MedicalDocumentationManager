namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondPatientDto
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public DateOnly BirthDate { get; init; }
    public long AddressId { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Email { get; init; }
    public required string InsuranceProvider { get; init; }
    public required string InsurancePolicyNumber { get; init; }
}