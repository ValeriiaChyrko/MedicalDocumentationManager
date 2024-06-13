using MedicalDocumentationManager.DTOs.RequestsDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public record UpdateDoctorCommand(Guid Id, RequestDoctorDto RequestDoctorDto, long AddressId);