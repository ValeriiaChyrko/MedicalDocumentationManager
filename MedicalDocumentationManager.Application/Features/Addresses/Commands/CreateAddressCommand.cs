using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Addresses.Commands;

public sealed record CreateAddressCommand
    (string Street, string City, string State, string Zip) : ICommand<AddressEntity>;