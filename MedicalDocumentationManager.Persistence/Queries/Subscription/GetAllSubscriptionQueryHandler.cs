using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Subscription;

public sealed class
    GetAllSubscriptionQueryHandler : IRequestHandler<GetAllSubscriptionQuery, IEnumerable<SubscriptionDto>>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSubscriptionQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<SubscriptionDto>> Handle(GetAllSubscriptionQuery query,
        CancellationToken cancellationToken)
    {
        var subscriptions = await _context
            .SubscriptionEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return subscriptions.Select(entityModel => _mapper.Map<SubscriptionDto>(entityModel)).ToList();
    }
}