using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Enums;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.Persistence.Queries.Patient;
using MedicalDocumentationManager.Persistence.Queries.Subscription;

namespace MedicalDocumentationManager.Application.Implementations;

public class SubscriptionService : ISubscriptionService
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SubscriptionService(ILogger logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task ProcessMedicalRecordSubscriptions(Guid medicalRecordId,
        IMedicalRecordObserver medicalRecordObserver, IMedicalRecordNotifier medicalRecordNotifier,
        CancellationToken cancellationToken)
    {
        try
        {
            var subscriptions =
                await _mediator.Send(new GetAllSubscriptionsByMedicalRecordIdQuery(medicalRecordId), cancellationToken);

            foreach (var subscription in subscriptions)
            {
                var resultPatientDto =
                    await _mediator.Send(new GetPatientByIdWithAddressQuery(subscription.PatientId),
                        cancellationToken);

                var patient = _mapper.Map<Patient>(resultPatientDto, opts =>
                {
                    opts.Items["medicalRecordObserver"] = medicalRecordObserver;
                    opts.Items["medicalRecordNotifier"] = medicalRecordNotifier;
                });

                if (subscription.SubscriptionType == SubscriptionType.Observer.ToString())
                {
                    patient.SubscribeToMedicalRecordUpdates();
                }
                else if (subscription.SubscriptionType == SubscriptionType.Notifier.ToString())
                {
                    patient.SubscribeToMedicalRecordNotifications();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Log(
                $"Error processing medical record subscriptions for medical record ID {medicalRecordId} : {ex.InnerException}");
        }
    }
}