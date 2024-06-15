using MediatR;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public sealed record DeleteDoctorCommand(Guid Id) : IRequest;