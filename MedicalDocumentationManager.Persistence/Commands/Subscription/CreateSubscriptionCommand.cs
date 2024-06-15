using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed record CreateSubscriptionCommand(SubscriptionDto SubscriptionDto) : IRequest<SubscriptionDto>;