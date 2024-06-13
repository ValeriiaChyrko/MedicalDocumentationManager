using AutoMapper;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Patient;

public sealed class UpdatePatientCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public UpdatePatientCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<RespondPatientDto> Handle(UpdatePatientCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        
        var patientEntity = _mapper.Map<PatientEntity>(command.RequestPatientDto);
        patientEntity.Id = command.Id;
        patientEntity.AddressId = command.AddressId;

        _context.PatientEntities.Update(patientEntity);

        return Task.FromResult(_mapper.Map<RespondPatientDto>(patientEntity));
    }
}