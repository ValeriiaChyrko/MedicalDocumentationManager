using MedicalDocumentationManager.Database.Contexts.Abstractions;

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
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        
        var subscriptionEntity = await _context.SubscriptionEntities.FindAsync(command.Id, cancellationToken);
        if (subscriptionEntity!= null)
        {
            _context.SubscriptionEntities.Remove(subscriptionEntity);
        }
    }
}