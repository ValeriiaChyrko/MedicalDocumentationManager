using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed class DeleteSubscriptionCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteSubscriptionCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(DeleteSubscriptionCommand command, CancellationToken cancellationToken)
    {
        await _context
            .SubscriptionEntities
            .Where(t => t.Id == command.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}