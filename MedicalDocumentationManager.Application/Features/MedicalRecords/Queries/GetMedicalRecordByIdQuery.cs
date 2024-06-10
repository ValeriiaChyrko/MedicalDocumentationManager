using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.MedicalRecords.Queries;

public record GetMedicalRecordByIdQuery(Guid Id) : IQuery<MedicalRecordEntity>;