using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

public sealed class
    CreateMedicalRecordCommandHandler : IRequestHandler<CreateMedicalRecordCommand, RespondMedicalRecordDto>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public CreateMedicalRecordCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondMedicalRecordDto> Handle(CreateMedicalRecordCommand command,
        CancellationToken cancellationToken)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        var medicalRecordEntity = _mapper.Map<MedicalRecordEntity>(command.RequestMedicalRecordDto);
        var addedEntity = await _context.MedicalRecordEntities.AddAsync(medicalRecordEntity, cancellationToken);

        return _mapper.Map<RespondMedicalRecordDto>(addedEntity.Entity);
    }
}