using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Queries;

public record GetAllSubscriptionQuery : IQuery<List<SubscriptionEntity>>;