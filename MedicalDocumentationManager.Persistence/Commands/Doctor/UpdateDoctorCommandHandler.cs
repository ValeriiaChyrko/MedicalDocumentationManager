using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public sealed class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, RespondDoctorDto>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public UpdateDoctorCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<RespondDoctorDto> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken = default)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var doctorEntity = _mapper.Map<DoctorEntity>(command.RequestDoctorDto);
        doctorEntity.Id = command.Id;
        doctorEntity.AddressId = command.AddressId;

        _context.DoctorEntities.Update(doctorEntity);

        return Task.FromResult(_mapper.Map<RespondDoctorDto>(doctorEntity));
    }
}