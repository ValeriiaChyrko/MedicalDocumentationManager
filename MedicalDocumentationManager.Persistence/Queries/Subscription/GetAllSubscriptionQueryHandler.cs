﻿using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Subscription;

public sealed class GetAllSubscriptionQueryHandler 
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSubscriptionQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondSubscriptionDto>> Handle(GetAllSubscriptionQuery query,
        CancellationToken cancellationToken)
    {
        var subscriptions = await _context
            .SubscriptionEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return subscriptions.Select(entityModel => _mapper.Map<RespondSubscriptionDto>(entityModel)).ToList();
    }
}