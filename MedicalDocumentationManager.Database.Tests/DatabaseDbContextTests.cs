using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalDocumentationManager.Database.Tests;

[TestFixture]
public class DatabaseDbContextTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext();

        _context.Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    [Test]
    public void ApplyMigration_DataIsPresent()
    {
        var addressEntities = _context.AddressEntities.ToList();
        addressEntities.Should().HaveCount(25);

        var doctorEntities = _context.DoctorEntities.ToList();
        doctorEntities.Should().HaveCount(15);

        var medicalRecordEntities = _context.MedicalRecordEntities.ToList();
        medicalRecordEntities.Should().HaveCount(30);

        var patientEntities = _context.PatientEntities.ToList();
        patientEntities.Should().HaveCount(15);

        var subscriptionEntities = _context.SubscriptionEntities.ToList();
        subscriptionEntities.Should().HaveCount(50);
    }

    [Test]
    public async Task SaveChangesAsync_SavesChangesToDatabase()
    {
        // Arrange
        var doctor = new DoctorEntity
        {
            Id = new Guid("31e273ed-bb90-4ecb-9b04-b4da014f895e"),
            AddressId = 20L,
            BirthDate = new DateOnly(1955, 2, 11),
            Education = "Medical Degree",
            Email = "anna.johnson1@yahoo.com",
            ExperienceInYears = 28L,
            FullName = "Anna Johnson",
            PhoneNumber = "+1-999-547-2424",
            RoomNumber = "B-437",
            Specialization = "Orthopedics"
        };
        _context.DoctorEntities.Add(doctor);

        // Act
        await _context.SaveChangesAsync();

        // Assert
        _context.DoctorEntities
            .Should()
            .Contain(d =>
                d.Id == Guid.Parse("31e273ed-bb90-4ecb-9b04-b4da014f895e")
                && d.Email == "anna.johnson1@yahoo.com"
                && d.PhoneNumber == "+1-999-547-2424"
            );
    }

    [Test]
    public void AddressEntity_Configuration_IsCorrect()
    {
        // Arrange
        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            AddressId = 1L,
            BirthDate = new DateOnly(1955, 2, 11),
            Education = "Medical Degree",
            Email = "jane.johnson1@yahoo.com",
            ExperienceInYears = 28L,
            FullName = "Jane Johnson",
            PhoneNumber = "+1-989-547-2424",
            RoomNumber = "B-437",
            Specialization = "Orthopedics"
        };

        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            AddressId = 1,
            BirthDate = new DateOnly(1968, 10, 10),
            Email = "john.jackson4@gmail.com",
            FullName = "John Jackson",
            InsurancePolicyNumber = "122725605",
            InsuranceProvider = "Health Net",
            PhoneNumber = "+1-111-146-3530"
        };

        // Act
        _context.DoctorEntities.Add(doctor);
        _context.PatientEntities.Add(patient);

        // Assert
        _context.ChangeTracker.Entries<DoctorEntity>().First().Navigation("AddressEntity").Should().NotBeNull();
        _context.ChangeTracker.Entries<PatientEntity>().First().Navigation("AddressEntity").Should().NotBeNull();

        var doctorEntityType = _context.Model.FindEntityType(typeof(DoctorEntity));
        var doctorAddressForeignKey = doctorEntityType?.GetForeignKeys()
            .Single(fk => fk.Properties.Contains(doctorEntityType.FindProperty("AddressId")));
        doctorAddressForeignKey?.IsRequired.Should().BeTrue();
        doctorAddressForeignKey?.DeleteBehavior.Should().Be(DeleteBehavior.Restrict);

        var patientEntityType = _context.Model.FindEntityType(typeof(PatientEntity));
        var patientAddressForeignKey = patientEntityType?.GetForeignKeys()
            .Single(fk => fk.Properties.Contains(patientEntityType.FindProperty("AddressId")));
        patientAddressForeignKey?.IsRequired.Should().BeTrue();
        patientAddressForeignKey?.DeleteBehavior.Should().Be(DeleteBehavior.Restrict);
    }

    [Test]
    public void DoctorEntity_Configuration_IsCorrect()
    {
        // Arrange
        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            AddressId = 1L,
            BirthDate = new DateOnly(1955, 2, 11),
            Education = "Medical Degree",
            Email = "jane.johnson1@yahoo.com",
            ExperienceInYears = 28L,
            FullName = "Jane Johnson",
            PhoneNumber = "+1-989-547-2424",
            RoomNumber = "B-437",
            Specialization = "Orthopedics"
        };

        var medicalRecord = new MedicalRecordEntity
        {
            DoctorId = doctor.Id,
            Record = string.Empty
        };

        // Act
        _context.DoctorEntities.Add(doctor);
        _context.MedicalRecordEntities.Add(medicalRecord);

        // Assert
        _context.ChangeTracker.Entries<DoctorEntity>().First().Navigation("MedicalRecords").Should().NotBeNull();

        var doctorEntityType = _context.Model.FindEntityType(typeof(DoctorEntity));
        var doctorAddressForeignKey = doctorEntityType?.GetForeignKeys()
            .Single(fk => fk.Properties.Contains(doctorEntityType.FindProperty("AddressId")));
        doctorAddressForeignKey?.IsRequired.Should().BeTrue();
        doctorAddressForeignKey?.DeleteBehavior.Should().Be(DeleteBehavior.Restrict);

        var medicalRecordEntityType = _context.Model.FindEntityType(typeof(MedicalRecordEntity));
        var medicalRecordDoctorForeignKey = medicalRecordEntityType?.GetForeignKeys()
            .Single(fk => fk.Properties.Contains(medicalRecordEntityType.FindProperty("DoctorId")));
        medicalRecordDoctorForeignKey?.IsRequired.Should().BeTrue();
        medicalRecordDoctorForeignKey?.DeleteBehavior.Should().Be(DeleteBehavior.NoAction);
    }

    [Test]
    public void MedicalRecordEntity_Configuration_IsCorrect()
    {
        // Arrange
        var medicalRecord = new MedicalRecordEntity
        {
            DoctorId = Guid.Parse("ebea2a4a-f8c3-4d85-ade2-4a9aafc1f1e8"),
            PatientId = Guid.Parse("e073a299-2f0c-4584-bf4c-2278e935cdd8"),
            Record = string.Empty
        };

        var subscription = new SubscriptionEntity
        {
            MedicalRecordId = medicalRecord.Id,
            SubscriptionType = string.Empty
        };

        // Act
        _context.MedicalRecordEntities.Add(medicalRecord);
        _context.SubscriptionEntities.Add(subscription);

        // Assert
        _context.ChangeTracker.Entries<MedicalRecordEntity>().First().Navigation("Subscriptions").Should().NotBeNull();

        var medicalRecordEntityType = _context.Model.FindEntityType(typeof(MedicalRecordEntity));
        var medicalRecordDoctorForeignKey = medicalRecordEntityType?.GetForeignKeys()
            .Single(fk => fk.Properties.Contains(medicalRecordEntityType.FindProperty("DoctorId")));
        medicalRecordDoctorForeignKey?.IsRequired.Should().BeTrue();
        medicalRecordDoctorForeignKey?.DeleteBehavior.Should().Be(DeleteBehavior.NoAction);

        var medicalRecordPatientForeignKey = medicalRecordEntityType?.GetForeignKeys()
            .Single(fk => fk.Properties.Contains(medicalRecordEntityType.FindProperty("PatientId")));
        medicalRecordPatientForeignKey?.IsRequired.Should().BeTrue();
        medicalRecordPatientForeignKey?.DeleteBehavior.Should().Be(DeleteBehavior.NoAction);
    }
    
    [Test]
    public async Task BeginTransactionAsync_ReturnsTransaction_WhenCalled()
    {
        // Act
        var transaction = await _context.BeginTransactionAsync();

        // Assert
        transaction.Should().NotBeNull();
        transaction.Should().BeAssignableTo<IDbContextTransaction>();
    }
}