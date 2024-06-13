using AutoMapper;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public sealed class CreateDoctorCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public CreateDoctorCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondDoctorDto> Handle(CreateDoctorCommand command, CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        
        var doctorEntity = _mapper.Map<DoctorEntity>(command.RequestDoctorDto);
        doctorEntity.AddressId = command.AddressId;
        
        var addedEntity = await _context.DoctorEntities.AddAsync(doctorEntity, cancellationToken);
        _context.DetachEntity(doctorEntity);

        return _mapper.Map<RespondDoctorDto>(addedEntity.Entity);
    }
}