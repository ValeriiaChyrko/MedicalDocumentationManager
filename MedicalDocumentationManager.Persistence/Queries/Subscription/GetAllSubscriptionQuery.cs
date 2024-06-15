using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Subscription;

public record GetAllSubscriptionQuery : IRequest<IEnumerable<SubscriptionDto>>;