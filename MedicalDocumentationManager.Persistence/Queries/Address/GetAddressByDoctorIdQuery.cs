using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public record GetAddressByDoctorIdQuery(Guid DoctorId) : IRequest<AddressDto?>;