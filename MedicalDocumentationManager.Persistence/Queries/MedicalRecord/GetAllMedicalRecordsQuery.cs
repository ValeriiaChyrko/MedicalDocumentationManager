using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public record GetAllMedicalRecordsQuery : IRequest<IEnumerable<RespondMedicalRecordDto>>;