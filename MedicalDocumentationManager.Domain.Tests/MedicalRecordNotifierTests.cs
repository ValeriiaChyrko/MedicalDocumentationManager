using System.Reflection;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.Domain.Implementation;

namespace MedicalDocumentationManager.Domain.Tests;

[TestFixture]
public class MedicalRecordNotifierTests
{
    [Test]
    public void Constructor_ThrowsArgumentNullException_WhenRecordObserverIsNull()
    {
        // Arrange
        var messageHandler = Substitute.For<IMessageHandler>();

        // Act
        Action act = () => _ = new MedicalRecordNotifier(null!, messageHandler);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Test]
    public void Subscribe_AddsEventHandler_WhenNotAlreadyRegistered()
    {
        // Arrange
        var recordObserver = Substitute.For<IMedicalRecordObserver>();
        var messageHandler = Substitute.For<IMessageHandler>();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);

        // Act
        notifier.Subscribe();

        // Assert
        recordObserver.Received(1).OnNotifyEvent += Arg.Any<EventHandler<MessageEventArgs>>();
    }

    [Test]
    public void Unsubscribe_RemovesEventHandler_WhenAlreadyRegistered()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
        var recordObserver = Substitute.For<MedicalRecordObserver>(record);
        var messageHandler = Substitute.For<IMessageHandler>();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);
        notifier.Subscribe();

        // Act
        notifier.Unsubscribe();

        // Assert
        recordObserver.Received(1).OnNotifyEvent -= Arg.Any<EventHandler<MessageEventArgs>>();
    }

    [Test]
    public void Unsubscribe_ThrowsInvalidOperationException_WhenObserverIsNotSubscribed()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
        var recordObserver = Substitute.For<MedicalRecordObserver>(record);
        var messageHandler = Substitute.For<IMessageHandler>();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);

        // Act
        var act = () => notifier.Unsubscribe();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("*The observer is not subscribed*");
    }

    [Test]
    public void Subscribe_ThrowsInvalidOperationException_WhenObserverIsAlreadySubscribed()
    {
        // Arrange
        var record = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
        var recordObserver = Substitute.For<MedicalRecordObserver>(record);
        var messageHandler = Substitute.For<IMessageHandler>();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);

        // Act
        notifier.Subscribe();
        var act = () => notifier.Subscribe();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("*The observer is already subscribed*");
    }


    [Test]
    public void Notify_ThrowsTargetInvocationException_WhenMessageIsNull()
    {
        // Arrange
        var recordObserver = Substitute.For<IMedicalRecordObserver>();
        var messageHandler = new ConsoleMessageHandler();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);

        // Act
        var notifyMethod =
            typeof(MedicalRecordNotifier).GetMethod("Notify", BindingFlags.NonPublic | BindingFlags.Instance);
        Action act = () => notifyMethod?.Invoke(notifier, new object[] { null!, new MessageEventArgs(null!) });

        // Assert
        act.Should().Throw<TargetInvocationException>();
    }

    [Test]
    public void Notify_ThrowsArgumentNullException_WhenMessageEventArgsIsNull()
    {
        // Arrange
        var recordObserver = Substitute.For<IMedicalRecordObserver>();
        var messageHandler = Substitute.For<IMessageHandler>();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);

        // Act
        var notifyMethod =
            typeof(MedicalRecordNotifier).GetMethod("Notify", BindingFlags.NonPublic | BindingFlags.Instance);
        Action act = () => notifyMethod?.Invoke(notifier, new object[] { null!, null! });
        act.Should().Throw<TargetInvocationException>().Which.InnerException.Should().BeOfType<ArgumentNullException>();
        act.Should().Throw<TargetInvocationException>().Which.InnerException?.Message.Should()
            .Be("Value cannot be null. (Parameter 'messageEventArgs')");
    }

    [Test]
    public void Notify_CallsHandleMessage_WithCorrectMessage()
    {
        // Arrange
        var recordObserver = Substitute.For<IMedicalRecordObserver>();
        var messageHandler = Substitute.For<IMessageHandler>();
        var notifier = new MedicalRecordNotifier(recordObserver, messageHandler);
        const string message = "Medical history was updated: Test message";

        // Act
        notifier.Subscribe();
        var notifyMethod =
            typeof(MedicalRecordNotifier).GetMethod("Notify", BindingFlags.NonPublic | BindingFlags.Instance);
        notifyMethod?.Invoke(notifier, new object[] { null!, new MessageEventArgs(message) });

        // Assert
        messageHandler.Received(1).HandleMessage(message);
    }
}