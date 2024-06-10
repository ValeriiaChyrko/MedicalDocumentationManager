using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Command;

public sealed class DeleteSubscriptionCommandHandler : ICommandHandler<DeleteSubscriptionCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteSubscriptionCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(DeleteSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = await _context
            .SubscriptionEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (subscription is null) return SubscriptionErrors.NotFound(command.Id);

        _context
            .SubscriptionEntities
            .Remove(subscription);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}