using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Doctors.Commands;

public sealed record CreateDoctorCommand(Guid Id, string Name, DateOnly BirthDate, string PhoneNumber, string Email,
    long AddressId, string Specialization, uint ExperienceInYears, string Education, string RoomNumber) : ICommand;