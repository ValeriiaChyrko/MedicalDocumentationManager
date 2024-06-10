using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Subscriptions.Queries;

public record GetSubscriptionByIdQuery(long Id) : IQuery<SubscriptionEntity>;