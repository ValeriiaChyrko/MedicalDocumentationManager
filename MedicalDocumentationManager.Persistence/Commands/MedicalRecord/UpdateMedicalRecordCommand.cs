using MediatR;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

public sealed record UpdateMedicalRecordCommand
    (Guid Id, RequestMedicalRecordDto RequestMedicalRecordDto) : IRequest<RespondMedicalRecordDto>;