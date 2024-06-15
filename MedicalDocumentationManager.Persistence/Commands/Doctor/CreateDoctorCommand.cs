using MediatR;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public sealed record CreateDoctorCommand
    (RequestDoctorDto RequestDoctorDto, long AddressId) : IRequest<RespondDoctorDto>;