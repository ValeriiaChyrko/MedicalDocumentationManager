using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed record UpdateSubscriptionCommand(long Id, SubscriptionDto SubscriptionDto) : IRequest<SubscriptionDto>;