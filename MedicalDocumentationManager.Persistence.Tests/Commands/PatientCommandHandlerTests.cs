using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Commands.Patient;

namespace MedicalDocumentationManager.Persistence.Tests.Commands;

[TestFixture]
public class PatientCommandHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext(Array.Empty<string>());

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new PatientMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    [Test]
    public async Task Handle_CreatePatientCommand_ReturnsRespondPatientDto_WhenPatientIsCreatedSuccessfully()
    {
        // Arrange
        var handler = new CreatePatientCommandHandler(_context, _mapper);
        var command = new CreatePatientCommand
        (
            new RequestPatientDto
            {
                FullName = "Test Patient 1",
                BirthDate = new DateOnly(1999,
                    1,
                    01),
                PhoneNumber = "623-456-7890",
                Email = "test1@example.com",
                InsurancePolicyNumber = "622785605",
                InsuranceProvider = "Health Net",
                Address = null!
            },
            0
        );

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.FullName.Should().Be(command.RequestPatientDto.FullName);
        result.BirthDate.Should().Be(command.RequestPatientDto.BirthDate);
        result.PhoneNumber.Should().Be(command.RequestPatientDto.PhoneNumber);
        result.Email.Should().Be(command.RequestPatientDto.Email);
        result.InsuranceProvider.Should().Be(command.RequestPatientDto.InsuranceProvider);
        result.InsurancePolicyNumber.Should().Be(command.RequestPatientDto.InsurancePolicyNumber);
    }

    [Test]
    public void Handle_CreatePatientCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new CreatePatientCommandHandler(_context, _mapper);

        // Act
        Func<Task> act = async () => await handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_CreatePatientCommand_ThrowsArgumentNullException_WhenRequestPatientDtoIsNull()
    {
        // Arrange
        var handler = new CreatePatientCommandHandler(_context, _mapper);
        var command = new CreatePatientCommand(null!, 0);

        // Act
        Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }
    
    [Test]
    public async Task Handle_DeletePatientCommand_RemovesPatientEntity_WhenPatientExists()
    {
        // Arrange
        var patientEntity = new PatientEntity
        {
            Id = Guid.NewGuid(),
            FullName = "Test Patient 1",
            BirthDate = new DateOnly(1999, 1, 01),
            PhoneNumber = "623-456-7890",
            Email = "test1@example.com",
            InsurancePolicyNumber = "622785605",
            InsuranceProvider = "Health Net"
        };

        _context.PatientEntities.Add(patientEntity);
        await _context.SaveChangesAsync();

        var handler = new DeletePatientCommandHandler(_context);
        var command = new DeletePatientCommand(patientEntity.Id);

        // Act
        await handler.Handle(command, CancellationToken.None);
        await _context.SaveChangesAsync();

        // Assert
        var patient = await _context.PatientEntities.FindAsync(patientEntity.Id);
        patient.Should().BeNull();
    }

    [Test]
    public void Handle_DeletePatientCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new DeletePatientCommandHandler(_context);

        // Act
        Func<Task> act = async () => await handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }
    
    [Test]
    public async Task Handle_UpdatePatientCommand_ReturnsRespondPatientDto_WhenPatientIsUpdatedSuccessfully()
    {
        // Arrange
        var handler = new CreatePatientCommandHandler(_context, _mapper);
        var createCommand = new CreatePatientCommand
        (
            RequestPatientDto: new RequestPatientDto
            {
                FullName = "Test Patient 1",
                BirthDate = new DateOnly(1999,
                    1,
                    01),
                PhoneNumber = "623-456-7890",
                Email = "test1@example.com",
                InsurancePolicyNumber = "622785605",
                InsuranceProvider = "Health Net",
                Address = null!
            },
            0
        );

        var createdPatient = await handler.Handle(createCommand, CancellationToken.None);

        var updateHandler = new UpdatePatientCommandHandler(_context, _mapper);
        var updateCommand = new UpdatePatientCommand
        (
            createdPatient.Id,
            new RequestPatientDto
            {
                FullName = "Updated Test Patient 1",
                BirthDate = new DateOnly(1999,
                    1,
                    01),
                PhoneNumber = "623-456-7891",
                Email = "updatedtest1@example.com",
                InsurancePolicyNumber = "622785606",
                InsuranceProvider = "Updated Health Net",
                Address = null!
            },
            0
        );

        // Act
        var result = await updateHandler.Handle(updateCommand);

        // Assert
        result.Should().NotBeNull();
        result.FullName.Should().Be(updateCommand.RequestPatientDto.FullName);
        result.BirthDate.Should().Be(updateCommand.RequestPatientDto.BirthDate);
        result.PhoneNumber.Should().Be(updateCommand.RequestPatientDto.PhoneNumber);
        result.Email.Should().Be(updateCommand.RequestPatientDto.Email);
        result.InsuranceProvider.Should().Be(updateCommand.RequestPatientDto.InsuranceProvider);
        result.InsurancePolicyNumber.Should().Be(updateCommand.RequestPatientDto.InsurancePolicyNumber);
    }

    [Test]
    public void Handle_UpdatePatientCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new UpdatePatientCommandHandler(_context, _mapper);

        // Act
        Func<Task<RespondPatientDto>> act = async () => await handler.Handle(null!);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_UpdatePatientCommand_ThrowsArgumentNullException_WhenRequestPatientDtoIsNull()
    {
        // Arrange
        var handler = new UpdatePatientCommandHandler(_context, _mapper);
        var command = new UpdatePatientCommand(Guid.NewGuid(), null!, 0);

        // Act
        Func<Task<RespondPatientDto>> act = async () => await handler.Handle(command);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }
}