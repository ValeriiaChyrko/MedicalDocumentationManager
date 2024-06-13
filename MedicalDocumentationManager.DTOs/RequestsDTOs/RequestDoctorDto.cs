using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.RequestsDTOs;

public class RequestDoctorDto
{
    public required string FullName { get; init; }
    public DateOnly BirthDate { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Email { get; init; }
    public required AddressDto  Address { get; set; }
    public required string Specialization { get; init; }
    public required long ExperienceInYears { get; init; }
    public required string Education { get; init; }
    public required string RoomNumber { get; init; }
}