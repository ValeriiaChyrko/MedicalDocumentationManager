using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Queries;

public sealed class GetAllSubscriptionQueryHandler : IQueryHandler<GetAllSubscriptionQuery, List<SubscriptionEntity>>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetAllSubscriptionQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<SubscriptionEntity>>> Handle(GetAllSubscriptionQuery query,
        CancellationToken cancellationToken)
    {
        var subscriptions = await _context
            .SubscriptionEntities
            .ToListAsync(cancellationToken);

        return Result.Success(subscriptions);
    }
}