using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Patient;

public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, RespondPatientDto>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public CreatePatientCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondPatientDto> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        var patientEntity = _mapper.Map<PatientEntity>(command.RequestPatientDto);
        patientEntity.AddressId = command.AddressId;

        var addedEntity = await _context.PatientEntities
            .AddAsync(patientEntity, cancellationToken);

        return _mapper.Map<RespondPatientDto>(addedEntity.Entity);
    }
}