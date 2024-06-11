using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

public sealed class CreateMedicalRecordCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public CreateMedicalRecordCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondMedicalRecordDto> Handle(CreateMedicalRecordCommand command, CancellationToken cancellationToken)
    {
        var medicalRecordEntity = _mapper.Map<MedicalRecordEntity>(command.RequestMedicalRecordDto);
        var addedEntity = await _context.MedicalRecordEntities.AddAsync(medicalRecordEntity, cancellationToken);

        return _mapper.Map<RespondMedicalRecordDto>(addedEntity.Entity);
    }
}