using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Queries.Patient;

namespace MedicalDocumentationManager.Persistence.Tests;

[TestFixture]
public class PatientQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;
    
    private readonly Guid _patientId = Guid.NewGuid();
    private readonly Guid _patientId2 = Guid.NewGuid();

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

    private void SeedData()
    {
        _context.PatientEntities.Add(
            new PatientEntity
            {
                Id = _patientId,
                FullName = "Test Patient 1",
                PhoneNumber = "623-456-7890",
                Email = "test1@example.com",
                InsurancePolicyNumber = "622785605",
                InsuranceProvider = "Health Net"
            });
        
        _context.PatientEntities.Add(
            new PatientEntity
            {
                Id = _patientId2,
                FullName = "Test Patient 2",
                PhoneNumber = "723-456-7890",
                Email = "test2@example.com",
                InsurancePolicyNumber = "252785605",
                InsuranceProvider = "Health Net"
            });
    
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
        // Assert
        var respondPatientDtos = result as RespondPatientDto[] ?? result.ToArray();
        respondPatientDtos.Should().NotBeNull();
        respondPatientDtos.Should().HaveCount(2);

        var patient1 = respondPatientDtos.FirstOrDefault(d => d.Id == _patientId);
        patient1.Should().NotBeNull();
        patient1.FullName.Should().Be("Test Patient 1");
        patient1.PhoneNumber.Should().Be("623-456-7890");
        patient1.Email.Should().Be("test1@example.com");
        patient1.InsurancePolicyNumber.Should().Be("622785605");
        patient1.InsuranceProvider.Should().Be("Health Net");

        var patient2 = respondPatientDtos.FirstOrDefault(d => d.Id == _patientId2);
        patient2.Should().NotBeNull();
        patient2.FullName.Should().Be("Test Patient 2");
        patient2.PhoneNumber.Should().Be("723-456-7890");
        patient2.Email.Should().Be("test2@example.com");
        patient2.InsurancePolicyNumber.Should().Be("252785605");
        patient2.InsuranceProvider.Should().Be("Health Net");
    }
    
    [Test]
    public async Task Handle_GetPatientByIdQuery_ReturnsRespondDoctorDto_WhenDoctorExists()
    {
        // Arrange
        var handler = new GetPatientByIdQueryHandler(_context, _mapper);
        var query = new GetPatientByIdQuery(_patientId);

        // Act
        SeedData();
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_patientId);
        result.FullName.Should().Be("Test Patient 1");
        result.PhoneNumber.Should().Be("623-456-7890");
        result.Email.Should().Be("test1@example.com");
        result.InsurancePolicyNumber.Should().Be("622785605");
        result.InsuranceProvider.Should().Be("Health Net");
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
}