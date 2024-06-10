using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Patients.Queries;

public sealed class GetDoctorByIdQueryHandler : IQueryHandler<GetPatientByIdQuery, PatientEntity>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetDoctorByIdQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<PatientEntity>> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
    {
        var patients = await _context
            .PatientEntities
            .FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

        return patients is null ? PatientErrors.NotFound(query.Id) : Result.Success(patients);
    }
}