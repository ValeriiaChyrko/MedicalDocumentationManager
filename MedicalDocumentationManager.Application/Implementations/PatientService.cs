using MediatR;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Commands.Address;
using MedicalDocumentationManager.Persistence.Commands.Patient;
using MedicalDocumentationManager.Persistence.Queries.Address;
using MedicalDocumentationManager.Persistence.Queries.Patient;

namespace MedicalDocumentationManager.Application.Implementations;

public class PatientService : IPatientService
{
    private readonly ILogger _logger;
    private readonly IDatabaseTransactionManager _transactionManager;
    private readonly IMediator _mediator;

    public PatientService(ILogger logger, IDatabaseTransactionManager transactionManager, IMediator mediator)
    {
        _logger = logger;
        _transactionManager = transactionManager;
        _mediator = mediator;
    }

    public async Task<RespondPatientDto> CreatePatientAsync(RequestPatientDto patient, 
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            var address = await _mediator.Send( new CreateAddressCommand(patient.Address), cancellationToken);

            var result = await _mediator.Send( new CreatePatientCommand(patient, address.Id), cancellationToken);
            result.Address = address;

            await _transactionManager.CommitAsync(transaction, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            await _transactionManager.RollbackAsync(transaction, cancellationToken);
            _logger.Log($"Error creating patient {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error creating patient", ex);
        }
    }

    public async Task<RespondPatientDto> UpdatePatientAsync(Guid id, RequestPatientDto patient, 
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            var address = await _mediator.Send(new GetAddressIfExistsQuery(patient.Address), cancellationToken) 
                          ?? await _mediator.Send(new CreateAddressCommand(patient.Address), cancellationToken);

            var result = await _mediator.Send(new UpdatePatientCommand(id, patient, address.Id), cancellationToken);
            result.Address = address;

            await _transactionManager.CommitAsync(transaction, cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error updating patient {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error updating patient", ex);
        }
    }

    public async Task DeletePatientAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            await _mediator.Send(new DeletePatientCommand(id), cancellationToken);

            await _transactionManager.CommitAsync(transaction, cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error deleting patient {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error deleting patient", ex);
        }
    }

    public async Task<RespondPatientDto?> GetPatientByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var patient = await _mediator.Send(new GetPatientByIdQuery(id), cancellationToken);
            return patient;
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting patient {ex.InnerException}.");

            throw new DatabaseException("Error getting patient", ex);
        }
    }
    
    public async Task<RespondPatientDto?> GetPatientWithAddressByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var patient = await _mediator.Send(new GetPatientByIdWithAddressQuery(id), cancellationToken);
            return patient;
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting patient {ex.InnerException}.");

            throw new DatabaseException("Error getting patient", ex);
        }
    }

    public async Task<IReadOnlyList<RespondPatientDto>> GetPatientsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var patient = await _mediator.Send(new GetAllPatientsQuery(), cancellationToken);
            
            return patient.ToList();
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting patient entities {ex.InnerException}.");

            throw new DatabaseException("Error getting patient entities", ex);
        }
    }
}