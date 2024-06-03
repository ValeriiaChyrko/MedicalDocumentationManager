using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Implementation;

namespace MedicalDocumentationManager.Tests
{
    [TestFixture]
    public class MedicalRecordObserverTests
    {
        [Test]
        public void SubscribeAndUnsubscribeFromMedicalRecord_UpdatesEventSubscriptions()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
            var messageHandlerMock = Substitute.For<IMessageHandler>();
            var observer = new MedicalRecordObserver(medicalRecord, messageHandlerMock);

            // Act
            observer.Subscribe();
            medicalRecord.Update(Guid.NewGuid(), Guid.NewGuid(), "New record");
            observer.Unsubscribe();
            medicalRecord.Update(Guid.NewGuid(), Guid.NewGuid(), "Another record");

            // Assert
            messageHandlerMock.Received(1).HandleMessage(Arg.Any<string>());
        }

        [Test]
        public void Notify_WithNullOrEmptyMessage_ThrowsArgumentNullException()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
            var messageHandlerMock = Substitute.For<IMessageHandler>();
            var observer = new MedicalRecordObserver(medicalRecord, messageHandlerMock);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => observer.Notify(null!));
            Assert.Throws<ArgumentNullException>(() => observer.Notify(""));
        }

        [Test]
        public void MissingMessageHandler_ThrowsArgumentNullException()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);

            TestDelegate act = () => _ = new MedicalRecordObserver(medicalRecord, null!);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Test]
        public void HandleMessage_CalledAfterEachMedicalRecordUpdate()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
            var messageHandlerMock = Substitute.For<IMessageHandler>();
            var observer = new MedicalRecordObserver(medicalRecord, messageHandlerMock);

            // Act
            observer.Subscribe();
            medicalRecord.Update(Guid.NewGuid(), Guid.NewGuid(), "First record");
            medicalRecord.Update(Guid.NewGuid(), Guid.NewGuid(), "Second record");

            // Assert
            messageHandlerMock.Received(2).HandleMessage(Arg.Any<string>());
        }

        [Test]
        public void HandleMessage_CalledCorrectNumberOfTimes()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
            var messageHandlerMock = Substitute.For<IMessageHandler>();
            var observer = new MedicalRecordObserver(medicalRecord, messageHandlerMock);
            var updatesCount = 5;

            // Act
            observer.Subscribe();
            for (var i = 0; i < updatesCount; i++)
            {
                medicalRecord.Update(Guid.NewGuid(), Guid.NewGuid(), $"Record {i + 1}");
            }

            // Assert
            messageHandlerMock.Received(updatesCount).HandleMessage(Arg.Any<string>());
        }

        [Test]
        public void Notify_CallsHandleMessageWithCorrectMessage()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
            var messageHandlerMock = Substitute.For<IMessageHandler>();
            var observer = new MedicalRecordObserver(medicalRecord, messageHandlerMock);
            const string message = "Test message";

            // Act
            observer.Notify(message);

            // Assert
            messageHandlerMock.Received(1).HandleMessage(message);
        }

        [Test]
        public void UnsubscribeAfterMedicalRecordDeletion_UnsubscribesFromMedicalRecordUpdates()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
            var messageHandlerMock = Substitute.For<IMessageHandler>();
            var observer = new MedicalRecordObserver(medicalRecord, messageHandlerMock);

            // Act
            observer.Subscribe();
            // ReSharper disable once RedundantAssignment
            medicalRecord = null; // Simulate deletion
            GC.Collect(); // Trigger garbage collection
            GC.WaitForPendingFinalizers();

            // Assert
            messageHandlerMock.DidNotReceive().HandleMessage(Arg.Any<string>());
        }

        [Test]
        public void UnsubscribeBeforeObserverDeletion_UnsubscribesFromMedicalRecordUpdates()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
            var messageHandlerMock = Substitute.For<IMessageHandler>();
            var observer = new MedicalRecordObserver(medicalRecord, messageHandlerMock);

            // Act
            observer.Subscribe();
            // ReSharper disable once RedundantAssignment
            observer = null; // Simulate observer deletion
            GC.Collect(); // Trigger garbage collection
            GC.WaitForPendingFinalizers();

            // Assert
            messageHandlerMock.DidNotReceive().HandleMessage(Arg.Any<string>());
        }

        [Test]
        public void ConcurrentOperationWithMultipleObservers_WorksCorrectly()
        {
            // Arrange
            var medicalRecord = MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty);
            var messageHandlerMock = Substitute.For<IMessageHandler>();
            var observersCount = 3;
            var updatesCount = 5;

            // Act
            var observers = new MedicalRecordObserver[observersCount];
            for (int i = 0; i < observersCount; i++)
            {
                observers[i] = new MedicalRecordObserver(medicalRecord, messageHandlerMock);
                observers[i].Subscribe();
            }

            for (int i = 0; i < updatesCount; i++)
            {
                medicalRecord.Update(Guid.NewGuid(), Guid.NewGuid(), $"Record {i + 1}");
            }

            // Assert
            messageHandlerMock.Received(observersCount * updatesCount).HandleMessage(Arg.Any<string>());
        }

        [Test]
        public void InvalidArgumentsInConstructor_ThrowArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                _ = new MedicalRecordObserver(null!, Substitute.For<IMessageHandler>()));
            
            Assert.Throws<ArgumentNullException>(() =>
               _ = new MedicalRecordObserver(MedicalRecord.Create(Guid.Empty, Guid.Empty, string.Empty), null!));
        }
    }
}