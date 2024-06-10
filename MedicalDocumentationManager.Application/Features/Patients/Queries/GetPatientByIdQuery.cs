using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Patients.Queries;

public record GetPatientByIdQuery(Guid Id) : IQuery<PatientEntity>;