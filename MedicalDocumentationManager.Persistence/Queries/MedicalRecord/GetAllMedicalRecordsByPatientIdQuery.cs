using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public record GetAllMedicalRecordsByPatientIdQuery(Guid PatientId) : IRequest<IEnumerable<RespondMedicalRecordDto>>;