using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public sealed class GetMedicalRecordByIdQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetMedicalRecordByIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondMedicalRecordDto?> Handle(GetMedicalRecordByIdQuery query, CancellationToken cancellationToken)
    {
        var medicalRecordEntity = await _context.MedicalRecordEntities.FindAsync(new object[] { query.Id }, cancellationToken);
        
        return medicalRecordEntity != null ? _mapper.Map<RespondMedicalRecordDto>(medicalRecordEntity) : null;
    }
}