using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Command;

public sealed class UpdateSubscriptionCommandHandler : ICommandHandler<UpdateSubscriptionCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public UpdateSubscriptionCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(UpdateSubscriptionCommand command, CancellationToken cancellationToken)
    {
        var subscription = await _context
            .SubscriptionEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (subscription is null) return SubscriptionErrors.NotFound(command.Id);

        subscription.PatientId = command.PatientId;
        subscription.MedicalRecordId = command.MedicalRecordId;
        subscription.SubscriptionType = command.SubscriptionType;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(subscription);
    }
}