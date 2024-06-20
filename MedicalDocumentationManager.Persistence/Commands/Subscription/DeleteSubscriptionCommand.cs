using MediatR;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed record DeleteSubscriptionCommand(Guid PatientId, Guid MedicalRecordId, string SubscriptionType) : IRequest;