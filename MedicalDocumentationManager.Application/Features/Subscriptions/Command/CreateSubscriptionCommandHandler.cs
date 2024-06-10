using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Command;

public sealed class CreateSubscriptionCommandHandler : ICommandHandler<CreateSubscriptionCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public CreateSubscriptionCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(CreateSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = new SubscriptionEntity
        {
            PatientId = command.PatientId,
            MedicalRecordId = command.MedicalRecordId,
            SubscriptionType = command.SubscriptionType
        };

        _context
            .SubscriptionEntities
            .Add(subscription);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(subscription);
    }
}