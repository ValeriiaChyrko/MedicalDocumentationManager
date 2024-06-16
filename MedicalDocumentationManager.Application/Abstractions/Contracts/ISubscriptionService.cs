using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Application.Abstractions.Contracts;

public interface ISubscriptionService
{
    Task ProcessMedicalRecordSubscriptions(Guid medicalRecordId,
        IMedicalRecordObserver medicalRecordObserver, IMedicalRecordNotifier medicalRecordNotifier,
        CancellationToken cancellationToken);
}