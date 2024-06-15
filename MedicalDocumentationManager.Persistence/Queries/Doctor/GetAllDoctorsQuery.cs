using MediatR;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Doctor;

public record GetAllDoctorsQuery : IRequest<IEnumerable<RespondDoctorDto>>;