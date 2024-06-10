using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.MedicalRecords.Queries;

public sealed class GetDoctorByIdQueryHandler : IQueryHandler<GetMedicalRecordByIdQuery, MedicalRecordEntity>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetDoctorByIdQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<MedicalRecordEntity>> Handle(GetMedicalRecordByIdQuery query,
        CancellationToken cancellationToken)
    {
        var medicalRecords = await _context
            .MedicalRecordEntities
            .FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

        return medicalRecords is null ? MedicalRecordsErrors.NotFound(query.Id) : Result.Success(medicalRecords);
    }
}