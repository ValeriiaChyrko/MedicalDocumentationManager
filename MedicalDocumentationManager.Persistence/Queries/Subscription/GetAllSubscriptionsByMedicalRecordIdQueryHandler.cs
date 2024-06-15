using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Subscription;

public sealed class GetAllSubscriptionsByMedicalRecordIdQueryHandler
    : IRequestHandler<GetAllSubscriptionsByMedicalRecordIdQuery, IEnumerable<SubscriptionDto>>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSubscriptionsByMedicalRecordIdQueryHandler(IMedicalDocumentationManagerDbContext context,
        IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<SubscriptionDto>> Handle(GetAllSubscriptionsByMedicalRecordIdQuery query,
        CancellationToken cancellationToken)
    {
        var subscriptionEntities = await _context
            .SubscriptionEntities
            .Where(m => m.MedicalRecordId == query.MedicalRecordId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return subscriptionEntities.Select(entityModel => _mapper.Map<SubscriptionDto>(entityModel)).ToList();
    }
}