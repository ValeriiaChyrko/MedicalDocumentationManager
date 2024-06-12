using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Tests;

[TestFixture]
public class AbstractionTests
{
    [Test]
    public void Constructor_CreatesAddress_WithCorrectProperties()
    {
        // Arrange
        const string street = "Main St";
        const string city = "AnyTown";
        const string state = "CA";
        const string zip = "12345";

        // Act
        var address = new Address(street, city, state, zip);

        // Assert
        address.Street.Should().Be(street);
        address.City.Should().Be(city);
        address.State.Should().Be(state);
        address.Zip.Should().Be(zip);
    }

    [Test]
    public void Constructor_CreatesDoctor_WithCorrectProperties()
    {
        // Arrange
        var id = Guid.NewGuid();
        const string name = "Dr. Smith";
        var birthDate = new DateOnly(1980, 1, 1);
        var address = new Address("123 Main St", "AnyTown", "CA", "12345");
        const string phoneNumber = "555-555-5555";
        const string email = "dr.smith@example.com";
        const string specialization = "Cardiology";
        const int experience = 10;
        const string education = "MD";
        const string roomNumber = "101";

        // Act
        var doctor = new Doctor(id, name, birthDate, address, phoneNumber, email, specialization, experience, education,
            roomNumber);

        // Assert
        doctor.Id.Should().Be(id);
        doctor.FullName.Should().Be(name);
        doctor.BirthDate.Should().Be(birthDate);
        doctor.Address.Should().Be(address);
        doctor.PhoneNumber.Should().Be(phoneNumber);
        doctor.Email.Should().Be(email);
        doctor.Specialization.Should().Be(specialization);
        doctor.ExperienceInYears.Should().Be(experience);
        doctor.Education.Should().Be(education);
        doctor.RoomNumber.Should().Be(roomNumber);
    }

    [Test]
    public void Create_CreatesMedicalRecord_WithCorrectProperties()
    {
        // Arrange
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        const string record = "Some medical record";

        // Act
        var medicalRecord = MedicalRecord.Create(patientId, doctorId, record);

        // Assert
        medicalRecord.PatientId.Should().Be(patientId);
        medicalRecord.DoctorId.Should().Be(doctorId);
        medicalRecord.Record.Should().Be(record);
        medicalRecord.Id.Should().NotBeEmpty();
        medicalRecord.CreatedAt.Should().BeSameDateAs(DateTime.Today);
        medicalRecord.UpdatedAt.Should().BeSameDateAs(DateTime.Today);
    }

    [Test]
    public void Update_UpdatesMedicalRecord_WithCorrectProperties()
    {
        // Arrange
        var patientId = Guid.NewGuid();
        var doctorId = Guid.NewGuid();
        const string record = "Some medical record";
        var medicalRecord = MedicalRecord.Create(patientId, doctorId, record);

        // Act
        medicalRecord.Update(patientId, doctorId, "Updated medical record");

        // Assert
        medicalRecord.PatientId.Should().Be(patientId);
        medicalRecord.DoctorId.Should().Be(doctorId);
        medicalRecord.Record.Should().Be("Updated medical record");
        medicalRecord.UpdatedAt.Should().NotBe(medicalRecord.CreatedAt);
    }

    [Test]
    public void Patient_Constructor_SetsPropertiesCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        const string name = "John Doe";
        var birthDate = new DateOnly(1990, 1, 1);
        var address = new Address("123 Main St", "AnyTown", "USA", "12345");
        const string phoneNumber = "555-123-4567";
        const string email = "john.doe@example.com";
        const string insuranceProvider = "ABC Insurance";
        const string insurancePolicyNumber = "123456789";

        var medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
        var medicalRecordNotifier = Substitute.For<IMedicalRecordNotifier>();

        // Act
        var patient = new Patient(id, name, birthDate, address, phoneNumber, email, insuranceProvider,
            insurancePolicyNumber, medicalRecordObserver, medicalRecordNotifier);

        // Assert
        patient.Id.Should().Be(id);
        patient.FullName.Should().Be(name);
        patient.BirthDate.Should().Be(birthDate);
        patient.Address.Should().Be(address);
        patient.PhoneNumber.Should().Be(phoneNumber);
        patient.Email.Should().Be(email);
        patient.InsuranceProvider.Should().Be(insuranceProvider);
        patient.InsurancePolicyNumber.Should().Be(insurancePolicyNumber);
    }

    [Test]
    public void Constructor_CreatesMessageEventArgs_WithCorrectMessage()
    {
        // Arrange
        const string message = "Hello, world!";

        // Act
        var messageEventArgs = new MessageEventArgs(message);

        // Assert
        messageEventArgs.Message.Should().Be(message);
    }
}