using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public sealed class GetAllMedicalRecordsByDoctorIdQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMedicalRecordsByDoctorIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondDoctorDto>> Handle(GetAllMedicalRecordsByDoctorIdQuery query,
        CancellationToken cancellationToken)
    {
        var medicalRecordEntities = await _context
            .MedicalRecordEntities
            .Where(m => m.DoctorId == query.DoctorId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalRecordEntities.Select(entityModel => _mapper.Map<RespondDoctorDto>(entityModel)).ToList();
    }
}