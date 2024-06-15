using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public sealed class GetAllMedicalRecordsByDoctorIdQueryHandler
    : IRequestHandler<GetAllMedicalRecordsByDoctorIdQuery, IEnumerable<RespondMedicalRecordDto>>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMedicalRecordsByDoctorIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondMedicalRecordDto>> Handle(GetAllMedicalRecordsByDoctorIdQuery query,
        CancellationToken cancellationToken)
    {
        var medicalRecordEntities = await _context
            .MedicalRecordEntities
            .Where(m => m.DoctorId == query.DoctorId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return medicalRecordEntities.Select(entityModel => _mapper.Map<RespondMedicalRecordDto>(entityModel)).ToList();
    }
}