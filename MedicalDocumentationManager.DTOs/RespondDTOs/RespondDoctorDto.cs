using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondDoctorDto
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public long AddressId { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required AddressDto  Address { get; set; }
    public required string Specialization { get; set; }
    public required long ExperienceInYears { get; set; }
    public required string Education { get; set; }
    public required string RoomNumber { get; set; }
}