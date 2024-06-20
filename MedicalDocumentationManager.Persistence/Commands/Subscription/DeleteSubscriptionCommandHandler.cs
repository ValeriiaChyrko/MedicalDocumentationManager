using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteSubscriptionCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(DeleteSubscriptionCommand command, CancellationToken cancellationToken)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        var subscriptionEntity = await _context
            .SubscriptionEntities
            .FirstOrDefaultAsync(s =>
                    s.PatientId == command.PatientId 
                    && s.MedicalRecordId == command.MedicalRecordId
                    && s.SubscriptionType == command.SubscriptionType,
                cancellationToken);
        
        if (subscriptionEntity != null)
        {
            _context.SubscriptionEntities.Remove(subscriptionEntity);
        }
    }
}