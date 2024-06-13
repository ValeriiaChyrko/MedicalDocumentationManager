using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.RequestsDTOs;

public class RequestPatientDto
{
    public required string FullName { get; init; }
    public DateOnly BirthDate { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Email { get; init; }
    public required AddressDto Address { get; init; }
    public required string InsuranceProvider { get; init; }
    public required string InsurancePolicyNumber { get; init; }
}