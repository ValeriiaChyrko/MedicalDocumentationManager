using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Doctor;

public record GetDoctorByIdWithAddressQuery(Guid Id) : IRequest<RespondDoctorDto?>;