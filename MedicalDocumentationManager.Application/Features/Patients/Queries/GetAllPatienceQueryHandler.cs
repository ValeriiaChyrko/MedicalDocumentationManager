using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Patients.Queries;

public sealed class GetAllPatienceQueryHandler : IQueryHandler<GetAllPatientsQuery, List<PatientEntity>>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetAllPatienceQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<PatientEntity>>> Handle(GetAllPatientsQuery query,
        CancellationToken cancellationToken)
    {
        var patients = await _context
            .PatientEntities
            .ToListAsync(cancellationToken);

        return Result.Success(patients);
    }
}