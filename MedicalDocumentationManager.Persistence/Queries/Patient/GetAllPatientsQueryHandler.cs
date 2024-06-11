using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Patient;

public sealed class GetAllPatientsQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllPatientsQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondPatientDto>> Handle(GetAllPatientsQuery query,
        CancellationToken cancellationToken)
    {
        var patients = await _context
            .PatientEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return patients.Select(entityModel => _mapper.Map<RespondPatientDto>(entityModel)).ToList();
    }
}