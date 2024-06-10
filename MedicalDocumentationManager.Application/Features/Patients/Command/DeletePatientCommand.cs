using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Patients.Command;

public sealed record DeletePatientCommand(Guid Id) : ICommand;