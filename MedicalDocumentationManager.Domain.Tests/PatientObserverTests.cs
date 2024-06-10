using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.Domain.Implementation;

namespace MedicalDocumentationManager.Tests;

[TestFixture]
public class PatientObserverTests
{
    private IMedicalRecordObserver _medicalRecordObserver = null!;
    private IMessageHandler _messageHandler = null!;
    private IMedicalRecordNotifier _medicalRecordNotifier = null!;

    [SetUp]
    public void SetUp()
    {
        _medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
        _messageHandler = Substitute.For<ConsoleMessageHandler>();
        _medicalRecordNotifier = Substitute.For<MedicalRecordNotifier>(_medicalRecordObserver, _messageHandler);
    }

    private Patient CreatePatient(IMedicalRecordObserver medicalRecordObserver,
        IMedicalRecordNotifier medicalRecordNotifier)
    {
        var id = Guid.NewGuid();
        const string name = "John Doe";
        var birthDate = new DateOnly(2000, 12, 01);
        var address = new Address("123 Main St", "AnyTown", "USA", "12345");
        const string phoneNumber = "555-1234";
        const string email = "johndoe@example.com";
        const string insuranceProvider = "Blue Cross";
        const string insurancePolicyNumber = "123456";

        return new Patient(id, name, birthDate, address, phoneNumber, email, insuranceProvider, insurancePolicyNumber,
            medicalRecordObserver, medicalRecordNotifier);
    }

    [Test]
    public void SubscribeToMedicalRecordUpdates_CallsSubscribeOnObserver()
    {
        // Arrange
        var patient = CreatePatient(_medicalRecordObserver, _medicalRecordNotifier);

        // Act
        patient.SubscribeToMedicalRecordUpdates();

        // Assert
        _medicalRecordObserver.Received(1).Subscribe();
    }

    [Test]
    public void UnsubscribeFromMedicalRecordUpdates_CallsUnsubscribeOnObserver()
    {
        // Arrange
        var patient = CreatePatient(_medicalRecordObserver, _medicalRecordNotifier);

        // Act
        patient.UnsubscribeFromMedicalRecordUpdates();

        // Assert
        _medicalRecordObserver.Received(1).Unsubscribe();
    }

    [Test]
    public void SubscribeToMedicalRecordNotifications_CallsSubscribeOnNotifier()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
        var recordObserver = Substitute.For<MedicalRecordObserver>(record);
        var messageHandler = Substitute.For<IMessageHandler>();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);
        var patient = CreatePatient(recordObserver, notifier);

        // Act
        patient.SubscribeToMedicalRecordNotifications();

        // Assert
        recordObserver.Received(1).OnNotifyEvent += Arg.Any<EventHandler<MessageEventArgs>>();
    }

    [Test]
    public void UnsubscribeFromMedicalRecordNotifications_CallsUnsubscribeOnNotifier()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
        var recordObserver = Substitute.For<MedicalRecordObserver>(record);
        var messageHandler = Substitute.For<IMessageHandler>();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);
        var patient = CreatePatient(recordObserver, notifier);

        // Act;
        patient.SubscribeToMedicalRecordNotifications();
        patient.UnsubscribeFromMedicalRecordNotifications();

        // Assert
        recordObserver.Received(1).OnNotifyEvent += Arg.Any<EventHandler<MessageEventArgs>>();
        recordObserver.Received(1).OnNotifyEvent -= Arg.Any<EventHandler<MessageEventArgs>>();
    }
}