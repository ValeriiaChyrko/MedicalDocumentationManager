using MediatR;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Commands.Address;
using MedicalDocumentationManager.Persistence.Commands.Doctor;
using MedicalDocumentationManager.Persistence.Queries.Address;
using MedicalDocumentationManager.Persistence.Queries.Doctor;

namespace MedicalDocumentationManager.Application.Implementations;

public class DoctorService : IDoctorService
{
    private readonly ILogger _logger;
    private readonly IDatabaseTransactionManager _transactionManager;
    private readonly IMediator _mediator;

    public DoctorService(IDatabaseTransactionManager transactionManager, ILogger logger, IMediator mediator)
    {
        _transactionManager = transactionManager;
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<RespondDoctorDto> CreateDoctorAsync(RequestDoctorDto doctor,
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            var address = await _mediator.Send( new CreateAddressCommand(doctor.Address), cancellationToken);

            var result = await _mediator.Send( new CreateDoctorCommand(doctor, address.Id), cancellationToken);
            result.Address = address;

            await _transactionManager.CommitAsync(transaction, cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            await _transactionManager.RollbackAsync(transaction, cancellationToken);
            _logger.Log($"Error creating doctor {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error creating doctor", ex);
        }
    }

    public async Task<RespondDoctorDto> UpdateDoctorAsync(Guid id, RequestDoctorDto doctor,
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            var address = await _mediator.Send(new GetAddressIfExistsQuery(doctor.Address), cancellationToken) 
                          ?? await _mediator.Send(new CreateAddressCommand(doctor.Address), cancellationToken);

            var result = await _mediator.Send(new UpdateDoctorCommand(id, doctor, address.Id), cancellationToken);
            result.Address = address;

            await _transactionManager.CommitAsync(transaction, cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error updating doctor {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error updating doctor", ex);
        }
    }

    public async Task DeleteDoctorAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await using var transaction = await _transactionManager.BeginTransactionAsync();
        try
        {
            await _mediator.Send(new DeleteDoctorCommand(id), cancellationToken);

            await _transactionManager.CommitAsync(transaction, cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.Log($"Error deleting doctor {ex.InnerException}. Using rollback transaction.");

            throw new DatabaseException("Error deleting doctor", ex);
        }
    }
    
    public async Task<IReadOnlyList<RespondDoctorDto>> GetDoctorsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var doctors = await _mediator.Send(new GetAllDoctorsQuery(), cancellationToken);
            
            return doctors.ToList();
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting doctor entities {ex.InnerException}.");

            throw new DatabaseException("Error getting doctor entities", ex);
        }
    }
    
    public async Task<RespondDoctorDto?> GetDoctorByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var address = await _mediator.Send(new GetAddressByDoctorIdQuery(id), cancellationToken);
            var doctor = await _mediator.Send(new GetDoctorByIdQuery(id), cancellationToken);
            doctor!.Address = address!;

            return doctor;
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting doctor {ex.InnerException}.");

            throw new DatabaseException("Error getting doctor", ex);
        }
    }
    
    public async Task<RespondDoctorDto?> GetDoctorWithAddressByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var doctor = await _mediator.Send(new GetDoctorByIdWithAddressQuery(id), cancellationToken);

            return doctor;
        }
        catch (Exception ex)
        {
            _logger.Log($"Error getting doctor {ex.InnerException}.");

            throw new DatabaseException("Error getting doctor", ex);
        }
    }
}