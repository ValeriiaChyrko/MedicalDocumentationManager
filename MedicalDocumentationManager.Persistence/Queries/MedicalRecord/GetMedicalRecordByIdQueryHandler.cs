﻿using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

public sealed class GetMedicalRecordByIdQueryHandler
    : IRequestHandler<GetMedicalRecordByIdQuery, RespondMedicalRecordDto?>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetMedicalRecordByIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondMedicalRecordDto?> Handle(GetMedicalRecordByIdQuery query,
        CancellationToken cancellationToken)
    {
        var medicalRecordEntity =
            await _context.MedicalRecordEntities
                .AsNoTracking()
                .FirstOrDefaultAsync(mr => mr.Id == query.Id, cancellationToken);

        return medicalRecordEntity != null ? _mapper.Map<RespondMedicalRecordDto>(medicalRecordEntity) : null;
    }
}