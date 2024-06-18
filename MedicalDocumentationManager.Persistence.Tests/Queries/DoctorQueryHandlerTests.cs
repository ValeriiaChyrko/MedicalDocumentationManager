using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Queries.Doctor;

namespace MedicalDocumentationManager.Persistence.Tests.Queries;

[TestFixture]
public class DoctorQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;

    private readonly DoctorEntity _seedDataDoctor1 = new DoctorEntity
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

    private readonly DoctorEntity _seedDataDoctor2 = new DoctorEntity
    {
        Id = Guid.NewGuid(),
        FullName = "Test Doctor 2",
        PhoneNumber = "123-456-7891",
        Email = "test2@example.com",
        Specialization = "Test Specialization",
        ExperienceInYears = 15,
        Education = "Test Education",
        RoomNumber = "102"
    };

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

    private void SeedData()
    {
        _context.DoctorEntities.Add(_seedDataDoctor1);
        _context.DoctorEntities.Add(_seedDataDoctor2);
        _context.SaveChanges();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }
    
    [Test]
    public async Task Handle_ReturnsEmptyList_WhenNoRecordsExist()
    {
        // Arrange
        var handler = new GetAllDoctorsQueryHandler(_context, _mapper);
        var query = new GetAllDoctorsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondDoctorDtos = result as RespondDoctorDto[] ?? result.ToArray();
        respondDoctorDtos.Should().NotBeNull();
        respondDoctorDtos.Should().BeEmpty();
    }
    
    [Test]
    public async Task Handle_GetAllDoctorsQuery_ReturnsListOfRespondDoctorDtos()
    {
        // Arrange
        var handler = new GetAllDoctorsQueryHandler(_context, _mapper);
        var query = new GetAllDoctorsQuery();

        // Act
        SeedData();
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        var respondDoctorDtos = result as RespondDoctorDto[] ?? result.ToArray();
        respondDoctorDtos.Should().NotBeNull();
        respondDoctorDtos.Should().HaveCount(2);

        var doctor1 = respondDoctorDtos.FirstOrDefault(d => d.Id == _seedDataDoctor1.Id);
        doctor1.Should().NotBeNull();
        doctor1.FullName.Should().Be(_seedDataDoctor1.FullName);
        doctor1.PhoneNumber.Should().Be(_seedDataDoctor1.PhoneNumber);
        doctor1.Email.Should().Be(_seedDataDoctor1.Email);
        doctor1.Specialization.Should().Be(_seedDataDoctor1.Specialization);
        doctor1.ExperienceInYears.Should().Be(_seedDataDoctor1.ExperienceInYears);
        doctor1.Education.Should().Be(_seedDataDoctor1.Education);
        doctor1.RoomNumber.Should().Be(_seedDataDoctor1.RoomNumber);

        var doctor2 = respondDoctorDtos.FirstOrDefault(d => d.Id == _seedDataDoctor2.Id);
        doctor2.Should().NotBeNull();
        doctor2.FullName.Should().Be(_seedDataDoctor2.FullName);
        doctor2.PhoneNumber.Should().Be(_seedDataDoctor2.PhoneNumber);
        doctor2.Email.Should().Be(_seedDataDoctor2.Email);
        doctor2.Specialization.Should().Be(_seedDataDoctor2.Specialization);
        doctor2.ExperienceInYears.Should().Be(_seedDataDoctor2.ExperienceInYears);
        doctor2.Education.Should().Be(_seedDataDoctor2.Education);
        doctor2.RoomNumber.Should().Be(_seedDataDoctor2.RoomNumber);
    }
    
    [Test]
    public async Task Handle_GetDoctorByIdQuery_ReturnsRespondDoctorDto_WhenDoctorExists()
    {
        // Arrange
        var handler = new GetDoctorByIdQueryHandler(_context, _mapper);
        var query = new GetDoctorByIdQuery(_seedDataDoctor1.Id);

        // Act
        SeedData();
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
result.Id.Should().Be(_seedDataDoctor1.Id);
        result.FullName.Should().Be(_seedDataDoctor1.FullName);
        result.PhoneNumber.Should().Be(_seedDataDoctor1.PhoneNumber);
        result.Email.Should().Be(_seedDataDoctor1.Email);
        result.Specialization.Should().Be(_seedDataDoctor1.Specialization);
        result.ExperienceInYears.Should().Be(_seedDataDoctor1.ExperienceInYears);
        result.Education.Should().Be(_seedDataDoctor1.Education);
        result.RoomNumber.Should().Be(_seedDataDoctor1.RoomNumber);
    }

    [Test]
    public async Task Handle_ReturnsNull_WhenDoctorDoesNotExist()
    {
        // Arrange
        var handler = new GetDoctorByIdQueryHandler(_context, _mapper);
        var query = new GetDoctorByIdQuery(Guid.NewGuid());

        // Act
        SeedData();
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeNull();
    }
}