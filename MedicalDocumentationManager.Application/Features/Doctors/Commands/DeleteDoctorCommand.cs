using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Doctors.Commands;

public sealed record DeleteDoctorCommand(Guid Id) : ICommand;