using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Queries.MedicalRecord;

namespace MedicalDocumentationManager.Persistence.Tests.Queries;

[TestFixture]
public class MedicalRecordQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    private readonly MedicalRecordEntity _seedDataMedicalRecord = new MedicalRecordEntity
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
        },
        CreatedAt = new DateTime(1999, 12, 12),
        UpdatedAt = new DateTime(2000, 05, 25)
    };

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext();
        
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MedicalRecordMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    private void SeedData()
    {
        _context.MedicalRecordEntities.Add(_seedDataMedicalRecord);
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
        var query = new GetAllMedicalRecordsByDoctorIdQuery(_seedDataMedicalRecord.DoctorEntity.Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondMedicalRecordDtos = result as RespondMedicalRecordDto[] ?? result.ToArray();
        respondMedicalRecordDtos.Should().NotBeNull();
        respondMedicalRecordDtos.Should().HaveCount(1);
        respondMedicalRecordDtos.Should().Contain(dto => dto.DoctorId == _seedDataMedicalRecord.DoctorEntity.Id);
        
        var medicalRecord = respondMedicalRecordDtos.FirstOrDefault(d => d.DoctorId == _seedDataMedicalRecord.DoctorEntity.Id);
        medicalRecord.Should().NotBeNull();
        medicalRecord.Record.Should().Be(_seedDataMedicalRecord.Record);
        medicalRecord.DoctorId.Should().Be(_seedDataMedicalRecord.DoctorEntity.Id);
        medicalRecord.PatientId.Should().Be(_seedDataMedicalRecord.PatientEntity.Id);
        medicalRecord.CreatedAt.Should().Be(new DateTime(1999, 12, 12));
        medicalRecord.UpdatedAt.Should().Be(new DateTime(2000, 05, 25));
    }

    [Test]
    public async Task Handle_GetAllMedicalRecordsByDoctorIdQuery_ReturnsEmptyList_WhenMedicalRecordsDoNotExist()
    {
        // Arrange
        var handler = new GetAllMedicalRecordsByDoctorIdQueryHandler(_context, _mapper);
        var query = new GetAllMedicalRecordsByDoctorIdQuery(Guid.NewGuid());

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
        var query = new GetAllMedicalRecordsByPatientIdQuery(_seedDataMedicalRecord.PatientEntity.Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondMedicalRecordDtos = result as RespondMedicalRecordDto[] ?? result.ToArray();
        respondMedicalRecordDtos.Should().NotBeNull();
        respondMedicalRecordDtos.Should().HaveCount(1);
        respondMedicalRecordDtos.Should().Contain(dto => dto.PatientId == _seedDataMedicalRecord.PatientEntity.Id);
        
        var medicalRecord = respondMedicalRecordDtos.FirstOrDefault(d => d.PatientId == _seedDataMedicalRecord.PatientEntity.Id);
        medicalRecord.Should().NotBeNull();
        medicalRecord.Record.Should().Be(_seedDataMedicalRecord.Record);
        medicalRecord.DoctorId.Should().Be(_seedDataMedicalRecord.DoctorEntity.Id);
        medicalRecord.PatientId.Should().Be(_seedDataMedicalRecord.PatientEntity.Id);
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
        respondMedicalRecordDtos.Should().Contain(dto => dto.Id == _seedDataMedicalRecord.Id);
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
        var query = new GetMedicalRecordByIdQuery(_seedDataMedicalRecord.Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Record.Should().Be(_seedDataMedicalRecord.Record);
        result.DoctorId.Should().Be(_seedDataMedicalRecord.DoctorEntity.Id);
        result.PatientId.Should().Be(_seedDataMedicalRecord.PatientEntity.Id);
        result.CreatedAt.Should().Be(new DateTime(1999, 12, 12));
        result.UpdatedAt.Should().Be(new DateTime(2000, 05, 25));
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