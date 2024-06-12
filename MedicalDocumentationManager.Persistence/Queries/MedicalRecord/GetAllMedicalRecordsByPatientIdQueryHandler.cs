using AutoMapper;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public sealed class GetAllMedicalRecordsByPatientIdQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMedicalRecordsByPatientIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondMedicalRecordDto>> Handle(GetAllMedicalRecordsByPatientIdQuery query,
        CancellationToken cancellationToken)
    {
        var medicalRecords = await _context
            .MedicalRecordEntities
            .Where(m => m.PatientId == query.PatientId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalRecords.Select(entityModel => _mapper.Map<RespondMedicalRecordDto>(entityModel)).ToList();
    }
}