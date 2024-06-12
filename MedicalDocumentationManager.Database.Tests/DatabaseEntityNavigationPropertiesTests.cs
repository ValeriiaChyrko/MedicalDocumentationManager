using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Database.Tests;

[TestFixture]
public class DatabaseEntityNavigationPropertiesTests
{
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private MedicalDocumentationManagerDbContext _context = null!;

    [SetUp]
    public void SetUp()
    {
        _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
        _context = _factory.CreateDbContext(Array.Empty<string>());

        _context.Database.EnsureCreated();
    }

    [TearDown]
    public void TearDown()
    {
        _context.Database.EnsureDeleted();
    }

    [Test]
    public void AddressEntity_Patients_NotNull()
    {
        //Arrange
        var address = new AddressEntity
        {
            Id = 1115,
            Street = "Test Street",
            City = "Test City",
            State = "Test Region",
            Zip = "01001"
        };

        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            AddressId = 1115L,
            BirthDate = new DateOnly(1968, 10, 10),
            Email = "john.jackson4@gmail.com",
            FullName = "John Jackson",
            InsurancePolicyNumber = "122785605",
            InsuranceProvider = "Health Net",
            PhoneNumber = "+1-111-146-3560"
        };

        //Act
        _context.AddressEntities.Add(address);
        _context.PatientEntities.Add(patient);
        _context.SaveChanges();

