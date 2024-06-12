using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

namespace MedicalDocumentationManager.Persistence.Tests;

[TestFixture]
public class MedicalRecordQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;
    
    private readonly Guid _medicalRecordId = Guid.NewGuid();
    private readonly Guid _doctorId = Guid.NewGuid();
    private readonly Guid _patientId = Guid.NewGuid();

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext(Array.Empty<string>());
        
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MedicalRecordMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    private void SeedData()
    {
        _context.MedicalRecordEntities.Add(new MedicalRecordEntity
        {
            Id = _medicalRecordId,
            Record = "Test Record",
            DoctorEntity = new DoctorEntity
            {
                Id = _doctorId,
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
                Id = _patientId,
                FullName = "Test Patient",
                PhoneNumber = "123-456-7890",
                Email = "test@example.com",
                InsurancePolicyNumber = "222785605",
                InsuranceProvider = "Health Net"
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
    public async Task Handle_GetAllMedicalRecordsByDoctorIdQuery_ReturnsRespondDoctorDtos_WhenMedicalRecordsExist()
    {
        // Arrange
        SeedData();
        var handler = new GetAllMedicalRecordsByDoctorIdQueryHandler(_context, _mapper);
        var query = new GetAllMedicalRecordsByDoctorIdQuery(_doctorId );

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondMedicalRecordDtos = result as RespondMedicalRecordDto[] ?? result.ToArray();
        respondMedicalRecordDtos.Should().NotBeNull();
        respondMedicalRecordDtos.Should().HaveCount(1);
        respondMedicalRecordDtos.Should().Contain(dto => dto.DoctorId == _doctorId);
        
        var medicalRecord = respondMedicalRecordDtos.FirstOrDefault(d => d.DoctorId == _doctorId);
        medicalRecord.Should().NotBeNull();
        medicalRecord.Record.Should().Be("Test Record");
        medicalRecord.DoctorId.Should().Be(_doctorId);
        medicalRecord.PatientId.Should().Be(_patientId);
    }

    [Test]
    public async Task Handle_GetAllMedicalRecordsByDoctorIdQuery_ReturnsEmptyList_WhenMedicalRecordsDoNotExist()
    {
        // Arrange
        var handler = new GetAllMedicalRecordsByDoctorIdQueryHandler(_context, _mapper);
        var query = new GetAllMedicalRecordsByDoctorIdQuery(_doctorId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondMedicalRecordDtos = result as RespondMedicalRecordDto[] ?? result.ToArray();
        respondMedicalRecordDtos.Should().NotBeNull();
        respondMedicalRecordDtos.Should().BeEmpty();
    }
    
    [Test]
    public async Task Handle_GetAllMedicalRecordsByPatientIdQuery_ReturnsRespondDoctorDtos_WhenMedicalRecordsExist()
    {
        // Arrange
        SeedData();
        var handler = new GetAllMedicalRecordsByPatientIdQueryHandler(_context, _mapper);
        var query = new GetAllMedicalRecordsByPatientIdQuery(_patientId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondMedicalRecordDtos = result as RespondMedicalRecordDto[] ?? result.ToArray();
        respondMedicalRecordDtos.Should().NotBeNull();
        respondMedicalRecordDtos.Should().HaveCount(1);
        respondMedicalRecordDtos.Should().Contain(dto => dto.PatientId == _patientId);
        
        var medicalRecord = respondMedicalRecordDtos.FirstOrDefault(d => d.PatientId == _patientId);
        medicalRecord.Should().NotBeNull();
        medicalRecord.Record.Should().Be("Test Record");
        medicalRecord.DoctorId.Should().Be(_doctorId);
        medicalRecord.PatientId.Should().Be(_patientId);
    }

    [Test]
    public async Task Handle_GetAllMedicalRecordsByPatientIdQuery_ReturnsEmptyList_WhenMedicalRecordsDoNotExist()
    {
        // Arrange
        SeedData();
        var handler = new GetAllMedicalRecordsByPatientIdQueryHandler(_context, _mapper);
        var query = new GetAllMedicalRecordsByPatientIdQuery(Guid.NewGuid());

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondDoctorDtos = result as RespondMedicalRecordDto[] ?? result.ToArray();
        respondDoctorDtos.Should().NotBeNull();
        respondDoctorDtos.Should().BeEmpty();
    }
    
    [Test]
    public async Task Handle_GetAllMedicalRecordsQuery_ReturnsRespondMedicalRecordDtos_WhenMedicalRecordsExist()
    {
        // Arrange
        SeedData();
        var handler = new GetAllMedicalRecordsQueryHandler(_context, _mapper);
        var query = new GetAllMedicalRecordsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondMedicalRecordDtos = result as RespondMedicalRecordDto[] ?? result.ToArray();
        respondMedicalRecordDtos.Should().NotBeNull();
        respondMedicalRecordDtos.Should().HaveCount(1);
        respondMedicalRecordDtos.Should().Contain(dto => dto.Id == _medicalRecordId);
    }

    [Test]
    public async Task Handle_GetAllMedicalRecordsQuery_ReturnsEmptyList_WhenMedicalRecordsDoNotExist()
    {
        // Arrange
        var handler = new GetAllMedicalRecordsQueryHandler(_context, _mapper);
        var query = new GetAllMedicalRecordsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondMedicalRecordDtos = result as RespondMedicalRecordDto[] ?? result.ToArray();
        respondMedicalRecordDtos.Should().NotBeNull();
        respondMedicalRecordDtos.Should().BeEmpty();
    }
    
    [Test]
    public async Task Handle_GetMedicalRecordByIdQuery_ReturnsRespondMedicalRecordDto_WhenMedicalRecordExists()
    {
        // Arrange
        SeedData();
        var handler = new GetMedicalRecordByIdQueryHandler(_context, _mapper);
        var query = new GetMedicalRecordByIdQuery(_medicalRecordId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Record.Should().Be("Test Record");
        result.DoctorId.Should().Be(_doctorId);
        result.PatientId.Should().Be(_patientId);
    }

    [Test]
    public async Task Handle_GetMedicalRecordByIdQuery_ReturnsNull_WhenMedicalRecordDoesNotExist()
    {
        // Arrange
        SeedData();
        var handler = new GetMedicalRecordByIdQueryHandler(_context, _mapper);
        var query = new GetMedicalRecordByIdQuery(Guid.NewGuid());

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
}