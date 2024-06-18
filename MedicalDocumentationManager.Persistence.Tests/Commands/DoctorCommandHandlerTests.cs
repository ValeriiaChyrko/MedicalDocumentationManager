using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.Persistence.Commands.Doctor;

namespace MedicalDocumentationManager.Persistence.Tests.Commands;

[TestFixture]
public class DoctorCommandHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext();
            
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DoctorMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }
    
    [Test]
    public async Task Handle_CreateDoctorCommand_ReturnsRespondDoctorDto_WhenDoctorIsCreatedSuccessfully()
    {
        // Arrange
        var handler = new CreateDoctorCommandHandler(_context, _mapper);
        var command = new CreateDoctorCommand
        (
            new RequestDoctorDto
            {
                FullName = "Test Doctor 1",
                BirthDate = new DateOnly(199, 10, 01),
                PhoneNumber = "123-456-7890",
                Email = "test1@example.com",
                Specialization = "Test Specialization",
                ExperienceInYears = 5,
                Education = "Test Education",
                RoomNumber = "101",
                Address = null!
            },
            0
        );

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(command.RequestDoctorDto);
    }

    [Test]
    public void Handle_CreateDoctorCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new CreateDoctorCommandHandler(_context, _mapper);
            
        // Act
        Func<Task> act = async () => await handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_CreateDoctorCommand_ThrowsArgumentNullException_WhenRequestDoctorDtoIsNull()
    {
        // Arrange
        var handler = new CreateDoctorCommandHandler(_context, _mapper);
        var command = new CreateDoctorCommand(null!, 0);
            
        // Act
        Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }
        
    [Test]
    public async Task Handle_DeleteDoctorCommand_WhenDoctorExists()
    {
        // Arrange
        var handler = new DeleteDoctorCommandHandler(_context);
        var doctorEntity = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            FullName = "Test Doctor 1",
            PhoneNumber = "123-456-7890",
            Email = "test1@example.com",
            Specialization = "Test Specialization",
            ExperienceInYears = 5,
            Education = "Test Education",
            RoomNumber = "101"
        };
            
        _context.DoctorEntities.Add(doctorEntity);
        await _context.SaveChangesAsync();

        var command = new DeleteDoctorCommand(doctorEntity.Id);

        // Act
        await handler.Handle(command, CancellationToken.None);
        await _context.SaveChangesAsync();

        // Assert
        var deletedDoctors = await _context.DoctorEntities.FindAsync(doctorEntity.Id);
        deletedDoctors.Should().BeNull();
    }

    [Test]
    public void Handle_WithNullCommand_ThrowsArgumentNullException()
    {
        // Arrange
        var dbContext = Substitute.For<IMedicalDocumentationManagerDbContext>();
        var handler = new DeleteDoctorCommandHandler(dbContext);

        // Act
        var act = async () => await handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }
        
    [Test]
    public async Task Handle_UpdateDoctorCommand_ReturnsRespondDoctorDto_WhenDoctorIsUpdatedSuccessfully()
    {
        // Arrange
        var handlerCreate = new CreateDoctorCommandHandler(_context, _mapper);
        var commandCreate = new CreateDoctorCommand
        (
            new RequestDoctorDto
            {
                FullName = "Old Doctor",
                PhoneNumber = "987-654-3210",
                Email = "old@example.com",
                Specialization = "Old Specialization",
                ExperienceInYears = 5,
                Education = "Old Education",
                RoomNumber = "101",
                Address = null!
            },
            0
        );
            
        var resultCreate = await handlerCreate.Handle(commandCreate, CancellationToken.None);
        await _context.SaveChangesAsync();
        _context.DetachEntitiesInChangeTracker();
            
        var handlerUpdate = new UpdateDoctorCommandHandler(_context, _mapper);
        var commandUpdate = new UpdateDoctorCommand
        (
            resultCreate.Id,
            new RequestDoctorDto
            {
                FullName = "Updated Doctor",
                PhoneNumber = "123-456-7890",
                Email = "updated@example.com",
                Specialization = "Updated Specialization",
                ExperienceInYears = 10,
                Education = "Updated Education",
                RoomNumber = "202",
                Address = null!
            },
            0
        );

        // Act
        var result = await handlerUpdate.Handle(commandUpdate);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(commandUpdate.RequestDoctorDto);
    }

    [Test]
    public void Handle_UpdateDoctorCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new UpdateDoctorCommandHandler(_context, _mapper);
            
        // Act
        var act = async () => await handler.Handle(null!);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_UpdateDoctorCommand_ThrowsArgumentNullException_WhenRequestDoctorDtoIsNull()
    {
        // Arrange
        var handler = new UpdateDoctorCommandHandler(_context, _mapper);
        var command = new UpdateDoctorCommand(Guid.NewGuid(), null!, 0);

        // Act
        var act = async () => await handler.Handle(command);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }
}