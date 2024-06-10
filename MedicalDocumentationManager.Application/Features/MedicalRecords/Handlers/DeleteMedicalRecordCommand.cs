using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.MedicalRecords.Handlers;

public sealed record DeleteMedicalRecordCommand(Guid Id) : ICommand;