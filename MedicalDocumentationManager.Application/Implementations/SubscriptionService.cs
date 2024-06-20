using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Enums;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Commands.Subscription;
using MedicalDocumentationManager.Persistence.Queries.Patient;
using MedicalDocumentationManager.Persistence.Queries.Subscription;

namespace MedicalDocumentationManager.Application.Implementations;

public class SubscriptionService : ISubscriptionService
{
    private readonly ILogger _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IDatabaseTransactionManager _transactionManager;

    public SubscriptionService(ILogger logger, IMediator mediator, IMapper mapper, IDatabaseTransactionManager transactionManager)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
        _transactionManager = transactionManager;
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
    
    public async Task SubscribePatientToMedicalRecordUpdatesAsync(Guid patientId, Guid medicalRecordId, 
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            var subscription = new SubscriptionDto
            {
                PatientId = patientId,
                MedicalRecordId = medicalRecordId,
                SubscriptionType = SubscriptionType.Observer.ToString()
            };
            
            await _mediator.Send(new CreateSubscriptionCommand(subscription), cancellationToken);

            await _transactionManager.CommitAsync(transaction, cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error creating subscription {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error subscribe patient to medical record updates", ex);
        }
    }
    
    public async Task UnsubscribePatientFromMedicalRecordUpdatesAsync(Guid patientId, Guid medicalRecordId, 
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            await _mediator.Send(
                new DeleteSubscriptionCommand(
                    patientId,
                    medicalRecordId,
                    SubscriptionType.Observer.ToString()
                ), cancellationToken);

            await _transactionManager.CommitAsync(transaction, cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error deleting subscription {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error unsubscribe patient to medical record updates", ex);
        }
    }
    
    public async Task SubscribePatientToMedicalRecordNotificationAsync(Guid patientId, Guid medicalRecordId, 
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            var subscription = new SubscriptionDto
            {
                PatientId = patientId,
                MedicalRecordId = medicalRecordId,
                SubscriptionType = SubscriptionType.Notifier.ToString()
            };
            
            await _mediator.Send(new CreateSubscriptionCommand(subscription), cancellationToken);

            await _transactionManager.CommitAsync(transaction, cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error creating subscription {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error subscribe patient to medical record updates", ex);
        }
    }
    
    public async Task UnsubscribePatientFromMedicalRecordNotificationAsync(Guid patientId, Guid medicalRecordId, 
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            await _mediator.Send(
                new DeleteSubscriptionCommand(
                    patientId,
                    medicalRecordId,
                    SubscriptionType.Notifier.ToString()
                ), cancellationToken);

            await _transactionManager.CommitAsync(transaction, cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error deleting subscription {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error unsubscribe patient to medical record updates", ex);
        }
    }
}