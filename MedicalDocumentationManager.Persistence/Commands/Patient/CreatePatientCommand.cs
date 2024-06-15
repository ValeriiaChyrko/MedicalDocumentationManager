using MediatR;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Patient;

public sealed record CreatePatientCommand
    (RequestPatientDto RequestPatientDto, long AddressId) : IRequest<RespondPatientDto>;