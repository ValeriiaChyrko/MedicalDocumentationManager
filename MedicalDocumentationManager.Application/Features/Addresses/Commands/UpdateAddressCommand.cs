using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Addresses.Commands;

public sealed record UpdateAddressCommand(long Id, string Street, string City, string State, string Zip) : ICommand;