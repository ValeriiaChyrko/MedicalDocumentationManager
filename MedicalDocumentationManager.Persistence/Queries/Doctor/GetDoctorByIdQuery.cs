using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Doctor;

public record GetDoctorByIdQuery(Guid Id) : IRequest<RespondDoctorDto?>;