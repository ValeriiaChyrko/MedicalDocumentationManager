using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Implementation;

namespace MedicalDocumentationManager.Domain.Tests;

[TestFixture]
public class MedicalRecordObserverTests
{
    [Test]
    public void MedicalRecordObserver_Constructor_ThrowsArgumentNullException_WhenRecordIsNull()
    {
        // Act
        TestDelegate act = () => _ = new MedicalRecordObserver(null!);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }

    [Test]
    public void Subscribe_DoesNotThrowArgumentNullException_WhenOnNotifyEventIsNull()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, Guid.Empty, string.Empty);
        var observer = new MedicalRecordObserver(record);

        // Act and Assert
        Assert.DoesNotThrow(() => observer.Subscribe());
    }

    [Test]
    public void Subscribe_ThrowsInvalidOperationException_WhenOnMedicalRecordUpdatedIsAlreadySubscribed()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, Guid.Empty, string.Empty);
        var observer = new MedicalRecordObserver(record);
        observer.Subscribe();

        // Act
        var act = () => observer.Subscribe();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("*The observer is already subscribed*");
    }

    [Test]
    public void UnSubscribe_ThrowsInvalidOperationException_WhenOnMedicalRecordUpdatedIsNotSubscribed()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, Guid.Empty, string.Empty);
        var observer = new MedicalRecordObserver(record);

        // Act
        var act = () => observer.Unsubscribe();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("*The observer is not subscribed*");
    }


    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenRecordIsNull()
    {
        // Act
        var act = () => _ = new MedicalRecordObserver(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithMessage("*record*");
    }

    [Test]
    public void Subscribe_ShouldAttachEventHandler_ToRecordUpdatedEvent()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, Guid.Empty, string.Empty);
        var observer = new MedicalRecordObserver(record);

        // Act
        observer.Subscribe();

        // Assert
        record.Updated += Arg.Any<EventHandler<MessageEventArgs>>();
    }

    [Test]
    public void Unsubscribe_ShouldDetachEventHandler_FromRecordUpdatedEvent()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, Guid.Empty, string.Empty);
        var observer = new MedicalRecordObserver(record);
        observer.Subscribe();

        // Act
        observer.Unsubscribe();

        // Assert
        record.Updated -= Arg.Any<EventHandler<MessageEventArgs>>();
    }

    [Test]
    public void OnMedicalRecordUpdated_ShouldInvokeOnNotifyEvent_WhenUpdatedEventIsRaised()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, Guid.Empty, string.Empty);
        var observer = new MedicalRecordObserver(record);
        var onNotifyEventInvoked = false;

        observer.OnNotifyEvent += (_, e) =>
        {
            onNotifyEventInvoked = true;
            e.Message.Should().Be("Medical history was updated: New record");
        };

        // Act
        observer.Subscribe();
        record.Update(Guid.Empty, Guid.Empty, "New record");

        // Assert
        onNotifyEventInvoked.Should().BeTrue();
    }

    [Test]
    public void IsRegistered_ReturnsTrue_WhenHandlerIsRegistered()
    {
        // Arrange
        var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.NewGuid(), Guid.NewGuid(), "Initial record");
        var handler = new EventHandler<MessageEventArgs>((_, _) => { });
        medicalRecord.Updated += handler;

        // Act
        var result = medicalRecord.IsRegistered(handler);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void IsRegistered_ReturnsFalse_WhenHandlerIsNotRegistered()
    {
        // Arrange
        var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.NewGuid(), Guid.NewGuid(), "Initial record");
        var handler = new EventHandler<MessageEventArgs>((_, _) => { });

        // Act
        var result = medicalRecord.IsRegistered(handler);

        // Assert
        result.Should().BeFalse();
    }
}