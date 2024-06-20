using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public sealed class GetAllMedicalRecordsQueryHandler
    : IRequestHandler<GetAllMedicalRecordsQuery, IEnumerable<RespondMedicalRecordDto>>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllMedicalRecordsQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondMedicalRecordDto>> Handle(GetAllMedicalRecordsQuery query,
        CancellationToken cancellationToken)
    {
        var doctors = await _context
            .MedicalRecordEntities
            .AsNoTracking()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return doctors.Select(entityModel => _mapper.Map<RespondMedicalRecordDto>(entityModel)).ToList();
    }
}