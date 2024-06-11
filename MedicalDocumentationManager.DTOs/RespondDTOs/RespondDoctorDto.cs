namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondDoctorDto
{
    public Guid Id { get; init; }
    public required string FullName { get; init; }
    public DateOnly BirthDate { get; init; }
    public long AddressId { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Email { get; init; }
    public required string Specialization { get; init; }
    public required long ExperienceInYears { get; init; }
    public required string Education { get; init; }
    public required string RoomNumber { get; init; }
}