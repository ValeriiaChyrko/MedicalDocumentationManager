using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Patient;

public record GetPatientByIdQuery(Guid Id) : IRequest<RespondPatientDto?>;