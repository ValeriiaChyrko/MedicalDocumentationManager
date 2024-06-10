using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.MedicalRecords.Queries;

public sealed class GetMedicalRecordByIdQueryHandler : IQueryHandler<GetDoctorByIdQuery, DoctorEntity>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetMedicalRecordByIdQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<DoctorEntity>> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
    {
        var doctors = await _context
            .DoctorEntities
            .FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

        return doctors is null ? DoctorErrors.NotFound(query.Id) : Result.Success(doctors);
    }
}