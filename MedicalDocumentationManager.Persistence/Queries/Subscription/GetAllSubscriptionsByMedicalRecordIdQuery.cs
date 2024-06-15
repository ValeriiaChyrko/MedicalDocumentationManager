using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Subscription;

public record GetAllSubscriptionsByMedicalRecordIdQuery(Guid MedicalRecordId) : IRequest<IEnumerable<SubscriptionDto>>;