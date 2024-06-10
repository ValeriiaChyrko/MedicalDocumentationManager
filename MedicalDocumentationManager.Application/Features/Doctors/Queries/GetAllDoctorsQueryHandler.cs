using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Doctors.Queries;

public sealed class GetAllDoctorsQueryHandler : IQueryHandler<GetAllDoctorsQuery, List<DoctorEntity>>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetAllDoctorsQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<DoctorEntity>>> Handle(GetAllDoctorsQuery query,
        CancellationToken cancellationToken)
    {
        var doctors = await _context
            .DoctorEntities
            .ToListAsync(cancellationToken);

        return Result.Success(doctors);
    }
}