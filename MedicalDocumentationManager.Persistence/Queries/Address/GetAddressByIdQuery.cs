using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public record GetAddressByIdQuery(long Id) : IRequest<AddressDto?>;