using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.Persistence.Queries.Address;

namespace MedicalDocumentationManager.Persistence.Tests.Queries;

[TestFixture]
public class AddressQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    private readonly AddressEntity _seedDataAddress = new AddressEntity
    {
        Id = int.MaxValue,
        Street = "Test Street",
        City = "Test City",
        State = "Test State",
        Zip = "12345",
        Doctors = new List<DoctorEntity>
        {
            new DoctorEntity
            {
                Id = Guid.NewGuid(),
                FullName = "Test Doctor",
                PhoneNumber = "123-456-7890",
                Email = "test@example.com",
                Specialization = "Test Specialization",
                ExperienceInYears = 5,
                Education = "Test Education",
                RoomNumber = "101"
            }
        },
        Patients = new List<PatientEntity>
        {
            new PatientEntity
            {
                Id = Guid.NewGuid(),
                FullName = "Test Patient",
                PhoneNumber = "123-456-7890",
                Email = "test@example.com",
                InsurancePolicyNumber = "222785605",
                InsuranceProvider = "Health Net"
            }
        }
    };

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext(Array.Empty<string>());
        
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AddressMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();

        _context.AddressEntities.Add(_seedDataAddress);
        _context.SaveChanges();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }
    
    [Test]
    public async Task Handle_GetAllAddressesQuery_ReturnsAddressDto_WhenAddressExists()
    {
        // Arrange
        var handler = new GetAllAddressesQueryHandler(_context, _mapper);
        var query = new GetAddressIfExistsQuery(new AddressDto
        {
            Street = _seedDataAddress.Street,
            City = _seedDataAddress.City,
            State = _seedDataAddress.State,
            Zip = _seedDataAddress.Zip
        });

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_seedDataAddress.Id);
        result.Street.Should().Be(_seedDataAddress.Street);
        result.City.Should().Be(_seedDataAddress.City);
        result.State.Should().Be(_seedDataAddress.State);
        result.Zip.Should().Be(_seedDataAddress.Zip);
    }

    [Test]
    public async Task Handle_GetAddressIfExistsQuery_ReturnsNull_WhenAddressDoesNotExist()
    {
        // Arrange
        var handler = new GetAllAddressesQueryHandler(_context, _mapper);
        var query = new GetAddressIfExistsQuery(new AddressDto
        {
            Street = "Non-Existing Street",
            City = "Non-Existing City",
            State = "Non-Existing State",
            Zip = "123456"
        });

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
    
    [Test]
    public async Task Handle_GetAddressByIdQuery_ReturnsAddressDto_WhenAddressExists()
    {
        // Arrange
        var query = new GetAddressByIdQuery(_seedDataAddress.Id);

        // Act
        var handler = new GetAddressByIdQueryHandler(_context, _mapper);
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_seedDataAddress.Id);
        result.Street.Should().Be(_seedDataAddress.Street);
        result.City.Should().Be(_seedDataAddress.City);
        result.State.Should().Be(_seedDataAddress.State);
        result.Zip.Should().Be(_seedDataAddress.Zip);
    }

    [Test]
    public async Task Handle_GetAddressByIdQuery_ReturnsNull_WhenAddressDoesNotExist()
    {
        // Arrange
        var query = new GetAddressByIdQuery(2);

        // Act
        var handler = new GetAddressByIdQueryHandler(_context, _mapper);
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
    
    [Test]
    public async Task Handle_GetAddressByDoctorIdQuery_ReturnsAddressDto_WhenAddressExists()
    {
        // Arrange
        var handler = new GetAddressByDoctorIdQueryHandler(_context, _mapper);
        var query = new GetAddressByDoctorIdQuery(_seedDataAddress.Doctors!.First().Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_seedDataAddress.Id);
        result.Street.Should().Be(_seedDataAddress.Street);
        result.City.Should().Be(_seedDataAddress.City);
        result.State.Should().Be(_seedDataAddress.State);
        result.Zip.Should().Be(_seedDataAddress.Zip);
    }

    [Test]
    public async Task Handle_GetAddressByDoctorIdQuery_ReturnsNull_WhenAddressDoesNotExist()
    {
        // Arrange
        var handler = new GetAddressByDoctorIdQueryHandler(_context, _mapper);
        var query = new GetAddressByDoctorIdQuery(Guid.NewGuid());

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
    
    [Test]
    public async Task Handle_ReturnsAddressDto_WhenAddressExists()
    {
        // Arrange
        var handler = new GetAddressByPatientIdQueryHandler(_context, _mapper);
        var query = new GetAddressByPatientIdQuery(_seedDataAddress.Patients!.First().Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_seedDataAddress.Id);
        result.Street.Should().Be(_seedDataAddress.Street);
        result.City.Should().Be(_seedDataAddress.City);
        result.State.Should().Be(_seedDataAddress.State);
        result.Zip.Should().Be(_seedDataAddress.Zip);
    }

    [Test]
    public async Task Handle_ReturnsNull_WhenAddressDoesNotExist()
    {
        // Arrange
        var handler = new GetAddressByPatientIdQueryHandler(_context, _mapper);
        var query = new GetAddressByPatientIdQuery(Guid.NewGuid());

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
}