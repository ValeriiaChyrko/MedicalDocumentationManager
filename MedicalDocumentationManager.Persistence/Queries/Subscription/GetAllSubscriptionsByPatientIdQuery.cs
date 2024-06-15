using MediatR;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Subscription;

public record GetAllSubscriptionsByPatientIdQuery(Guid PatientId) : IRequest<IEnumerable<SubscriptionDto>>;