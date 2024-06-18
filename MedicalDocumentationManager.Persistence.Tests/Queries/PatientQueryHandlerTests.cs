using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Queries.Patient;

namespace MedicalDocumentationManager.Persistence.Tests.Queries;

[TestFixture]
public class PatientQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    private readonly PatientEntity _seedDataPatient1 = new()
    {
        Id = Guid.NewGuid(),
        FullName = "Test Patient 1",
        PhoneNumber = "623-456-7890",
        Email = "test1@example.com",
        InsurancePolicyNumber = "622785605",
        InsuranceProvider = "Health Net",
        AddressEntity = new AddressEntity
        {
            Id = int.MaxValue,
            Street = "Test Street",
            City = "Test City",
            State = "Test State",
            Zip = "12345",
        }
    };

    private readonly PatientEntity _seedDataPatient2 = new()
    {
        Id = Guid.NewGuid(),
        FullName = "Test Patient 2",
        PhoneNumber = "723-456-7890",
        Email = "test2@example.com",
        InsurancePolicyNumber = "252785605",
        InsuranceProvider = "Health Net",
        AddressId = int.MaxValue
    };

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext();

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AddressMappingProfile());
            cfg.AddProfile(new PatientMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    private void SeedData()
    {
        _context.PatientEntities.Add(_seedDataPatient1);
        _context.PatientEntities.Add(_seedDataPatient2);
        _context.AddressEntities.Add(_seedDataPatient1.AddressEntity);
        _context.SaveChanges();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    [Test]
    public async Task Handle_GetAllPatientsQuery_ReturnsEmptyList_WhenNoRecordsExist()
    {
        // Arrange
        var handler = new GetAllPatientsQueryHandler(_context, _mapper);
        var query = new GetAllPatientsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondPatientDtos = result as RespondPatientDto[] ?? result.ToArray();
        respondPatientDtos.Should().NotBeNull();
        respondPatientDtos.Should().BeEmpty();
    }

    [Test]
    public async Task Handle_GetAllPatientsQuery_ReturnsListOfRespondDoctorDtos()
    {
        // Arrange
        var handler = new GetAllPatientsQueryHandler(_context, _mapper);
        var query = new GetAllPatientsQuery();

        // Act
        SeedData();
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondPatientDtos = result as RespondPatientDto[] ?? result.ToArray();
        respondPatientDtos.Should().NotBeNull();
        respondPatientDtos.Should().HaveCount(2);

        var patient1 = respondPatientDtos.FirstOrDefault(d => d.Id == _seedDataPatient1.Id);
        patient1.Should().NotBeNull();
        patient1.FullName.Should().Be(_seedDataPatient1.FullName);
        patient1.PhoneNumber.Should().Be(_seedDataPatient1.PhoneNumber);
        patient1.Email.Should().Be(_seedDataPatient1.Email);
        patient1.InsurancePolicyNumber.Should().Be(_seedDataPatient1.InsurancePolicyNumber);
        patient1.InsuranceProvider.Should().Be(_seedDataPatient1.InsuranceProvider);

        var patient2 = respondPatientDtos.FirstOrDefault(d => d.Id == _seedDataPatient2.Id);
        patient2.Should().NotBeNull();
        patient2.FullName.Should().Be(_seedDataPatient2.FullName);
        patient2.PhoneNumber.Should().Be(_seedDataPatient2.PhoneNumber);
        patient2.Email.Should().Be(_seedDataPatient2.Email);
        patient2.InsurancePolicyNumber.Should().Be(_seedDataPatient2.InsurancePolicyNumber);
        patient2.InsuranceProvider.Should().Be(_seedDataPatient2.InsuranceProvider);
        patient2.AddressId.Should().Be(int.MaxValue);
    }

    [Test]
    public async Task Handle_GetPatientByIdQuery_ReturnsRespondDoctorDto_WhenDoctorExists()
    {
        // Arrange
        var handler = new GetPatientByIdQueryHandler(_context, _mapper);
        var query = new GetPatientByIdQuery(_seedDataPatient1.Id);

        // Act
        SeedData();
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_seedDataPatient1.Id);
        result.FullName.Should().Be(_seedDataPatient1.FullName);
        result.PhoneNumber.Should().Be(_seedDataPatient1.PhoneNumber);
        result.Email.Should().Be(_seedDataPatient1.Email);
        result.InsurancePolicyNumber.Should().Be(_seedDataPatient1.InsurancePolicyNumber);
        result.InsuranceProvider.Should().Be(_seedDataPatient1.InsuranceProvider);
    }

    [Test]
    public async Task Handle_ReturnsNull_WhenDoctorDoesNotExist()
    {
        // Arrange
        var handler = new GetPatientByIdQueryHandler(_context, _mapper);
        var query = new GetPatientByIdQuery(Guid.NewGuid());

        // Act
        SeedData();
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
    
    [Test]
    public async Task Handle_GetPatientByIdWithAddressQuery_ReturnsRespondPatientDto_WithAddress()
    {
        // Arrange
        var handler = new GetPatientByIdWithAddressQueryHandler(_context, _mapper);
        var query = new GetPatientByIdWithAddressQuery(_seedDataPatient1.Id);
        SeedData();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_seedDataPatient1.Id);
        result.FullName.Should().Be(_seedDataPatient1.FullName);
        result.PhoneNumber.Should().Be(_seedDataPatient1.PhoneNumber);
        result.Email.Should().Be(_seedDataPatient1.Email);
        result.InsurancePolicyNumber.Should().Be(_seedDataPatient1.InsurancePolicyNumber);
        result.InsuranceProvider.Should().Be(_seedDataPatient1.InsuranceProvider);
        result.Address.Should().NotBeNull();
        result.Address.City.Should().Be(_seedDataPatient1.AddressEntity.City);
        result.Address.State.Should().Be(_seedDataPatient1.AddressEntity.State);
    }

    [Test]
    public async Task Handle_ReturnsNull_WhenPatientDoesNotExist()
    {
        // Arrange
        var handler = new GetPatientByIdWithAddressQueryHandler(_context, _mapper);
        var query = new GetPatientByIdWithAddressQuery(Guid.NewGuid());

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
}