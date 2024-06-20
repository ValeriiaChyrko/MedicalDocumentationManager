using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Implementations;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Commands.Address;
using MedicalDocumentationManager.Persistence.Commands.Patient;
using MedicalDocumentationManager.Persistence.Queries.Address;
using MedicalDocumentationManager.Persistence.Queries.Patient;
using Microsoft.EntityFrameworkCore.Storage;
using CancellationToken = System.Threading.CancellationToken;
using DeletePatientCommand = MedicalDocumentationManager.Persistence.Commands.Patient.DeletePatientCommand;

namespace MedicalDocumentationManager.Application.Tests;

public class PatientServiceTests
{
    private IPatientService _patientService = null!;
    private IMediator _mediator = null!;
    private IDatabaseTransactionManager _transactionManager = null!;
    private ILogger _logger = null!;

    [SetUp]
    public void Setup()
    {
        _mediator = Substitute.For<IMediator>();
        _transactionManager = Substitute.For<IDatabaseTransactionManager>();
        _logger = Substitute.For<ILogger>();

        _patientService = new PatientService(_logger, _transactionManager, _mediator);
    }

    [Test]
    public async Task CreatePatientAsync_Should_Create_Patient_And_Address()
    {
        // Arrange
        var patientRequest = new RequestPatientDto
        {
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            Address = new AddressDto
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                Zip = "12345"
            },
            InsuranceProvider = "ABC Insurance",
            InsurancePolicyNumber = "1234567890"
        };

        var addressResponse = new AddressDto
        {
            Id = 1,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };

        var patientResponse = new RespondPatientDto
        {
            Id = Guid.NewGuid(),
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            Address = addressResponse,
            InsuranceProvider = "ABC Insurance",
            InsurancePolicyNumber = "1234567890"
        };

        _mediator.Send(Arg.Any<CreateAddressCommand>()).Returns(addressResponse);
        _mediator.Send(Arg.Any<CreatePatientCommand>()).Returns(patientResponse);

        // Act
        var result = await _patientService.CreatePatientAsync(patientRequest);

