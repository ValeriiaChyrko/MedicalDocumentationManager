using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

namespace MedicalDocumentationManager.Persistence.Tests.Commands;

[TestFixture]
public class MedicalRecordCommandHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    private readonly MedicalRecordEntity _seedDataMedicalRecord = new()
    {
        Id = Guid.NewGuid(),
        Record = "Test Record",
        DoctorEntity = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            FullName = "Test Doctor",
            PhoneNumber = "123-456-7890",
            Email = "test@example.com",
            Specialization = "Test Specialization",
            ExperienceInYears = 5,
            Education = "Test Education",
            RoomNumber = "101"
        },
        PatientEntity = new PatientEntity
        {
            Id = Guid.NewGuid(),
            FullName = "Test Patient",
            PhoneNumber = "123-456-7890",
            Email = "test@example.com",
            InsurancePolicyNumber = "222785605",
            InsuranceProvider = "Health Net"
        }
    };

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext(Array.Empty<string>());

        var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MedicalRecordMappingProfile()); });

        _mapper = mapperConfig.CreateMapper();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    [Test]
    public async Task
        Handle_CreateMedicalRecordCommand_ReturnsRespondMedicalRecordDto_WhenMedicalRecordIsCreatedSuccessfully()
    {
        // Arrange
        var handler = new CreateMedicalRecordCommandHandler(_context, _mapper);
        var command = new CreateMedicalRecordCommand(new RequestMedicalRecordDto
        {
            Record = _seedDataMedicalRecord.Record,
            DoctorId = _seedDataMedicalRecord.DoctorEntity.Id,
            PatientId = _seedDataMedicalRecord.PatientEntity.Id
        });

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Record.Should().Be(command.RequestMedicalRecordDto.Record);
        result.DoctorId.Should().Be(command.RequestMedicalRecordDto.DoctorId);
        result.PatientId.Should().Be(command.RequestMedicalRecordDto.PatientId);
    }

    [Test]
    public void Handle_CreateMedicalRecordCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new CreateMedicalRecordCommandHandler(_context, _mapper);

        // Act
        var act = () => handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_CreateMedicalRecordCommand_ThrowsArgumentNullException_WhenRequestMedicalRecordDtoIsNull()
    {
        // Arrange
        var handler = new CreateMedicalRecordCommandHandler(_context, _mapper);
        var command = new CreateMedicalRecordCommand(null!);

        // Act
        var act = () => handler.Handle(command, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Constructor_CreateMedicalRecordCommandHandler_ThrowsArgumentNullException_WhenContextIsNull()
    {
        // Act
        var act = () => new CreateMedicalRecordCommandHandler(null!, _mapper);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_CreateMedicalRecordCommandHandler_ThrowsArgumentNullException_WhenMapperIsNull()
    {
        // Act
        var act = () => new CreateMedicalRecordCommandHandler(_context, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task Handle_DeleteMedicalRecordCommand_RemovesMedicalRecordEntity_WhenEntityIsFound()
    {
        // Arrange
        var handler = new DeleteMedicalRecordCommandHandler(_context);
        var medicalRecordEntity = _seedDataMedicalRecord;
        _context.MedicalRecordEntities.Add(medicalRecordEntity);
        await _context.SaveChangesAsync();

        var command = new DeleteMedicalRecordCommand(medicalRecordEntity.Id);

        // Act
        await handler.Handle(command, CancellationToken.None);
        await _context.SaveChangesAsync();

        // Assert
        var removedEntity =
            await _context.MedicalRecordEntities.FindAsync(medicalRecordEntity.Id, CancellationToken.None);
        removedEntity.Should().BeNull();
    }

    [Test]
    public async Task Handle_DeleteMedicalRecordCommand_DoesNotThrowException_WhenEntityIsNotFound()
    {
        // Arrange
        var handler = new DeleteMedicalRecordCommandHandler(_context);
        var command = new DeleteMedicalRecordCommand(Guid.NewGuid());

        // Act and Assert
        await handler.Handle(command, CancellationToken.None);
    }

    [Test]
    public void Handle_DeleteMedicalRecordCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new DeleteMedicalRecordCommandHandler(_context);

        // Act
        var act = () => handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenContextIsNull()
    {
        // Act
        var act = () => new DeleteMedicalRecordCommandHandler(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task Handle_UpdateMedicalRecordCommand_UpdatesMedicalRecordEntity_WhenCommandIsValid()
    {
        // Arrange
        var handler = new UpdateMedicalRecordCommandHandler(_context, _mapper);
        var createCommand = new CreateMedicalRecordCommand(new RequestMedicalRecordDto
        {
            Record = "Initial Record",
            DoctorId = Guid.NewGuid(),
            PatientId = Guid.NewGuid()
        });
        var createHandler = new CreateMedicalRecordCommandHandler(_context, _mapper);
        var createdMedicalRecord = await createHandler.Handle(createCommand, CancellationToken.None);
        await _context.SaveChangesAsync();

        var updateCommand = new UpdateMedicalRecordCommand(createdMedicalRecord.Id, new RequestMedicalRecordDto
        {
            Record = "Updated Record",
            DoctorId = createdMedicalRecord.DoctorId,
            PatientId = createdMedicalRecord.PatientId
        });

        // Act
        var result = await handler.Handle(updateCommand);

        // Assert
        result.Should().NotBeNull();
        result.Record.Should().Be(updateCommand.RequestMedicalRecordDto.Record);
        result.DoctorId.Should().Be(updateCommand.RequestMedicalRecordDto.DoctorId);
        result.PatientId.Should().Be(updateCommand.RequestMedicalRecordDto.PatientId);

        // Verify the update in the database
        var updatedMedicalRecordEntity = await _context.MedicalRecordEntities.FindAsync(createdMedicalRecord.Id, CancellationToken.None);
        updatedMedicalRecordEntity.Should().NotBeNull();
        updatedMedicalRecordEntity.Record.Should().Be(updateCommand.RequestMedicalRecordDto.Record);
    }

    [Test]
    public void Handle_UpdateMedicalRecordCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new UpdateMedicalRecordCommandHandler(_context, _mapper);

        // Act
        Func<Task<RespondMedicalRecordDto>> act = () => handler.Handle(null!);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_UpdateMedicalRecordCommand_ThrowsArgumentNullException_WhenRequestMedicalRecordDtoIsNull()
    {
        // Arrange
        var handler = new UpdateMedicalRecordCommandHandler(_context, _mapper);
        var command = new UpdateMedicalRecordCommand(Guid.NewGuid(), null!);

        // Act
        Func<Task<RespondMedicalRecordDto>> act = () => handler.Handle(command);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Constructor_UpdateMedicalRecordCommandHandler_ThrowsArgumentNullException_WhenContextIsNull()
    {
        // Act
        var act = () => new UpdateMedicalRecordCommandHandler(null!, _mapper);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_UpdateMedicalRecordCommandHandler_ThrowsArgumentNullException_WhenMapperIsNull()
    {
        // Act
        var act = () => new UpdateMedicalRecordCommandHandler(_context, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}