using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed record CreateAddressCommand(AddressDto AddressDto) : IRequest<AddressDto>;