using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Doctors.Queries;

public record GetAllDoctorsQuery : IQuery<List<DoctorEntity>>;