        // Assert
        result.Should().BeEquivalentTo(patientResponse);
    }

    [Test]
    public void CreatePatientAsync_Should_Rollback_Transaction_On_Exception()
    {
        // Arrange
        var patientRequest = new RequestPatientDto
        {
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            Address = new AddressDto
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                Zip = "12345"
            },
            InsuranceProvider = "ABC Insurance",
            InsurancePolicyNumber = "1234567890"
        };

        _mediator.Send(Arg.Any<CreateAddressCommand>()).Throws<Exception>();

        // Act
        Assert.ThrowsAsync<DatabaseException>(() => _patientService.CreatePatientAsync(patientRequest));

        // Assert
        _transactionManager.Received(1).RollbackAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task UpdatePatientAsync_Should_Update_Patient_And_Address()
    {
        // Arrange
        var patientRequest = new RequestPatientDto
        {
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            Address = new AddressDto
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                Zip = "12345"
            },
            InsuranceProvider = "ABC Insurance",
            InsurancePolicyNumber = "1234567890"
        };

        var addressResponse = new AddressDto
        {
            Id = 1,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };

        var patientResponse = new RespondPatientDto
        {
            Id = Guid.NewGuid(),
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            Address = addressResponse,
            InsuranceProvider = "ABC Insurance",
            InsurancePolicyNumber = "1234567890"
        };

        _mediator.Send(Arg.Any<GetAddressIfExistsQuery>()).Returns(addressResponse);
        _mediator.Send(Arg.Any<UpdatePatientCommand>()).Returns(patientResponse);

        // Act
        var result = await _patientService.UpdatePatientAsync(Guid.NewGuid(), patientRequest);

        // Assert
        result.Should().BeEquivalentTo(patientResponse);
    }

    [Test]
    public async Task UpdatePatientAsync_Should_Rollback_Transaction_On_Exception()
    {
        // Arrange
        var patientRequest = new RequestPatientDto
        {
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            Address = new AddressDto
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                Zip = "12345"
            },
            InsuranceProvider = "ABC Insurance",
            InsurancePolicyNumber = "1234567890"
        };

        _mediator.Send(Arg.Any<GetAddressIfExistsQuery>()).Throws<Exception>();

        // Act
        Assert.ThrowsAsync<DatabaseException>(() =>
            _patientService.UpdatePatientAsync(Guid.NewGuid(), patientRequest));

        // Assert
        await _transactionManager.Received(1).BeginTransactionAsync();
        var transaction = _transactionManager.Received().BeginTransactionAsync().Result;
        await transaction.Received(1).RollbackAsync(Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task DeletePatientAsync_Should_Delete_Patient()
    {
        // Arrange
        var patientId = Guid.NewGuid();

        _mediator.Send(Arg.Any<DeletePatientCommand>()).Returns(Task.CompletedTask);

        // Act
        await _patientService.DeletePatientAsync(patientId);

        // Assert
        await _mediator.Received(1).Send(Arg.Any<DeletePatientCommand>());
    }

    [Test]
    public async Task DeletePatientAsync_Should_Rollback_Transaction_On_Exception()
    {
        // Arrange
        var patientId = Guid.NewGuid();

        _mediator.Send(Arg.Any<DeletePatientCommand>()).Throws<Exception>();

        // Act
        Assert.ThrowsAsync<DatabaseException>(() => _patientService.DeletePatientAsync(patientId));

        // Assert
        await _transactionManager.Received(1).BeginTransactionAsync();
        var transaction = _transactionManager.Received().BeginTransactionAsync().Result;
        await transaction.Received(1).RollbackAsync(Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task GetPatientByIdAsync_Should_Return_Patient()
    {
        // Arrange
        var patientId = Guid.NewGuid();

        var addressResponse = new AddressDto
        {
            Id = 1,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };

        var patientResponse = new RespondPatientDto
        {
            Id = patientId,
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            Address = addressResponse,
            InsuranceProvider = "ABC Insurance",
            InsurancePolicyNumber = "1234567890"
        };

        _mediator.Send(Arg.Any<GetAddressByDoctorIdQuery>()).Returns(addressResponse);
        _mediator.Send(Arg.Any<GetPatientByIdQuery>()).Returns(patientResponse);

        // Act
        var result = await _patientService.GetPatientByIdAsync(patientId);

        // Assert
        result.Should().BeEquivalentTo(patientResponse);
    }

    [Test]
    public void GetPatientByIdAsync_Should_Throw_Exception_On_Error()
    {
        // Arrange
        var patientId = Guid.NewGuid();

        _mediator.Send(Arg.Any<GetPatientByIdQuery>()).Throws<Exception>();

        // Act
        Assert.ThrowsAsync<DatabaseException>(() => _patientService.GetPatientByIdAsync(patientId));
    }

    [Test]
    public async Task GetPatientsAsync_Should_Return_Patients()
    {
        // Arrange
        var patientsResponse = new List<RespondPatientDto>
        {
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                Address = new AddressDto
                {
                    Id = 1,
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "CA",
                    Zip = "12345"
                },
                InsuranceProvider = "ABC Insurance",
                InsurancePolicyNumber = "1234567890"
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Jane Doe",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                PhoneNumber = "9876543210",
                Email = "jane.doe@example.com",
                Address = new AddressDto
                {
                    Id = 2,
                    Street = "456 Elm St",
                    City = "Othertown",
                    State = "NY",
                    Zip = "67890"
                },
                InsuranceProvider = "XYZ Insurance",
                InsurancePolicyNumber = "9876543210"
            }
        };

        _mediator.Send(Arg.Any<GetAllPatientsQuery>()).Returns(patientsResponse);

        // Act
        var result = await _patientService.GetPatientsAsync();

        // Assert
        result.Should().BeEquivalentTo(patientsResponse);
    }

    [Test]
    public void GetPatientsAsync_Should_Throw_Exception_On_Error()
    {
        // Arrange
        _mediator.Send(Arg.Any<GetAllPatientsQuery>()).Throws<Exception>();

        // Act
        Assert.ThrowsAsync<DatabaseException>(() => _patientService.GetPatientsAsync());
    }
    
    [Test]
    public async Task GetPatientWithAddressByIdAsync_Should_Return_Patient_With_Address()
    {
        // Arrange
        var patientId = Guid.NewGuid();
        var addressResponse = new AddressDto
        {
            Id = 1,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };

        var patientResponse = new RespondPatientDto
        {
            Id = patientId,
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            PhoneNumber = "1234567890",
            Email = "john.doe@example.com",
            Address = addressResponse,
            InsuranceProvider = "ABC Insurance",
            InsurancePolicyNumber = "1234567890"
        };

        _mediator.Send(Arg.Any<GetPatientByIdWithAddressQuery>()).Returns(patientResponse);

        // Act
        var result = await _patientService.GetPatientWithAddressByIdAsync(patientId);

        // Assert
        result.Should().BeEquivalentTo(patientResponse);
    }

    [Test]
    public void GetPatientWithAddressByIdAsync_Should_Throw_Exception_On_Error()
    {
        // Arrange
        var patientId = Guid.NewGuid();

        _mediator.Send(Arg.Any<GetPatientByIdWithAddressQuery>()).Throws<Exception>();

        // Act
        Assert.ThrowsAsync<DatabaseException>(() => _patientService.GetPatientWithAddressByIdAsync(patientId));
    }
}