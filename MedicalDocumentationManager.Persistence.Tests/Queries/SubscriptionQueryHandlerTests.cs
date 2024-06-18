using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.Persistence.Queries.Subscription;

namespace MedicalDocumentationManager.Persistence.Tests.Queries;

[TestFixture]
public class SubscriptionQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;
    private static readonly Guid PatientId = Guid.NewGuid();

    private static readonly SubscriptionEntity SeedDataSubscription1 = new SubscriptionEntity
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

    private readonly SubscriptionEntity _seedDataSubscription2 = new SubscriptionEntity
    {
        Id = 123,
        SubscriptionType = "Observer",
        PatientId = SeedDataSubscription1.PatientEntity.Id,
        MedicalRecordId = SeedDataSubscription1.MedicalRecordEntity.Id
    };

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext();
        
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new SubscriptionMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    private void SeedData()
    {
        _context.SubscriptionEntities.Add(SeedDataSubscription1);
        _context.SubscriptionEntities.Add(_seedDataSubscription2);
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
        var respondSubscriptionDtos = result as SubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().HaveCount(2);
        respondSubscriptionDtos.Should().Contain(dto => dto.Id == SeedDataSubscription1.Id && dto.SubscriptionType == "Notifier");
        respondSubscriptionDtos.Should().Contain(dto => dto.Id == _seedDataSubscription2.Id && dto.SubscriptionType == "Observer");
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
        var respondSubscriptionDtos = result as SubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().BeEmpty();
    }
    
    [Test]
    public async Task Handle_GetAllSubscriptionsByMedicalRecordIdQuery_ReturnsRespondSubscriptionDtos_WhenSubscriptionsExistForMedicalRecord()
    {
        // Arrange
        SeedData();
        var handler = new GetAllSubscriptionsByMedicalRecordIdQueryHandler(_context, _mapper);
        var query = new GetAllSubscriptionsByMedicalRecordIdQuery(SeedDataSubscription1.MedicalRecordEntity.Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondSubscriptionDtos = result as SubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().HaveCount(2);
        respondSubscriptionDtos.Should().Contain(dto => dto.MedicalRecordId == SeedDataSubscription1.MedicalRecordEntity.Id && dto.SubscriptionType == "Notifier");
        respondSubscriptionDtos.Should().Contain(dto => dto.MedicalRecordId == SeedDataSubscription1.MedicalRecordEntity.Id && dto.SubscriptionType == "Observer");
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
        var respondSubscriptionDtos = result as SubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().BeEmpty();
    }
    
    [Test]
    public async Task Handle_GetAllSubscriptionsByPatientIdQuery_ReturnsRespondSubscriptionDtos_WhenSubscriptionsExistForPatient()
    {
        // Arrange
        SeedData();
        var handler = new GetAllSubscriptionsByPatientIdQueryHandler(_context, _mapper);
        var query = new GetAllSubscriptionsByPatientIdQuery(SeedDataSubscription1.PatientEntity.Id);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondSubscriptionDtos = result as SubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().HaveCount(2);
        respondSubscriptionDtos.Should().Contain(dto => dto.PatientId == SeedDataSubscription1.PatientEntity.Id && dto.SubscriptionType == "Notifier");
        respondSubscriptionDtos.Should().Contain(dto => dto.PatientId == SeedDataSubscription1.PatientEntity.Id && dto.SubscriptionType == "Observer");
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
        var respondSubscriptionDtos = result as SubscriptionDto[] ?? result.ToArray();
        respondSubscriptionDtos.Should().NotBeNull();
        respondSubscriptionDtos.Should().BeEmpty();
    }
}