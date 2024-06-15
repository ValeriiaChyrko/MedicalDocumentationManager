using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondPatientDto
{
    public required Guid Id { get; set; }
    public required string FullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public long AddressId { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required AddressDto Address { get; set; }
    public required string InsuranceProvider { get; set; }
    public required string InsurancePolicyNumber { get; set; }
}