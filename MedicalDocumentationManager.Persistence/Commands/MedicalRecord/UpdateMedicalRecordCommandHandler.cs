﻿using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

public sealed class
    UpdateMedicalRecordCommandHandler : IRequestHandler<UpdateMedicalRecordCommand, RespondMedicalRecordDto>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public UpdateMedicalRecordCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<RespondMedicalRecordDto> Handle(UpdateMedicalRecordCommand command,
        CancellationToken cancellationToken = default)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        var medicalRecordEntity = _mapper.Map<MedicalRecordEntity>(command.RequestMedicalRecordDto);
        medicalRecordEntity.Id = command.Id;
        medicalRecordEntity.UpdatedAt = DateTime.UtcNow;

        _context.MedicalRecordEntities.Update(medicalRecordEntity);

        return Task.FromResult(_mapper.Map<RespondMedicalRecordDto>(medicalRecordEntity));
    }
}