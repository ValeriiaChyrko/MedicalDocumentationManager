using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Implementations;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Commands.Address;
using MedicalDocumentationManager.Persistence.Commands.Doctor;
using MedicalDocumentationManager.Persistence.Queries.Address;
using MedicalDocumentationManager.Persistence.Queries.Doctor;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalDocumentationManager.Application.Tests;

[TestFixture]
public class DoctorServiceTests
{
    private IDoctorService _doctorService = null!;
    private IMediator _mediator = null!;
    private IDatabaseTransactionManager _transactionManager = null!;
    private ILogger _logger = null!;

    [SetUp]
    public void Setup()
    {
        _mediator = Substitute.For<IMediator>();
        _transactionManager = Substitute.For<IDatabaseTransactionManager>();
        _logger = Substitute.For<ILogger>();

        _doctorService = new DoctorService(_transactionManager, _logger, _mediator);
    }

    [Test]
    public async Task CreateDoctorAsync_Should_Return_Created_Doctor()
    {
        // Arrange
        var doctorRequest = new RequestDoctorDto
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
            Specialization = "General Practitioner",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };

        var addressResponse = new AddressDto
        {
            Id = 1,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };

        var doctorResponse = new RespondDoctorDto
        {
            Id = Guid.NewGuid(),
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
            Specialization = "General Practitioner",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };

        _mediator.Send(Arg.Any<CreateAddressCommand>()).Returns(addressResponse);
        _mediator.Send(Arg.Any<CreateDoctorCommand>()).Returns(doctorResponse);

        // Act
        var result = await _doctorService.CreateDoctorAsync(doctorRequest);

        // Assert
        result.Should().BeEquivalentTo(doctorResponse);
        await _transactionManager.Received(1)
            .CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task CreateDoctorAsync_Should_Rollback_Transaction_On_Exception()
    {
        // Arrange
        var doctorRequest = new RequestDoctorDto
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
            Specialization = "General Practitioner",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };

        _mediator.Send(Arg.Any<CreateAddressCommand>()).Throws<Exception>();

        // Act and Assert
        Assert.ThrowsAsync<DatabaseException>(() => _doctorService.CreateDoctorAsync(doctorRequest));
        await _transactionManager.Received(1)
            .RollbackAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task UpdateDoctorAsync_Should_Return_Updated_Doctor()
    {
        // Arrange
        var doctorId = Guid.NewGuid();
        var doctorRequest = new RequestDoctorDto
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
            Specialization = "General Practitioner",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };

        var addressResponse = new AddressDto
        {
            Id = 1,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };

        var doctorResponse = new RespondDoctorDto
        {
            Id = Guid.NewGuid(),
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
            Specialization = "General Practitioner",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };

        _mediator.Send(Arg.Any<GetAddressIfExistsQuery>()).Returns(addressResponse);
        _mediator.Send(Arg.Any<UpdateDoctorCommand>()).Returns(doctorResponse);

        // Act
        var result = await _doctorService.UpdateDoctorAsync(doctorId, doctorRequest);

        // Assert
        result.Should().BeEquivalentTo(doctorResponse);
        await _transactionManager.Received(1)
            .CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task UpdateDoctorAsync_Should_Rollback_Transaction_On_Exception()
    {
        // Arrange
        var doctorRequest = new RequestDoctorDto
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
            Specialization = "General Practitioner",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };

        _mediator.Send(Arg.Any<GetAddressIfExistsQuery>()).Throws<Exception>();

        // Act
        Assert.ThrowsAsync<DatabaseException>(() =>
            _doctorService.UpdateDoctorAsync(Guid.NewGuid(), doctorRequest));

