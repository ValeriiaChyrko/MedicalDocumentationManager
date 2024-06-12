using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Queries.Subscription;

namespace MedicalDocumentationManager.Persistence.Tests;

[TestFixture]
public class SubscriptionQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    private readonly long _subscriptionId = 112;
    private readonly long _subscriptionId2 = 123;
    private readonly Guid _patientId = Guid.NewGuid();
    private readonly Guid _doctorId = Guid.NewGuid();
    private readonly Guid _medicalRecordId = Guid.NewGuid();

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext(Array.Empty<string>());
        
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new SubscriptionMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    private void SeedData()
    {
        _context.SubscriptionEntities.Add(
            new SubscriptionEntity
            {
                Id = _subscriptionId,
                SubscriptionType = "Notifier",
                PatientEntity =  new PatientEntity
                {
                    Id = _patientId,
                    FullName = "Test Patient 1",
                    PhoneNumber = "623-456-7890",
                    Email = "test1@example.com",
                    InsurancePolicyNumber = "622785605",
                    InsuranceProvider = "Health Net"
                },
                MedicalRecordEntity = new MedicalRecordEntity
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
                    PatientId = _patientId
                }
            });
        
        _context.SubscriptionEntities.Add(
            new SubscriptionEntity
            {
                Id = _subscriptionId2,
                SubscriptionType = "Observer",
                PatientId = _patientId,
                MedicalRecordId = _medicalRecordId
            });

        _context.SaveChanges();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }
    
    [Test]
    public async Task Handle_GetAllSubscriptionQuery_ReturnsRespondSubscriptionDtos_WhenSubscriptionsExist()
    {
        // Arrange
        SeedData();
        var handler = new GetAllSubscriptionQueryHandler(_context, _mapper);
        var query = new GetAllSubscriptionQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondSubscriptionDtos = result as RespondSubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().HaveCount(2);
        respondSubscriptionDtos.Should().Contain(dto => dto.Id == _subscriptionId && dto.SubscriptionType == "Notifier");
        respondSubscriptionDtos.Should().Contain(dto => dto.Id == _subscriptionId2 && dto.SubscriptionType == "Observer");
    }

    [Test]
    public async Task Handle_GetAllSubscriptionQuery_ReturnsEmptyList_WhenSubscriptionsDoNotExist()
    {
        // Arrange
        var handler = new GetAllSubscriptionQueryHandler(_context, _mapper);
        var query = new GetAllSubscriptionQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondSubscriptionDtos = result as RespondSubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().BeEmpty();
    }
    
    [Test]
    public async Task Handle_GetAllSubscriptionsByMedicalRecordIdQuery_ReturnsRespondSubscriptionDtos_WhenSubscriptionsExistForMedicalRecord()
    {
        // Arrange
        SeedData();
        var handler = new GetAllSubscriptionsByMedicalRecordIdQueryHandler(_context, _mapper);
        var query = new GetAllSubscriptionsByMedicalRecordIdQuery(_medicalRecordId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondSubscriptionDtos = result as RespondSubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().HaveCount(2);
        respondSubscriptionDtos.Should().Contain(dto => dto.MedicalRecordId == _medicalRecordId && dto.SubscriptionType == "Notifier");
        respondSubscriptionDtos.Should().Contain(dto => dto.MedicalRecordId == _medicalRecordId && dto.SubscriptionType == "Observer");
    }

    [Test]
    public async Task Handle_GetAllSubscriptionsByMedicalRecordIdQuery_ReturnsEmptyList_WhenSubscriptionsDoNotExistForMedicalRecord()
    {
        // Arrange
        SeedData();
        var handler = new GetAllSubscriptionsByMedicalRecordIdQueryHandler(_context, _mapper);
        var query = new GetAllSubscriptionsByMedicalRecordIdQuery(Guid.NewGuid());

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondSubscriptionDtos = result as RespondSubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().BeEmpty();
    }
    
    [Test]
    public async Task Handle_GetAllSubscriptionsByPatientIdQuery_ReturnsRespondSubscriptionDtos_WhenSubscriptionsExistForPatient()
    {
        // Arrange
        SeedData();
        var handler = new GetAllSubscriptionsByPatientIdQueryHandler(_context, _mapper);
        var query = new GetAllSubscriptionsByPatientIdQuery(_patientId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondSubscriptionDtos = result as RespondSubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().HaveCount(2);
        respondSubscriptionDtos.Should().Contain(dto => dto.PatientId == _patientId && dto.SubscriptionType == "Notifier");
        respondSubscriptionDtos.Should().Contain(dto => dto.PatientId == _patientId && dto.SubscriptionType == "Observer");
    }

    [Test]
    public async Task Handle_GetAllSubscriptionsByPatientIdQuery_ReturnsEmptyList_WhenSubscriptionsDoNotExistForPatient()
    {
        // Arrange
        SeedData();
        var handler = new GetAllSubscriptionsByPatientIdQueryHandler(_context, _mapper);
        var query = new GetAllSubscriptionsByPatientIdQuery(Guid.NewGuid());

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondSubscriptionDtos = result as RespondSubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().BeEmpty();
    }
}