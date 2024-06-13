using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed record UpdateAddressCommand(long Id, AddressDto AddressDto);