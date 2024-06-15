using MediatR;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public record UpdateDoctorCommand
    (Guid Id, RequestDoctorDto RequestDoctorDto, long AddressId) : IRequest<RespondDoctorDto>;