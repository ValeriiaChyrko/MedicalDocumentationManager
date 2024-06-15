using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public record GetAddressIfExistsQuery(AddressDto AddressDto) : IRequest<AddressDto?>;