        //Assert
        address.Patients.Should().NotBeNull();
        address.Patients.Should().ContainSingle(p => p.AddressId == address.Id);
        patient.AddressEntity.Should().NotBeNull();
        patient.AddressEntity.Should().Be(address);
    }

    [Test]
    public void AddressEntity_Doctors_NotNull()
    {
        //Arrange
        var address = new AddressEntity
        {
            Id = 1115,
            Street = "Test Street",
            City = "Test City",
            State = "Test Region",
            Zip = "01001"
        };

        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            AddressId = 1115L,
            BirthDate = new DateOnly(1974, 6, 15),
            Education = "Medical Degree",
            Email = "anna.brown0@hotmail.com",
            ExperienceInYears = 11L,
            FullName = "Anna Brown",
            PhoneNumber = "+1-882-529-7395",
            RoomNumber = "E-561",
            Specialization = "Pediatrics"
        };

        //Act
        _context.AddressEntities.Add(address);
        _context.DoctorEntities.Add(doctor);
        _context.SaveChanges();

        //Assert
        _context.AddressEntities.Should().ContainSingle(s => s.Id == address.Id);
        _context.AddressEntities.Should().ContainSingle(s => s.Street == address.Street);
        _context.AddressEntities.Should().ContainSingle(s => s.City == address.City);
        _context.AddressEntities.Should().ContainSingle(s => s.State == address.State);
        _context.AddressEntities.Should().ContainSingle(s => s.Zip == address.Zip);

        address.Doctors.Should().NotBeNull();
        address.Doctors.Should().ContainSingle(p => p.AddressId == address.Id);
        doctor.AddressEntity.Should().NotBeNull();
        doctor.AddressEntity.Should().Be(address);
    }

    [Test]
    public void MedicalRecordEntity_PatientEntity_NotNull()
    {
        //Arrange
        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1968, 10, 10),
            Email = "john.jackson4@gmail.com",
            FullName = "John Jackson",
            InsurancePolicyNumber = "122785605",
            InsuranceProvider = "Health Net",
            PhoneNumber = "+1-111-146-3560"
        };

        var medicalRecord = new MedicalRecordEntity
        {
            PatientId = patient.Id,
            DoctorId = Guid.NewGuid(),
            Record = "Medical Record",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        //Act
        _context.PatientEntities.Add(patient);
        _context.MedicalRecordEntities.Add(medicalRecord);
        _context.SaveChanges();

        //Assert
        medicalRecord.PatientEntity.Should().NotBeNull();
        medicalRecord.PatientEntity.Should().Be(patient);
        patient.MedicalRecords.Should().ContainSingle(m => m.PatientId == patient.Id);
    }

    [Test]
    public void MedicalRecordEntity_DoctorEntity_NotNull()
    {
        //Arrange
        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1974, 6, 15),
            Education = "Medical Degree",
            Email = "anna.brown0@hotmail.com",
            ExperienceInYears = 11L,
            FullName = "Anna Brown",
            PhoneNumber = "+1-882-529-7395",
            RoomNumber = "E-561",
            Specialization = "Pediatrics"
        };

        var medicalRecord = new MedicalRecordEntity
        {
            PatientId = Guid.NewGuid(),
            DoctorId = doctor.Id,
            Record = "Medical Record",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        //Act
        _context.DoctorEntities.Add(doctor);
        _context.MedicalRecordEntities.Add(medicalRecord);
        _context.SaveChanges();

        //Assert
        medicalRecord.DoctorEntity.Should().NotBeNull();
        medicalRecord.DoctorEntity.Should().Be(doctor);
        doctor.MedicalRecords.Should().ContainSingle(m => m.DoctorId == doctor.Id);
    }


    [Test]
    public void SubscriptionEntity_PatientEntity_NotNull()
    {
        //Arrange
        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1968, 10, 10),
            Email = "john.jackson4@gmail.com",
            FullName = "John Jackson",
            InsurancePolicyNumber = "122785605",
            InsuranceProvider = "Health Net",
            PhoneNumber = "+1-111-146-3560"
        };

        var subscription = new SubscriptionEntity
        {
            PatientId = patient.Id,
            MedicalRecordId = Guid.NewGuid(),
            SubscriptionType = "Observer"
        };

        //Act
        _context.PatientEntities.Add(patient);
        _context.SubscriptionEntities.Add(subscription);
        _context.SaveChanges();

        //Assert
        subscription.PatientEntity.Should().NotBeNull();
        subscription.PatientEntity.Should().Be(patient);
        patient.Subscriptions.Should().ContainSingle(s => s.PatientId == patient.Id);
    }

    [Test]
    public void SubscriptionEntity_MedicalRecordEntity_NotNull()
    {
        //Arrange
        var medicalRecord = new MedicalRecordEntity
        {
            Id = Guid.NewGuid(),
            CreatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6909),
            DoctorId = new Guid("1345f6de-2771-46d4-9f77-a4e05956c87e"),
            PatientId = new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"),
            Record =
                "Medical record 27 for patient 293a3eb3-7212-424a-bec5-d6b37f51841c and doctor 1345f6de-2771-46d4-9f77-a4e05956c87e",
            UpdatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6910)
        };

        var subscription = new SubscriptionEntity
        {
            PatientId = Guid.NewGuid(),
            MedicalRecordId = medicalRecord.Id,
            SubscriptionType = "Notifier"
        };

        //Act
        _context.MedicalRecordEntities.Add(medicalRecord);
        _context.SubscriptionEntities.Add(subscription);
        _context.SaveChanges();

        //Assert
        subscription.MedicalRecordEntity.Should().NotBeNull();
        subscription.MedicalRecordEntity.Should().Be(medicalRecord);
        medicalRecord.Subscriptions.Should().ContainSingle(s => s.MedicalRecordId == medicalRecord.Id);
    }

    [Test]
    public void AddressEntity_Patients_Setter()
    {
        //Arrange
        var address = new AddressEntity
        {
            Id = 1115,
            Street = "Test Street",
            City = "Test City",
            State = "Test Region",
            Zip = "01001"
        };

        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1968, 10, 10),
            Email = "john.jackson4@gmail.com",
            FullName = "John Jackson",
            InsurancePolicyNumber = "122785605",
            InsuranceProvider = "Health Net",
            PhoneNumber = "+1-111-146-3560"
        };

        //Act
        address.Patients = new List<PatientEntity> { patient };
        _context.AddressEntities.Add(address);
        _context.SaveChanges();

        //Assert
        address.Patients.Should().NotBeNull();
        address.Patients.Should().ContainSingle(p => p.AddressId == address.Id);
        patient.AddressEntity.Should().NotBeNull();
        patient.AddressEntity.Should().Be(address);
    }

    [Test]
    public void AddressEntity_Doctors_Setter()
    {
        //Arrange
        var address = new AddressEntity
        {
            Id = 1115,
            Street = "Test Street",
            City = "Test City",
            State = "Test Region",
            Zip = "01001"
        };

        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1974, 6, 15),
            Education = "Medical Degree",
            Email = "anna.brown0@hotmail.com",
            ExperienceInYears = 11L,
            FullName = "Anna Brown",
            PhoneNumber = "+1-882-529-7395",
            RoomNumber = "E-561",
            Specialization = "Pediatrics"
        };

        //Act
        address.Doctors = new List<DoctorEntity> { doctor };
        _context.AddressEntities.Add(address);
        _context.SaveChanges();

        //Assert
        address.Doctors.Should().NotBeNull();
        address.Doctors.Should().ContainSingle(p => p.AddressId == address.Id);
        doctor.AddressEntity.Should().NotBeNull();
        doctor.AddressEntity.Should().Be(address);
    }

    [Test]
    public void SubscriptionEntity_PatientEntity_Setter()
    {
        //Arrange
        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1968, 10, 10),
            Email = "john.jackson4@gmail.com",
            FullName = "John Jackson",
            InsurancePolicyNumber = "122785605",
            InsuranceProvider = "Health Net",
            PhoneNumber = "+1-111-146-3560"
        };

        var subscription = new SubscriptionEntity
        {
            PatientId = patient.Id,
            MedicalRecordId = Guid.NewGuid(),
            SubscriptionType = "Observer",
            //Act
            PatientEntity = patient
        };

        _context.SubscriptionEntities.Add(subscription);
        _context.SaveChanges();

        //Assert
        subscription.PatientEntity.Should().NotBeNull();
        subscription.PatientEntity.Should().Be(patient);
        patient.Subscriptions.Should().ContainSingle(s => s.PatientId == patient.Id);
    }

    [Test]
    public void SubscriptionEntity_MedicalRecordEntity_Setter()
    {
        //Arrange
        var medicalRecord = new MedicalRecordEntity
        {
            Id = Guid.NewGuid(),
            CreatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6909),
            DoctorId = new Guid("1345f6de-2771-46d4-9f77-a4e05956c87e"),
            PatientId = new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"),
            Record =
                "Medical record 27 for patient 293a3eb3-7212-424a-bec5-d6b37f51841c and doctor 1345f6de-2771-46d4-9f77-a4e05956c87e",
            UpdatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6910)
        };

        var subscription = new SubscriptionEntity
        {
            PatientId = Guid.NewGuid(),
            MedicalRecordId = medicalRecord.Id,
            SubscriptionType = "Notifier",
            //Act
            MedicalRecordEntity = medicalRecord
        };

        _context.SubscriptionEntities.Add(subscription);
        _context.SaveChanges();

        //Assert
        _context.SubscriptionEntities.Should().ContainSingle(s => s.Id == subscription.Id);
        _context.SubscriptionEntities.Should().Contain(s => s.PatientId == subscription.PatientId);
        _context.SubscriptionEntities.Should().Contain(s => s.MedicalRecordId == subscription.MedicalRecordId);
        _context.SubscriptionEntities.Should().Contain(s => s.SubscriptionType == subscription.SubscriptionType);

        subscription.MedicalRecordEntity.Should().NotBeNull();
        subscription.MedicalRecordEntity.Should().Be(medicalRecord);
        medicalRecord.Subscriptions.Should().ContainSingle(s => s.MedicalRecordId == medicalRecord.Id);
    }

    [Test]
    public void DoctorEntity_AddressEntity_Setter()
    {
        //Arrange
        var address = new AddressEntity
        {
            Id = 1115,
            Street = "Test Street",
            City = "Test City",
            State = "Test Region",
            Zip = "01001"
        };

        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1974, 6, 15),
            Education = "Medical Degree",
            Email = "anna.brown0@hotmail.com",
            ExperienceInYears = 11L,
            FullName = "Anna Brown",
            PhoneNumber = "+1-882-529-7395",
            RoomNumber = "E-561",
            Specialization = "Pediatrics",
            AddressId = address.Id,
            //Act
            AddressEntity = address
        };

        _context.DoctorEntities.Add(doctor);
        _context.SaveChanges();

        //Assert
        doctor.AddressEntity.Should().NotBeNull();
        doctor.AddressEntity.Should().Be(address);
        address.Doctors.Should().ContainSingle(d => d.AddressId == address.Id);
    }

    [Test]
    public void DoctorEntity_MedicalRecords_Setter()
    {
        //Arrange
        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1974, 6, 15),
            Education = "Medical Degree",
            Email = "anna.brown0@hotmail.com",
            ExperienceInYears = 11L,
            FullName = "Anna Brown",
            PhoneNumber = "+1-882-529-7395",
            RoomNumber = "E-561",
            Specialization = "Pediatrics"
        };

        var medicalRecord = new MedicalRecordEntity
        {
            Id = Guid.NewGuid(),
            CreatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6909),
            DoctorId = doctor.Id,
            PatientId = new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"),
            Record =
                "Medical record 27 for patient 293a3eb3-7212-424a-bec5-d6b37f51841c and doctor 1345f6de-2771-46d4-9f77-a4e05956c87e",
            UpdatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6910)
        };

        //Act
        doctor.MedicalRecords = new List<MedicalRecordEntity> { medicalRecord };
        _context.DoctorEntities.Add(doctor);
        _context.SaveChanges();

        //Assert
        _context.DoctorEntities.Should().ContainSingle(d => d.Id == doctor.Id);
        _context.DoctorEntities.Should().Contain(d => d.BirthDate == doctor.BirthDate);
        _context.DoctorEntities.Should().Contain(d => d.Education == doctor.Education);
        _context.DoctorEntities.Should().ContainSingle(d => d.Email == doctor.Email);
        _context.DoctorEntities.Should().Contain(d => d.ExperienceInYears == doctor.ExperienceInYears);
        _context.DoctorEntities.Should().ContainSingle(d => d.FullName == doctor.FullName);
        _context.DoctorEntities.Should().ContainSingle(d => d.PhoneNumber == doctor.PhoneNumber);
        _context.DoctorEntities.Should().ContainSingle(d => d.RoomNumber == doctor.RoomNumber);
        _context.DoctorEntities.Should().Contain(d => d.Specialization == doctor.Specialization);

        doctor.MedicalRecords.Should().NotBeNull();
        doctor.MedicalRecords.Should().ContainSingle(m => m.DoctorId == doctor.Id);
        medicalRecord.DoctorEntity.Should().NotBeNull();
        medicalRecord.DoctorEntity.Should().Be(doctor);
    }

    [Test]
    public void MedicalRecordEntity_PatientEntity_Setter()
    {
        //Arrange
        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1968, 10, 10),
            Email = "john.jackson4@gmail.com",
            FullName = "John Jackson",
            InsurancePolicyNumber = "122785605",
            InsuranceProvider = "Health Net",
            PhoneNumber = "+1-111-146-3560"
        };

        var medicalRecord = new MedicalRecordEntity
        {
            Id = Guid.NewGuid(),
            DoctorId = Guid.NewGuid(),
            Record =
                "Medical record 27 for patient 293a3eb3-7212-424a-bec5-d6b37f51841c and doctor 1345f6de-2771-46d4-9f77-a4e05956c87e",
            CreatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6909),
            UpdatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6910),
            PatientId = patient.Id,
            //Act
            PatientEntity = patient
        };

        _context.MedicalRecordEntities.Add(medicalRecord);
        _context.SaveChanges();

        //Assert
        medicalRecord.PatientEntity.Should().NotBeNull();
        medicalRecord.PatientEntity.Should().Be(patient);
        patient.MedicalRecords.Should().ContainSingle(m => m.PatientId == patient.Id);
    }

    [Test]
    public void MedicalRecordEntity_DoctorEntity_Setter()
    {
        //Arrange
        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            BirthDate = new DateOnly(1974, 6, 15),
            Education = "Medical Degree",
            Email = "anna.brown0@hotmail.com",
            ExperienceInYears = 11L,
            FullName = "Anna Brown",
            PhoneNumber = "+1-882-529-7395",
            RoomNumber = "E-561",
            Specialization = "Pediatrics"
        };

        var medicalRecord = new MedicalRecordEntity
        {
            Id = Guid.NewGuid(),
            PatientId = Guid.NewGuid(),
            Record =
                "Medical record 27 for patient 293a3eb3-7212-424a-bec5-d6b37f51841c and doctor 1345f6de-2771-46d4-9f77-a4e05956c87e",
            CreatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6909),
            UpdatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6910),
            DoctorId = doctor.Id,
            //Act
            DoctorEntity = doctor
        };

        _context.MedicalRecordEntities.Add(medicalRecord);
        _context.SaveChanges();

        //Assert
        medicalRecord.DoctorEntity.Should().NotBeNull();
        medicalRecord.DoctorEntity.Should().Be(doctor);
        doctor.MedicalRecords.Should().ContainSingle(m => m.DoctorId == doctor.Id);
    }

    [Test]
    public void MedicalRecordEntity_Subscriptions_Setter()
    {
        //Arrange
        var medicalRecord = new MedicalRecordEntity
        {
            Id = Guid.NewGuid(),
            PatientId = Guid.NewGuid(),
            DoctorId = Guid.NewGuid(),
            Record =
                "Medical record 27 for patient  and doctor",
            CreatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6909),
            UpdatedAt = new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6910)
        };

        var subscription = new SubscriptionEntity
        {
            Id = 1710,
            PatientId = medicalRecord.PatientId,
            MedicalRecordId = medicalRecord.Id,
            SubscriptionType = "Observer"
        };

        //Act
        medicalRecord.Subscriptions = new List<SubscriptionEntity> { subscription };
        _context.MedicalRecordEntities.Add(medicalRecord);
        _context.SaveChanges();

        //Assert
        _context.MedicalRecordEntities.Should().ContainSingle(m => m.Id == medicalRecord.Id);
        _context.MedicalRecordEntities.Should().ContainSingle(m => m.PatientId == medicalRecord.PatientId);
        _context.MedicalRecordEntities.Should().ContainSingle(m => m.DoctorId == medicalRecord.DoctorId);
        _context.MedicalRecordEntities.Should().ContainSingle(m => m.Record == medicalRecord.Record);
        _context.MedicalRecordEntities.Should().ContainSingle(m => m.CreatedAt == medicalRecord.CreatedAt);
        _context.MedicalRecordEntities.Should().ContainSingle(m => m.UpdatedAt == medicalRecord.UpdatedAt);

        medicalRecord.Subscriptions.Should().NotBeNull();
        medicalRecord.Subscriptions.Should().ContainSingle(s => s.MedicalRecordId == medicalRecord.Id);
        subscription.MedicalRecordEntity.Should().NotBeNull();
        subscription.MedicalRecordEntity.Should().Be(medicalRecord);
    }

    [Test]
    public void PatientEntity_AddressEntity_Setter()
    {
        //Arrange
        var address = new AddressEntity
        {
            Id = 1123,
            Street = "123 Main St",
            City = "Anytown",
            State = "CA",
            Zip = "12345"
        };

        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            FullName = "John Doe",
            BirthDate = new DateOnly(1990, 1, 1),
            PhoneNumber = "123-456-7890",
            Email = "johndoe@example.com",
            InsuranceProvider = "Health Net",
            InsurancePolicyNumber = "123456789",
            AddressId = address.Id,
            //Act
            AddressEntity = address
        };

        _context.PatientEntities.Add(patient);
        _context.SaveChanges();

        //Assert
        patient.AddressEntity.Should().NotBeNull();
        patient.AddressEntity.Should().Be(address);
        address.Patients.Should().ContainSingle(p => p.AddressId == address.Id);
    }

    [Test]
    public void PatientEntity_MedicalRecords_Setter()
    {
        //Arrange
        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            FullName = "John Doe",
            BirthDate = new DateOnly(1990, 1, 1),
            PhoneNumber = "123-456-7890",
            Email = "johndoe@example.com",
            InsuranceProvider = "Health Net",
            InsurancePolicyNumber = "123456789"
        };

        var medicalRecord = new MedicalRecordEntity
        {
            Id = Guid.NewGuid(),
            PatientId = patient.Id,
            DoctorId = Guid.NewGuid(),
            Record = "Medical record 1",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        //Act
        patient.MedicalRecords = new List<MedicalRecordEntity> { medicalRecord };
        _context.PatientEntities.Add(patient);
        _context.SaveChanges();

        //Assert
        patient.MedicalRecords.Should().NotBeNull();
        patient.MedicalRecords.Should().ContainSingle(m => m.PatientId == patient.Id);
        medicalRecord.PatientEntity.Should().NotBeNull();
        medicalRecord.PatientEntity.Should().Be(patient);
    }

    [Test]
    public void PatientEntity_Subscriptions_Setter()
    {
        //Arrange
        var patient = new PatientEntity
        {
            Id = Guid.NewGuid(),
            FullName = "John Doe",
            BirthDate = new DateOnly(1990, 1, 1),
            PhoneNumber = "123-456-7890",
            Email = "johndoe@example.com",
            InsuranceProvider = "Health Net",
            InsurancePolicyNumber = "123456789"
        };

        var subscription = new SubscriptionEntity
        {
            Id = 1789,
            PatientId = patient.Id,
            MedicalRecordId = Guid.NewGuid(),
            SubscriptionType = "Observer"
        };

        //Act
        patient.Subscriptions = new List<SubscriptionEntity> { subscription };
        _context.PatientEntities.Add(patient);
        _context.SaveChanges();

        //Assert
        _context.PatientEntities.Should().ContainSingle(p => p.Id == patient.Id);
        _context.PatientEntities.Should().ContainSingle(p => p.Email == patient.Email);
        _context.PatientEntities.Should().ContainSingle(p => p.PhoneNumber == patient.PhoneNumber);
        _context.PatientEntities.Should().ContainSingle(p => p.FullName == patient.FullName);
        _context.PatientEntities.Should().ContainSingle(p => p.BirthDate == patient.BirthDate);
        _context.PatientEntities.Should().Contain(p => p.InsuranceProvider == patient.InsuranceProvider);
        _context.PatientEntities.Should().ContainSingle(p => p.InsurancePolicyNumber == patient.InsurancePolicyNumber);

        patient.Subscriptions.Should().NotBeNull();
        patient.Subscriptions.Should().ContainSingle(s => s.PatientId == patient.Id);
        subscription.PatientEntity.Should().NotBeNull();
        subscription.PatientEntity.Should().Be(patient);
    }
}