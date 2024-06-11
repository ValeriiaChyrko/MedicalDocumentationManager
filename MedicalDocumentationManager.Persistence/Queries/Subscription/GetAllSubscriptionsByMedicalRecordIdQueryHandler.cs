using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Subscription;

public sealed class GetAllSubscriptionsByMedicalRecordIdQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllSubscriptionsByMedicalRecordIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondSubscriptionDto>> Handle(GetAllSubscriptionsByMedicalRecordIdQuery query, CancellationToken cancellationToken)
    {
        var subscriptionEntities = await _context
            .SubscriptionEntities
            .Where(m => m.MedicalRecordId == query.MedicalRecordId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return subscriptionEntities.Select(entityModel => _mapper.Map<RespondSubscriptionDto>(entityModel)).ToList();
    }
}