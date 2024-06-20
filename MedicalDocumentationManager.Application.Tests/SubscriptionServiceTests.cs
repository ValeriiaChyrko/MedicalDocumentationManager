using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Enums;
using MedicalDocumentationManager.Application.Implementations;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.Persistence.Queries.Patient;
using MedicalDocumentationManager.Persistence.Queries.Subscription;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Commands.Subscription;
using Microsoft.EntityFrameworkCore.Storage;
using Exception = System.Exception;

namespace MedicalDocumentationManager.Application.Tests
{
    [TestFixture]
    public class SubscriptionServiceTests
    {
        private ILogger _logger = null!;
        private IMediator _mediator = null!;
        private IMapper _mapper = null!;
        private IMedicalRecordObserver _medicalRecordObserver = null!;
        private IMedicalRecordNotifier _medicalRecordNotifier = null!;
        private SubscriptionService _subscriptionService = null!;
        private IDatabaseTransactionManager _transactionManager = null!;

        [SetUp]
        public void SetUp()
        {
            _logger = Substitute.For<ILogger>();
            _mediator = Substitute.For<IMediator>();
            _mapper = Substitute.For<IMapper>();
            _medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
            _medicalRecordNotifier = Substitute.For<IMedicalRecordNotifier>();
            _transactionManager = Substitute.For<IDatabaseTransactionManager>();
            _subscriptionService = new SubscriptionService(_logger, _mediator, _mapper, _transactionManager);
            Substitute.For<IDbContextTransaction>();
        }

        [Test]
        public async Task ProcessMedicalRecordSubscriptions_WithObserverSubscriptionDtoAndPatientDto_CallsSubscribeToMedicalRecordUpdates()
        {
            // Arrange
            var medicalRecordId = Guid.NewGuid();
            var medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
            var medicalRecordNotifier = Substitute.For<IMedicalRecordNotifier>();
            var subscriptionDto = new SubscriptionDto
            {
                Id = 123,
                PatientId = Guid.NewGuid(),
                MedicalRecordId = medicalRecordId,
                SubscriptionType = SubscriptionType.Observer.ToString()
            };
            var respondPatientDto = new RespondPatientDto
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                AddressId = 123,
                PhoneNumber = "123-456-7890",
                Email = "johndoe@example.com",
                Address = new AddressDto { Id = 123, Street = "123 Main St", City = "Anytown", State = "CA", Zip = "12345" },
                InsuranceProvider = "Insurance Co.",
                InsurancePolicyNumber = "1234567890"
            };
            var address = new Address("123 Main St", "Anytown", "CA", "12345");
            var patient = Patient.Create(respondPatientDto.Id, respondPatientDto.FullName, respondPatientDto.BirthDate, address,
                respondPatientDto.PhoneNumber, respondPatientDto.Email, respondPatientDto.InsuranceProvider,
                respondPatientDto.InsurancePolicyNumber, _medicalRecordObserver, _medicalRecordNotifier);

            var subscriptions = new[] { subscriptionDto };

            _mediator.Send(Arg.Any<GetAllSubscriptionsByMedicalRecordIdQuery>(), Arg.Any<CancellationToken>())
                .Returns(subscriptions);

            _mediator.Send(Arg.Any<GetPatientByIdWithAddressQuery>(), Arg.Any<CancellationToken>())
                .Returns(respondPatientDto);

            _mapper.Map<Patient>(Arg.Any<RespondPatientDto>(), Arg.Any<Action<IMappingOperationOptions>>())
                .Returns(patient);

            // Act
            await _subscriptionService.ProcessMedicalRecordSubscriptions(medicalRecordId, medicalRecordObserver, medicalRecordNotifier, CancellationToken.None);

            // Assert
            _medicalRecordObserver.Received(1).Subscribe();
        }

