using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Command;

public sealed record CreateSubscriptionCommand
    (Guid PatientId, Guid MedicalRecordId, string SubscriptionType) : ICommand;