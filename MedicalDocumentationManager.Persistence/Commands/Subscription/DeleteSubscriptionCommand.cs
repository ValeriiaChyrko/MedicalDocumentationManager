using MediatR;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed record DeleteSubscriptionCommand(long Id) : IRequest;