        [Test]
        public async Task ProcessMedicalRecordSubscriptions_WithNotifierSubscriptionDtoAndPatientDto_CallsSubscribeToMedicalRecordNotifications()
        {
            // Arrange
            var medicalRecordId = Guid.NewGuid();
            var medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
            var medicalRecordNotifier = Substitute.For<IMedicalRecordNotifier>();
            var subscriptionDto = new SubscriptionDto
            {
                Id = 123,
                PatientId = Guid.NewGuid(),
                MedicalRecordId = medicalRecordId,
                SubscriptionType = SubscriptionType.Notifier.ToString()
            };
            var respondPatientDto = new RespondPatientDto
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                AddressId = 123,
                PhoneNumber = "123-456-7890",
                Email = "johndoe@example.com",
                Address = new AddressDto { Id = 123, Street = "123 Main St", City = "Anytown", State = "CA", Zip = "12345" },
                InsuranceProvider = "Insurance Co.",
                InsurancePolicyNumber = "1234567890"
            };
            var address = new Address("123 Main St", "Anytown", "CA", "12345");
            var patient = Patient.Create(respondPatientDto.Id, respondPatientDto.FullName, respondPatientDto.BirthDate, address,
                respondPatientDto.PhoneNumber, respondPatientDto.Email, respondPatientDto.InsuranceProvider,
                respondPatientDto.InsurancePolicyNumber, _medicalRecordObserver, _medicalRecordNotifier);

            var subscriptions = new[] { subscriptionDto };

            _mediator.Send(Arg.Any<GetAllSubscriptionsByMedicalRecordIdQuery>(), Arg.Any<CancellationToken>())
                .Returns(subscriptions);

            _mediator.Send(Arg.Any<GetPatientByIdWithAddressQuery>(), Arg.Any<CancellationToken>())
                .Returns(respondPatientDto);

            _mapper.Map<Patient>(Arg.Any<RespondPatientDto>(), Arg.Any<Action<IMappingOperationOptions>>())
                .Returns(patient);

            // Act
            await _subscriptionService.ProcessMedicalRecordSubscriptions(medicalRecordId, medicalRecordObserver, medicalRecordNotifier, CancellationToken.None);

