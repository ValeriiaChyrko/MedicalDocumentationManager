using MediatR;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

public sealed record CreateMedicalRecordCommand
    (RequestMedicalRecordDto RequestMedicalRecordDto) : IRequest<RespondMedicalRecordDto>;