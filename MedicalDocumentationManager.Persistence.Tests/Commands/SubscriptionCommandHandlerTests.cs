using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.Persistence.Commands.Subscription;

namespace MedicalDocumentationManager.Persistence.Tests.Commands;

[TestFixture]
public class SubscriptionCommandHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;
    private static readonly Guid PatientId = Guid.NewGuid();

    private static readonly SubscriptionEntity SeedDataSubscription1 = new()
    {
        Id = 112,
        SubscriptionType = "Notifier",
        PatientEntity = new PatientEntity
        {
            Id = PatientId,
            FullName = "Test Patient 1",
            PhoneNumber = "623-456-7890",
            Email = "test1@example.com",
            InsurancePolicyNumber = "622785605",
            InsuranceProvider = "Health Net"
        },
        MedicalRecordEntity = new MedicalRecordEntity
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
            PatientId = PatientId
        }
    };

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext(Array.Empty<string>());

        var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new SubscriptionMappingProfile()); });

        _mapper = mapperConfig.CreateMapper();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    [Test]
    public async Task
        Handle_CreateSubscriptionCommand_ReturnsRespondSubscriptionDto_WhenSubscriptionIsCreatedSuccessfully()
    {
        // Arrange
        var handler = new CreateSubscriptionCommandHandler(_context, _mapper);
        var command = new CreateSubscriptionCommand(new SubscriptionDto
        {
            SubscriptionType = SeedDataSubscription1.SubscriptionType,
            PatientId = SeedDataSubscription1.PatientEntity.Id,
            MedicalRecordId = SeedDataSubscription1.MedicalRecordEntity.Id
        });

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.SubscriptionType.Should().Be(command.SubscriptionDto.SubscriptionType);
        result.PatientId.Should().Be(command.SubscriptionDto.PatientId);
        result.MedicalRecordId.Should().Be(command.SubscriptionDto.MedicalRecordId);
    }

    [Test]
    public void Handle_CreateSubscriptionCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new CreateSubscriptionCommandHandler(_context, _mapper);

        // Act
        Func<Task> act = async () => await handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_CreateSubscriptionCommand_ThrowsArgumentNullException_WhenRequestSubscriptionDtoIsNull()
    {
        // Arrange
        var handler = new CreateSubscriptionCommandHandler(_context, _mapper);
        var command = new CreateSubscriptionCommand(null!);

        // Act
        Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Constructor_DeleteSubscriptionCommandHandler_ThrowsArgumentNullException_WhenContextIsNull()
    {
        // Act
        var act = () => new DeleteSubscriptionCommandHandler(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public async Task Handle_DeleteSubscriptionCommand_RemovesSubscriptionEntity_WhenSubscriptionExists()
    {
        // Arrange
        var subscriptionEntity = SeedDataSubscription1;
        _context.SubscriptionEntities.Add(subscriptionEntity);
        await _context.SaveChangesAsync();

        var command = new DeleteSubscriptionCommand(subscriptionEntity.Id);
        var handler = new DeleteSubscriptionCommandHandler(_context);

        // Act
        await handler.Handle(command, CancellationToken.None);
        await _context.SaveChangesAsync();

        // Assert
        var removedSubscription = await _context.SubscriptionEntities.FindAsync(subscriptionEntity.Id);
        removedSubscription.Should().BeNull();
    }

    [Test]
    public void Handle_DeleteSubscriptionCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        //Arrange
        var handler = new DeleteSubscriptionCommandHandler(_context);

        // Act
        var act = async () => await handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task Handle_DeleteSubscriptionCommand_DoesNotThrowException_WhenSubscriptionDoesNotExist()
    {
        // Arrange
        var command = new DeleteSubscriptionCommand(1);
        var handler = new DeleteSubscriptionCommandHandler(_context);

        // Act
        var act = async () => await handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().NotThrowAsync();
    }

    [Test]
    public async Task Handle_UpdateSubscriptionCommand_ReturnsRespondSubscriptionDto_WhenSubscriptionIsUpdatedSuccessfully()
    {
        // Arrange
        var handler = new UpdateSubscriptionCommandHandler(_context, _mapper);
        var createCommand = new CreateSubscriptionCommand(new SubscriptionDto
        {
            SubscriptionType = SeedDataSubscription1.SubscriptionType,
            PatientId = SeedDataSubscription1.PatientEntity.Id,
            MedicalRecordId = SeedDataSubscription1.MedicalRecordEntity.Id
        });
        var createdSubscription = await new CreateSubscriptionCommandHandler(_context, _mapper).Handle(createCommand, CancellationToken.None);
        await _context.SaveChangesAsync();
        
        var updateCommand = new UpdateSubscriptionCommand(createdSubscription.Id, new SubscriptionDto
        {
            SubscriptionType = "Updated Notifier",
            PatientId = createdSubscription.PatientId,
            MedicalRecordId = createdSubscription.MedicalRecordId
        });

        // Act
        var result = await handler.Handle(updateCommand);

        // Assert
        result.Should().NotBeNull();
        result.SubscriptionType.Should().Be(updateCommand.SubscriptionDto.SubscriptionType);
        result.PatientId.Should().Be(updateCommand.SubscriptionDto.PatientId);
        result.MedicalRecordId.Should().Be(updateCommand.SubscriptionDto.MedicalRecordId);
    }

    [Test]
    public void Handle_UpdateSubscriptionCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new UpdateSubscriptionCommandHandler(_context, _mapper);

        // Act
        Func<Task<SubscriptionDto>> act = async () => await handler.Handle(null!);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_UpdateSubscriptionCommand_ThrowsArgumentNullException_WhenRequestSubscriptionDtoIsNull()
    {
        // Arrange
        var handler = new UpdateSubscriptionCommandHandler(_context, _mapper);
        var command = new UpdateSubscriptionCommand(1, null!);

        // Act
        Func<Task<SubscriptionDto>> act = async () => await handler.Handle(command);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Constructor_UpdateSubscriptionCommandHandler_ThrowsArgumentNullException_WhenContextIsNull()
    {
        // Act
        var act = () => new UpdateSubscriptionCommandHandler(null!, _mapper);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenMapperIsNull()
    {
        // Act
        var act = () => new UpdateSubscriptionCommandHandler(_context, null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
}