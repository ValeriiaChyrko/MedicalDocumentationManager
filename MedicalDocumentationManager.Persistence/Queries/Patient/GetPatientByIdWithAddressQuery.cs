using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Patient;

public record GetPatientByIdWithAddressQuery(Guid Id) : IRequest<RespondPatientDto?>;