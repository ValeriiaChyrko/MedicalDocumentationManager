using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.Domain.Implementation;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Commands.MedicalRecord;
using MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

namespace MedicalDocumentationManager.Application.Implementations;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly ILogger _logger;
    private readonly IDatabaseTransactionManager _transactionManager;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IMessageHandler _messageHandler;
    private readonly ISubscriptionService _subscriptionService;

    public MedicalRecordService(ILogger logger, IDatabaseTransactionManager transactionManager, 
        IMediator mediator, IMapper mapper, IMessageHandler messageHandler, ISubscriptionService subscriptionService)
    {
        _logger = logger;
        _transactionManager = transactionManager;
        _mediator = mediator;
        _mapper = mapper;
        _messageHandler = messageHandler;
        _subscriptionService = subscriptionService;
    }

    public async Task<RespondMedicalRecordDto> CreateMedicalRecordAsync(RequestMedicalRecordDto medicalRecord, CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            var result = await _mediator.Send( 
                new CreateMedicalRecordCommand(medicalRecord), cancellationToken);

            await _transactionManager.CommitAsync(transaction, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            await _transactionManager.RollbackAsync(transaction, cancellationToken);
            _logger.Log($"Error creating medical record {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error creating  medical record", ex);
        }
    }

    public async Task<RespondMedicalRecordDto> UpdateMedicalRecordAsync(Guid id, RequestMedicalRecordDto medicalRecordDto, CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            var result = 
                await _mediator.Send(new UpdateMedicalRecordCommand(id, medicalRecordDto), cancellationToken);

            var medicalRecord = _mapper.Map<MedicalRecord>(result);
            var medicalRecordObserver = new MedicalRecordObserver(medicalRecord);
            var medicalRecordNotifier = new MedicalRecordNotifier(medicalRecordObserver, _messageHandler);

            await _subscriptionService.ProcessMedicalRecordSubscriptions(id, medicalRecordObserver, medicalRecordNotifier, cancellationToken);
            
            medicalRecord.Update(medicalRecordDto.PatientId, medicalRecordDto.DoctorId, medicalRecordDto.Record);
            
            await _transactionManager.CommitAsync(transaction, cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error updating medical record {ex.InnerException}. Using rollback transaction.");
            throw new DatabaseException("Error updating medical record", ex);
        }
    }

    public async Task DeleteMedicalRecordAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            await _mediator.Send(new DeleteMedicalRecordCommand(id), cancellationToken);

            await _transactionManager.CommitAsync(transaction, cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error deleting medical record {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error deleting medical record", ex);
        }
    }

    public async Task<RespondMedicalRecordDto?> GetMedicalRecordByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var medicalRecord = await _mediator.Send(new GetMedicalRecordByIdQuery(id), cancellationToken);

            return medicalRecord;
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting medical record {ex.InnerException}.");

            throw new DatabaseException("Error getting medical record", ex);
        }
    }

    public async Task<IReadOnlyList<RespondMedicalRecordDto>> GetMedicalRecordsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var medicalRecords = await _mediator.Send(new GetAllMedicalRecordsQuery(), cancellationToken);
            
            return medicalRecords.ToList();
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting medical records {ex.InnerException}.");

            throw new DatabaseException("Error getting medical records", ex);
        }
    }

    public async Task<IReadOnlyList<RespondMedicalRecordDto>> GetMedicalRecordsByPatientAsync(Guid patientId, CancellationToken cancellationToken = default)
    {
        try
        {
            var medicalRecords = await _mediator.Send(
                new GetAllMedicalRecordsByPatientIdQuery(patientId), cancellationToken);
            
            return medicalRecords.ToList();
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting medical records {ex.InnerException}.");

            throw new DatabaseException("Error getting medical records", ex);
        }
    }

    public async Task<IReadOnlyList<RespondMedicalRecordDto>> GetMedicalRecordsByDoctorAsync(Guid doctorId, CancellationToken cancellationToken = default)
    {
        try
        {
            var medicalRecords = await _mediator.Send(
                new GetAllMedicalRecordsByDoctorIdQuery(doctorId), cancellationToken);
            
            return medicalRecords.ToList();
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting medical records {ex.InnerException}.");

            throw new DatabaseException("Error getting medical records", ex);
        }
    }
}