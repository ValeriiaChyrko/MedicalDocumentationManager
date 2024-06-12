using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public sealed class GetAllMedicalRecordsQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMedicalRecordsQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondDoctorDto>> Handle(GetAllMedicalRecordsQuery query,
        CancellationToken cancellationToken)
    {
        var doctors = await _context
            .MedicalRecordEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return doctors.Select(entityModel => _mapper.Map<RespondDoctorDto>(entityModel)).ToList();
    }
}