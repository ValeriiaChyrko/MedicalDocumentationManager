using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.Persistence.Commands.Address;

namespace MedicalDocumentationManager.Persistence.Tests.Commands;

[TestFixture]
public class AddressCommandHandlerTests
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
            cfg.AddProfile(new AddressMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    [Test]
    public async Task Handle_CreateAddressCommand_ReturnsRespondAddressDto_WhenAddressIsCreatedSuccessfully()
    {
        // Arrange
        var handler = new CreateAddressCommandHandler(_context, _mapper);
        var command = new CreateAddressCommand
        (
            new AddressDto
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                Zip = "12345"
            }
        );

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Street.Should().Be(command.AddressDto.Street);
        result.City.Should().Be(command.AddressDto.City);
        result.State.Should().Be(command.AddressDto.State);
        result.Zip.Should().Be(command.AddressDto.Zip);
    }

    [Test]
    public void Handle_CreateAddressCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new CreateAddressCommandHandler(_context, _mapper);

        // Act
        Func<Task> act = async () => await handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_CreateAddressCommand_ThrowsArgumentNullException_WhenRequestAddressDtoIsNull()
    {
        // Arrange
        var handler = new CreateAddressCommandHandler(_context, _mapper);
        var command = new CreateAddressCommand(null!);

        // Act
        Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task Handle_DeleteAddressCommand_RemovesAddressEntity_WhenAddressExists()
    {
        // Arrange
        var addressEntity = new AddressEntity
        {
            Id = int.MaxValue,
            Street = "Test Street",
            City = "Test City",
            State = "Test State",
            Zip = "12345"
        };

        _context.AddressEntities.Add(addressEntity);
        await _context.SaveChangesAsync();

        var handler = new DeleteAddressCommandHandler(_context);
        var command = new DeleteAddressCommand(addressEntity.Id);

        // Act
        await handler.Handle(command, CancellationToken.None);
        await _context.SaveChangesAsync();

        // Assert
        var address = await _context.AddressEntities.FindAsync(addressEntity.Id);
        address.Should().BeNull();
    }

    [Test]
    public void Handle_DeleteAddressCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new DeleteAddressCommandHandler(_context);

        // Act
        Func<Task> act = async () => await handler.Handle(null!, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public async Task Handle_UpdateAddressCommand_ReturnsRespondAddressDto_WhenAddressIsUpdatedSuccessfully()
    {
        // Arrange
        var handlerCreate = new CreateAddressCommandHandler(_context, _mapper);
        var commandCreate = new CreateAddressCommand
        (
            new AddressDto
            {
                Street = "123 Main St",
                City = "Oldtown",
                State = "CA",
                Zip = "12345"
            }
        );

        var resultCreate = await handlerCreate.Handle(commandCreate, CancellationToken.None);
        await _context.SaveChangesAsync();
        _context.DetachEntitiesInChangeTracker();

        var handlerUpdate = new UpdateAddressCommandHandler(_context, _mapper);
        var commandUpdate = new UpdateAddressCommand
        (
            resultCreate.Id,
            new AddressDto
            {
                Street = "456 Main St",
                City = "Newtown",
                State = "TX",
                Zip = "67890"
            }
        );

        // Act
        var result = await handlerUpdate.Handle(commandUpdate);

        // Assert
        result.Should().NotBeNull();
        result.Street.Should().Be(commandUpdate.AddressDto.Street);
        result.City.Should().Be(commandUpdate.AddressDto.City);
        result.State.Should().Be(commandUpdate.AddressDto.State);
        result.Zip.Should().Be(commandUpdate.AddressDto.Zip);
    }

    [Test]
    public void Handle_UpdateAddressCommand_ThrowsArgumentNullException_WhenCommandIsNull()
    {
        // Arrange
        var handler = new UpdateAddressCommandHandler(_context, _mapper);

        // Act
        Func<Task> act = async () => await handler.Handle(null!);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Test]
    public void Handle_UpdateAddressCommand_ThrowsArgumentNullException_WhenRequestAddressDtoIsNull()
    {
        // Arrange
        var handler = new UpdateAddressCommandHandler(_context, _mapper);
        var command = new UpdateAddressCommand(int.MaxValue, null!);

        // Act
        Func<Task> act = async () => await handler.Handle(command);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }
}