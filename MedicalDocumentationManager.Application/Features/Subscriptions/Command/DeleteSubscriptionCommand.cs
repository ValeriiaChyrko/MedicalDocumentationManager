using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Command;

public sealed record DeleteSubscriptionCommand(long Id) : ICommand;