        // Assert
        await _transactionManager.Received(1).BeginTransactionAsync();
        var transaction = _transactionManager.Received().BeginTransactionAsync().Result;
        await transaction.Received(1).RollbackAsync(Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task DeleteDoctorAsync_Should_Delete_Doctor()
    {
        // Arrange
        var doctorId = Guid.NewGuid();

        // Act
        await _doctorService.DeleteDoctorAsync(doctorId);

        // Assert
        await _mediator.Received(1).Send(Arg.Any<DeleteDoctorCommand>(), Arg.Any<CancellationToken>());
        await _transactionManager.Received(1)
            .CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task DeleteDoctorAsync_Should_Rollback_Transaction_On_Exception()
    {
        // Arrange
        var doctorId = Guid.NewGuid();

        _mediator.Send(Arg.Any<DeleteDoctorCommand>()).Throws<Exception>();

        // Act and Assert
        Assert.ThrowsAsync<DatabaseException>(() => _doctorService.DeleteDoctorAsync(doctorId));
        await _transactionManager.DidNotReceive().RollbackAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
    }

    [Test]
    public async Task GetDoctorsAsync_Should_Return_Doctors()
    {
        // Arrange
        var doctorsResponse = new List<RespondDoctorDto>
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
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "CA",
                    Zip = "12345"
                },
                Specialization = "General Practitioner",
                ExperienceInYears = 10,
                Education = "Medical School",
                RoomNumber = "123"
            },
            new()
            {
                Id = Guid.NewGuid(),
                FullName = "Jane Doe",
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
                Specialization = "General Practitioner",
                ExperienceInYears = 10,
                Education = "Medical School",
                RoomNumber = "123"
            }
        };

        _mediator.Send(Arg.Any<GetAllDoctorsQuery>()).Returns(doctorsResponse);

        // Act
        var result = await _doctorService.GetDoctorsAsync();

        // Assert
        result.Should().BeEquivalentTo(doctorsResponse);
    }

    [Test]
    public void GetDoctorsAsync_Should_Throw_Exception_On_Error()
    {
        // Arrange
        _mediator.Send(Arg.Any<GetAllDoctorsQuery>()).Throws<Exception>();

        // Act and Assert
        Assert.ThrowsAsync<DatabaseException>(() => _doctorService.GetDoctorsAsync());
    }

    [Test]
    public async Task GetDoctorByIdAsync_Should_Return_Doctor()
    {
        // Arrange
        var doctorId = Guid.NewGuid();
        var addressResponse = new AddressDto
        {
            Id = 1,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };
        
        var doctorResponse = new RespondDoctorDto
        {
            Id = Guid.NewGuid(),
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
            Specialization = "General Practitioner",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };

        _mediator.Send(Arg.Any<GetDoctorByIdQuery>()).Returns(doctorResponse);
        _mediator.Send(Arg.Any<GetAddressByDoctorIdQuery>()).Returns(addressResponse);

        // Act
        var result = await _doctorService.GetDoctorByIdAsync(doctorId);

        // Assert
        result.Should().BeEquivalentTo(doctorResponse);
    }

    [Test]
    public void GetDoctorByIdAsync_Should_Throw_Exception_On_Error()
    {
        // Arrange
        var doctorId = Guid.NewGuid();

        _mediator.Send(Arg.Any<GetDoctorByIdQuery>()).Throws<Exception>();

        // Act and Assert
        Assert.ThrowsAsync<DatabaseException>(() => _doctorService.GetDoctorByIdAsync(doctorId));
    }
    
    [Test]
    public async Task GetDoctorWithAddressByIdAsync_Should_Return_Doctor_With_Address()
    {
        // Arrange
        var doctorId = Guid.NewGuid();

        var doctorResponse = new RespondDoctorDto
        {
            Id = Guid.NewGuid(),
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
            Specialization = "General Practitioner",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };

        _mediator.Send(Arg.Any<GetDoctorByIdWithAddressQuery>()).Returns(doctorResponse);

        // Act
        var result = await _doctorService.GetDoctorWithAddressByIdAsync(doctorId);

        // Assert
        result.Should().BeEquivalentTo(doctorResponse);
    }

    [Test]
    public void GetDoctorWithAddressByIdAsync_Should_Throw_Exception_On_Error()
    {
        // Arrange
        var doctorId = Guid.NewGuid();

        _mediator.Send(Arg.Any<GetDoctorByIdWithAddressQuery>()).Throws<Exception>();

        // Act and Assert
        Assert.ThrowsAsync<DatabaseException>(() => _doctorService.GetDoctorWithAddressByIdAsync(doctorId));
    }
}