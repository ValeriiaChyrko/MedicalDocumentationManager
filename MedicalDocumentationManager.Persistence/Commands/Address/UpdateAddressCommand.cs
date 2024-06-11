using MedicalDocumentationManager.DTOs.RequestsDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed record UpdateAddressCommand(long Id, RequestAddressDto RequestAddressDto);