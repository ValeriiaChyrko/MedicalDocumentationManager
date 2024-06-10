using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Command;

public sealed record UpdateSubscriptionCommand
    (long Id, Guid PatientId, Guid MedicalRecordId, string SubscriptionType) : ICommand;