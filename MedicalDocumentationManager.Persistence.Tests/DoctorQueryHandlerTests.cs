using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Queries.Doctor;

namespace MedicalDocumentationManager.Persistence.Tests;

[TestFixture]
public class DoctorQueryHandlerTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;
    private IMapper _mapper = null!;
    
    private readonly Guid _doctorId = Guid.NewGuid();
    private readonly Guid _doctorId2 = Guid.NewGuid();

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext(Array.Empty<string>());
        
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DoctorMappingProfile());
        });

        _mapper = mapperConfig.CreateMapper();
    }

    private void SeedData()
    {
        _context.DoctorEntities.Add(
            new DoctorEntity
            {
                Id = _doctorId,
                FullName = "Test Doctor 1",
                PhoneNumber = "123-456-7890",
                Email = "test1@example.com",
                Specialization = "Test Specialization",
                ExperienceInYears = 5,
                Education = "Test Education",
                RoomNumber = "101"
            });
        
        _context.DoctorEntities.Add(
            new DoctorEntity
            {
                Id = _doctorId2,
                FullName = "Test Doctor 2",
                PhoneNumber = "123-456-7891",
                Email = "test2@example.com",
                Specialization = "Test Specialization",
                ExperienceInYears = 15,
                Education = "Test Education",
                RoomNumber = "102"
            });
    
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
        // Assert
        var respondDoctorDtos = result as RespondDoctorDto[] ?? result.ToArray();
        respondDoctorDtos.Should().NotBeNull();
        respondDoctorDtos.Should().HaveCount(2);

        var doctor1 = respondDoctorDtos.FirstOrDefault(d => d.Id == _doctorId);
        doctor1.Should().NotBeNull();
        doctor1.FullName.Should().Be("Test Doctor 1");
        doctor1.PhoneNumber.Should().Be("123-456-7890");
        doctor1.Email.Should().Be("test1@example.com");
        doctor1.Specialization.Should().Be("Test Specialization");
        doctor1.ExperienceInYears.Should().Be(5);
        doctor1.Education.Should().Be("Test Education");
        doctor1.RoomNumber.Should().Be("101");

        var doctor2 = respondDoctorDtos.FirstOrDefault(d => d.Id == _doctorId2);
        doctor2.Should().NotBeNull();
        doctor2.FullName.Should().Be("Test Doctor 2");
        doctor2.PhoneNumber.Should().Be("123-456-7891");
        doctor2.Email.Should().Be("test2@example.com");
        doctor2.Specialization.Should().Be("Test Specialization");
        doctor2.ExperienceInYears.Should().Be(15);
        doctor2.Education.Should().Be("Test Education");
        doctor2.RoomNumber.Should().Be("102");
    }
    
    [Test]
    public async Task Handle_GetDoctorByIdQuery_ReturnsRespondDoctorDto_WhenDoctorExists()
    {
        // Arrange
        var handler = new GetDoctorByIdQueryHandler(_context, _mapper);
        var query = new GetDoctorByIdQuery(_doctorId);

        // Act
        SeedData();
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(_doctorId);
        result.FullName.Should().Be("Test Doctor 1");
        result.PhoneNumber.Should().Be("123-456-7890");
        result.Email.Should().Be("test1@example.com");
        result.Specialization.Should().Be("Test Specialization");
        result.ExperienceInYears.Should().Be(5);
        result.Education.Should().Be("Test Education");
        result.RoomNumber.Should().Be("101");
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