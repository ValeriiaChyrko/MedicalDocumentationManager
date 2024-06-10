using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Patients.Queries;

public record GetAllPatientsQuery : IQuery<List<PatientEntity>>;