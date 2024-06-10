using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Queries;

public sealed class GetSubscriptionByIdQueryHandler : IQueryHandler<GetSubscriptionByIdQuery, SubscriptionEntity>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetSubscriptionByIdQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<SubscriptionEntity>> Handle(GetSubscriptionByIdQuery query,
        CancellationToken cancellationToken)
    {
        var patients = await _context
            .SubscriptionEntities
            .FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

        return patients is null ? SubscriptionErrors.NotFound(query.Id) : Result.Success(patients);
    }
}