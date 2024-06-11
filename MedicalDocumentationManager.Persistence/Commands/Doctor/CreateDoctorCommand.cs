using MedicalDocumentationManager.DTOs.RequestsDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public sealed record CreateDoctorCommand(RequestDoctorDto RequestDoctorDto);