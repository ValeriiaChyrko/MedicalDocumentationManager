using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Addresses.Commands;

public sealed record DeleteAddressCommand(long Id) : ICommand;