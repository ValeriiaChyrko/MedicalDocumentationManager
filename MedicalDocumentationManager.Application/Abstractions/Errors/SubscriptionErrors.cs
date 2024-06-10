using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Abstractions.Errors;

public static class SubscriptionErrors
{
    public static Result<SubscriptionEntity> NotFound(long subscriptionId)
    {
        return Result.Failure<SubscriptionEntity>(new Error("SubscriptionId.NotFound",
            $"The subscription with the id = '{subscriptionId}' was not found"));
    }
}