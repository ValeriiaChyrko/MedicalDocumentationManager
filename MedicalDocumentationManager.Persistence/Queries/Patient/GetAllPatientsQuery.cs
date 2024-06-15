using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Patient;

public record GetAllPatientsQuery : IRequest<IEnumerable<RespondPatientDto>>;