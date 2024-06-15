using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public record GetAllMedicalRecordsByDoctorIdQuery(Guid DoctorId) : IRequest<IEnumerable<RespondMedicalRecordDto>>;