            // Assert
            _medicalRecordNotifier.Received(1).Subscribe();
        }

        [Test]
        public async Task ProcessMedicalRecordSubscriptions_WithException_LogsError()
        {
            // Arrange
            var medicalRecordId = Guid.NewGuid();
            var medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
            var medicalRecordNotifier = Substitute.For<IMedicalRecordNotifier>();
            _mediator.Send(Arg.Any<GetAllSubscriptionsByMedicalRecordIdQuery>(), Arg.Any<CancellationToken>())
                .Throws<Exception>();

            // Act
            await _subscriptionService.ProcessMedicalRecordSubscriptions(medicalRecordId, medicalRecordObserver, medicalRecordNotifier, CancellationToken.None);

            // Assert
            _logger.Received(1).Log(Arg.Any<string>());
        }

        [Test]
        public async Task ProcessMedicalRecordSubscriptions_MapsPatient()
        {
            // Arrange
            var medicalRecordId = Guid.NewGuid();
            var medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
            var medicalRecordNotifier = Substitute.For<IMedicalRecordNotifier>();
            var subscriptionDto = new SubscriptionDto
            {
                Id = 123,
                PatientId = Guid.NewGuid(),
                MedicalRecordId = medicalRecordId,
                SubscriptionType = SubscriptionType.Notifier.ToString()
            };
            var respondPatientDto = new RespondPatientDto
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                AddressId = 123,
                PhoneNumber = "123-456-7890",
                Email = "johndoe@example.com",
                Address = new AddressDto { Id = 123, Street = "123 Main St", City = "Anytown", State = "CA", Zip = "12345" },
                InsuranceProvider = "Insurance Co.",
                InsurancePolicyNumber = "1234567890"
            };

            var subscriptions = new[] { subscriptionDto };

            _mediator.Send(Arg.Any<GetAllSubscriptionsByMedicalRecordIdQuery>(), Arg.Any<CancellationToken>())
                .Returns(subscriptions);

            _mediator.Send(Arg.Any<GetPatientByIdWithAddressQuery>(), Arg.Any<CancellationToken>())
                .Returns(respondPatientDto);

            // Act
            await _subscriptionService.ProcessMedicalRecordSubscriptions(medicalRecordId, medicalRecordObserver, medicalRecordNotifier, CancellationToken.None);

            // Assert
            _mapper.Received(1).Map<Patient>(Arg.Any<RespondPatientDto>(), Arg.Any<Action<IMappingOperationOptions>>());
        }

        [Test]
        public async Task ProcessMedicalRecordSubscriptions_MapsPatientWithMedicalRecordNotifier()
        {
            // Arrange
            var medicalRecordId = Guid.NewGuid();
            var medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
            var medicalRecordNotifier = Substitute.For<IMedicalRecordNotifier>();
            var subscriptionDto = new SubscriptionDto
            {
                Id = 123,
                PatientId = Guid.NewGuid(),
                MedicalRecordId = medicalRecordId,
                SubscriptionType = SubscriptionType.Notifier.ToString()
            };
            var respondPatientDto = new RespondPatientDto
            {
                Id = Guid.NewGuid(),
                FullName = "John Doe",
                BirthDate = DateOnly.FromDateTime(DateTime.Now),
                AddressId = 123,
                PhoneNumber = "123-456-7890",
                Email = "johndoe@example.com",
                Address = new AddressDto { Id = 123, Street = "123 Main St", City = "Anytown", State = "CA", Zip = "12345" },
                InsuranceProvider = "Insurance Co.",
                InsurancePolicyNumber = "1234567890"
            };
            var address = new Address("123 Main St", "Anytown", "CA", "12345");
            var patient = Patient.Create(respondPatientDto.Id, respondPatientDto.FullName, respondPatientDto.BirthDate, address,
                respondPatientDto.PhoneNumber, respondPatientDto.Email, respondPatientDto.InsuranceProvider,
                respondPatientDto.InsurancePolicyNumber, _medicalRecordObserver, _medicalRecordNotifier);

            var subscriptions = new[] { subscriptionDto };

            _mediator.Send(Arg.Any<GetAllSubscriptionsByMedicalRecordIdQuery>(), Arg.Any<CancellationToken>())
                .Returns(subscriptions);

            _mediator.Send(Arg.Any<GetPatientByIdWithAddressQuery>(), Arg.Any<CancellationToken>())
                .Returns(respondPatientDto);

            _mapper.Map<Patient>(Arg.Is<RespondPatientDto>(dto => dto.Id == respondPatientDto.Id), opts =>
            {
                opts.Items["medicalRecordObserver"].Should().BeSameAs(medicalRecordObserver);
                opts.Items["medicalRecordNotifier"].Should().BeSameAs(medicalRecordNotifier);
            })
            .Returns(patient);

            // Act
            await _subscriptionService.ProcessMedicalRecordSubscriptions(medicalRecordId, medicalRecordObserver, medicalRecordNotifier, CancellationToken.None);

            // Assert
            _mapper.Received(1).Map<Patient>(Arg.Is<RespondPatientDto>(dto => dto.Id == respondPatientDto.Id),
                Arg.Any<Action<IMappingOperationOptions>>());
        }

        [Test]
        public async Task SubscribePatientToMedicalRecordUpdatesAsync_SuccessfulSubscription()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var medicalRecordId = Guid.NewGuid();

            // Act
            await _subscriptionService.SubscribePatientToMedicalRecordUpdatesAsync(patientId, medicalRecordId, CancellationToken.None);

            // Assert
            await _mediator.Received(1).Send(Arg.Is<CreateSubscriptionCommand>(cmd =>
                cmd.SubscriptionDto.PatientId == patientId &&
                cmd.SubscriptionDto.MedicalRecordId == medicalRecordId &&
                cmd.SubscriptionDto.SubscriptionType == SubscriptionType.Observer.ToString()), Arg.Any<CancellationToken>());
            await _transactionManager.Received(1).CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task SubscribePatientToMedicalRecordUpdatesAsync_WithException_LogsErrorAndThrowsDatabaseException()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var medicalRecordId = Guid.NewGuid();
            var exception = new Exception("Test exception");

            _mediator.Send(Arg.Any<CreateSubscriptionCommand>(), Arg.Any<CancellationToken>()).Throws(exception);

            // Act
            var action = async () => await _subscriptionService.SubscribePatientToMedicalRecordUpdatesAsync(patientId, medicalRecordId, CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<DatabaseException>()
                .WithMessage("Error subscribe patient to medical record updates");
            _logger.Received(1).Log(Arg.Is<string>(msg => msg.Contains("Error creating subscription")));
        }

        [Test]
        public async Task UnsubscribePatientFromMedicalRecordUpdatesAsync_SuccessfulUnsubscription()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var medicalRecordId = Guid.NewGuid();

            // Act
            await _subscriptionService.UnsubscribePatientFromMedicalRecordUpdatesAsync(patientId, medicalRecordId, CancellationToken.None);

            // Assert
            await _mediator.Received(1)
                .Send(
                    Arg.Is<DeleteSubscriptionCommand>(cmd =>
                        cmd.PatientId == patientId && cmd.MedicalRecordId == medicalRecordId &&
                        cmd.SubscriptionType == SubscriptionType.Observer.ToString()), Arg.Any<CancellationToken>());
            await _transactionManager.Received(1).CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task UnsubscribePatientFromMedicalRecordUpdatesAsync_WithException_LogsErrorAndThrowsDatabaseException()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var medicalRecordId = Guid.NewGuid();
            var exception = new Exception("Test exception");

            _mediator.Send(Arg.Any<DeleteSubscriptionCommand>(), Arg.Any<CancellationToken>()).Throws(exception);

            // Act
            Func<Task> action = async () => await _subscriptionService.UnsubscribePatientFromMedicalRecordUpdatesAsync(patientId, medicalRecordId, CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<DatabaseException>()
                .WithMessage("Error unsubscribe patient to medical record updates");
            _logger.Received(1).Log(Arg.Is<string>(msg => msg.Contains("Error deleting subscription")));
        }

        [Test]
        public async Task SubscribePatientToMedicalRecordNotificationAsync_SuccessfulSubscription()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var medicalRecordId = Guid.NewGuid();

            // Act
            await _subscriptionService.SubscribePatientToMedicalRecordNotificationAsync(patientId, medicalRecordId, CancellationToken.None);

            // Assert
            await _mediator.Received(1).Send(
                Arg.Is<CreateSubscriptionCommand>(cmd =>
                    cmd.SubscriptionDto.PatientId == patientId && cmd.SubscriptionDto.MedicalRecordId == medicalRecordId &&
                    cmd.SubscriptionDto.SubscriptionType == SubscriptionType.Notifier.ToString()),
                Arg.Any<CancellationToken>());
            await _transactionManager.Received(1).CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task SubscribePatientToMedicalRecordNotificationAsync_WithException_LogsErrorAndThrowsDatabaseException()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var medicalRecordId = Guid.NewGuid();
            var exception = new Exception("Test exception");

            _mediator.Send(Arg.Any<CreateSubscriptionCommand>(), Arg.Any<CancellationToken>()).Throws(exception);

            // Act
            Func<Task> action = async () => await _subscriptionService.SubscribePatientToMedicalRecordNotificationAsync(patientId, medicalRecordId, CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<DatabaseException>()
                .WithMessage("Error subscribe patient to medical record updates");
        }

        [Test]
        public async Task UnsubscribePatientFromMedicalRecordNotificationAsync_SuccessfulUnsubscription()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var medicalRecordId = Guid.NewGuid();

            // Act
            await _subscriptionService.UnsubscribePatientFromMedicalRecordNotificationAsync(patientId, medicalRecordId, CancellationToken.None);

            // Assert
            await _mediator.Received(1).Send(Arg.Is<DeleteSubscriptionCommand>(cmd => cmd.PatientId == patientId && cmd.MedicalRecordId == medicalRecordId && cmd.SubscriptionType == SubscriptionType.Notifier.ToString()), Arg.Any<CancellationToken>());
            await _transactionManager.Received(1).CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task UnsubscribePatientFromMedicalRecordNotificationAsync_WithException_LogsErrorAndThrowsDatabaseException()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var medicalRecordId = Guid.NewGuid();
            var exception = new Exception("Test exception");

            _mediator.Send(Arg.Any<DeleteSubscriptionCommand>(), Arg.Any<CancellationToken>()).Throws(exception);

            // Act
            Func<Task> action = async () => await _subscriptionService.UnsubscribePatientFromMedicalRecordNotificationAsync(patientId, medicalRecordId, CancellationToken.None);

            // Assert
            await action.Should().ThrowAsync<DatabaseException>()
                .WithMessage("Error unsubscribe patient to medical record updates");
        }
    }
}
