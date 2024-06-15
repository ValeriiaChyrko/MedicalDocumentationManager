using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public record GetAddressByPatientIdQuery(Guid PatientId) : IRequest<AddressDto?>;