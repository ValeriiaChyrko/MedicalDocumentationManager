using MediatR;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed record DeleteAddressCommand(long Id) : IRequest;