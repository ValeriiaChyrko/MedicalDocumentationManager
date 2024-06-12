using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.Persistence.Queries.Address;

namespace MedicalDocumentationManager.Persistence.Tests;

[TestFixture]
public class AddressQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    private readonly long _addressId = 1;
    private readonly Guid _doctorId = Guid.NewGuid();
    private readonly Guid _patientId = Guid.NewGuid();

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

        _context.AddressEntities.Add(new AddressEntity
        {
            Id = _addressId,
            Street = "Test Street",
            City = "Test City",
            State = "Test State",
            Zip = "12345",
            Doctors = new List<DoctorEntity>
            {
                new DoctorEntity
                {
                    Id = _doctorId,
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
                    Id = _patientId,
                    FullName = "Test Patient",
                    PhoneNumber = "123-456-7890",
                    Email = "test@example.com",
                    InsurancePolicyNumber = "222785605",
                    InsuranceProvider = "Health Net"
                }
            }
        });
    
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
        var query = new GetAddressIfExistsQuery(new RequestAddressDto
        {
            Street = "Test Street",
            City = "Test City",
            State = "Test State",
            Zip = "12345"
        });

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_addressId);
        result.Street.Should().Be("Test Street");
        result.City.Should().Be("Test City");
        result.State.Should().Be("Test State");
        result.Zip.Should().Be("12345");
    }

    [Test]
    public async Task Handle_GetAddressIfExistsQuery_ReturnsNull_WhenAddressDoesNotExist()
    {
        // Arrange
        var handler = new GetAllAddressesQueryHandler(_context, _mapper);
        var query = new GetAddressIfExistsQuery(new RequestAddressDto
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
        var query = new GetAddressByIdQuery(_addressId);

        // Act
        var handler = new GetAddressByIdQueryHandler(_context, _mapper);
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_addressId);
        result.Street.Should().Be("Test Street");
        result.City.Should().Be("Test City");
        result.State.Should().Be("Test State");
        result.Zip.Should().Be("12345");
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
        var query = new GetAddressByDoctorIdQuery(_doctorId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_addressId);
        result.Street.Should().Be("Test Street");
        result.City.Should().Be("Test City");
        result.State.Should().Be("Test State");
        result.Zip.Should().Be("12345");
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
        var query = new GetAddressByPatientIdQuery(_patientId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_addressId);
        result.Street.Should().Be("Test Street");
        result.City.Should().Be("Test City");
        result.State.Should().Be("Test State");
        result.Zip.Should().Be("12345");
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