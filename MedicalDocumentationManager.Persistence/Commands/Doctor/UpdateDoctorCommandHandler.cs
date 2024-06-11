using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public sealed class UpdateDoctorCommandHandler 
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public UpdateDoctorCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<RespondDoctorDto> Handle(UpdateDoctorCommand command)
    {
        var doctorEntity = _mapper.Map<DoctorEntity>(command.RequestDoctorDto);
        doctorEntity.Id = command.Id;

        _context.DoctorEntities.Update(doctorEntity);

        return Task.FromResult(_mapper.Map<RespondDoctorDto>(doctorEntity));
    }
}