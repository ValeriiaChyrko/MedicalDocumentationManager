using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public record GetMedicalRecordByIdQuery(Guid Id) : IRequest<RespondMedicalRecordDto?>;