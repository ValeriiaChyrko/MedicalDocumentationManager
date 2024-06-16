using MedicalDocumentationManager.Application.Implementations;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Commands.MedicalRecord;
using MedicalDocumentationManager.Persistence.Queries.MedicalRecord;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalDocumentationManager.Application.Tests
{
    [TestFixture]
    public class MedicalRecordServiceTests
    {
        private IMediator _mediator = null!;
        private IDatabaseTransactionManager _transactionManager = null!;
        private ILogger _logger = null!;
        private MedicalRecordService _medicalRecordService = null!;

        [SetUp]
        public void SetUp()
        {
            _mediator = Substitute.For<IMediator>();
            _transactionManager = Substitute.For<IDatabaseTransactionManager>();
            _logger = Substitute.For<ILogger>();
            var mapper = Substitute.For<IMapper>();
            _medicalRecordService = new MedicalRecordService(_logger, _transactionManager, _mediator, mapper);
        }

        [Test]
        public async Task CreateMedicalRecordAsync_ReturnsRespondMedicalRecordDto_WhenCalled()
        {
            // Arrange
            var requestMedicalRecordDto = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Record = "Test Record",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var respondMedicalRecordDto = new RespondMedicalRecordDto
            {
                Id = Guid.NewGuid(),
                PatientId = requestMedicalRecordDto.PatientId,
                DoctorId = requestMedicalRecordDto.DoctorId,
                Record = requestMedicalRecordDto.Record,
                CreatedAt = requestMedicalRecordDto.CreatedAt,
                UpdatedAt = requestMedicalRecordDto.UpdatedAt
            };
            _mediator.Send(Arg.Any<CreateMedicalRecordCommand>()).Returns(respondMedicalRecordDto);

            // Act
            var result = await _medicalRecordService.CreateMedicalRecordAsync(requestMedicalRecordDto);

            // Assert
            result.Should().BeEquivalentTo(respondMedicalRecordDto);
            await _transactionManager
                .Received(1)
                .CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task CreateMedicalRecordAsync_ThrowsDatabaseException_WhenMediatorSendThrowsException()
        {
            // Arrange
            var requestMedicalRecordDto = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Record = "Test Record",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _mediator.Send(Arg.Any<CreateMedicalRecordCommand>()).Throws<Exception>();

            // Act and Assert
            await FluentActions.Invoking(async () => await _medicalRecordService.CreateMedicalRecordAsync(requestMedicalRecordDto))
                .Should().ThrowAsync<DatabaseException>();
            await _transactionManager
                .Received(1)
                .RollbackAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task UpdateMedicalRecordAsync_ThrowsDatabaseException_WhenMediatorSendThrowsException()
        {
            // Arrange
            var requestMedicalRecordDto = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Record = "Test Record",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            
            _mediator.Send(Arg.Any<UpdateMedicalRecordCommand>()).Throws<Exception>();

            // Act
            Assert.ThrowsAsync<DatabaseException>(() =>
                _medicalRecordService.UpdateMedicalRecordAsync(Guid.NewGuid(), requestMedicalRecordDto));

            // Assert
            await _transactionManager.Received(1).BeginTransactionAsync();
            var transaction = _transactionManager.Received().BeginTransactionAsync().Result;
            await transaction.Received(1).RollbackAsync(Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task DeleteMedicalRecordAsync_DoesNotThrowException_WhenCalled()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mediator.Send(Arg.Any<DeleteMedicalRecordCommand>()).Returns(Task.CompletedTask);

            // Act and Assert
            await FluentActions.Invoking(async () => await _medicalRecordService.DeleteMedicalRecordAsync(id))
                .Should().NotThrowAsync();
            await _transactionManager
                .Received(1)
                .CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task DeleteMedicalRecordAsync_ThrowsDatabaseException_WhenMediatorSendThrowsException()
        {
            // Arrange
            var id = Guid.NewGuid();
            
            _mediator.Send(Arg.Any<DeleteMedicalRecordCommand>()).Throws<Exception>();

            // Act and Assert
            Assert.ThrowsAsync<DatabaseException>(() => _medicalRecordService.DeleteMedicalRecordAsync(id));
            await _transactionManager
                .DidNotReceive()
                .RollbackAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task GetMedicalRecordByIdAsync_ReturnsRespondMedicalRecordDto_WhenCalled()
        {
            // Arrange
            var id = Guid.NewGuid();
            var respondMedicalRecordDto = new RespondMedicalRecordDto
            {
                Id = id,
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Record = "Test Record",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _mediator.Send(Arg.Any<GetMedicalRecordByIdQuery>()).Returns(respondMedicalRecordDto);

            // Act
            var result = await _medicalRecordService.GetMedicalRecordByIdAsync(id);

            // Assert
            result.Should().BeEquivalentTo(respondMedicalRecordDto);
        }

        [Test]
        public async Task GetMedicalRecordByIdAsync_ThrowsDatabaseException_WhenMediatorSendThrowsException()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mediator.Send(Arg.Any<GetMedicalRecordByIdQuery>()).Throws<Exception>();

            // Act and Assert
            await FluentActions.Invoking(async () => await _medicalRecordService.GetMedicalRecordByIdAsync(id))
               .Should().ThrowAsync<DatabaseException>();
        }

        [Test]
        public async Task GetMedicalRecordsAsync_ReturnsIReadOnlyListRespondMedicalRecordDto_WhenCalled()
        {
            // Arrange
            var respondMedicalRecordDtos = new List<RespondMedicalRecordDto>
            {
                new RespondMedicalRecordDto
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(),
                    DoctorId = Guid.NewGuid(),
                    Record = "Test Record",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };
            _mediator.Send(Arg.Any<GetAllMedicalRecordsQuery>()).Returns(respondMedicalRecordDtos);

            // Act
            var result = await _medicalRecordService.GetMedicalRecordsAsync();

            // Assert
            result.Should().BeEquivalentTo(respondMedicalRecordDtos);
        }

        [Test]
        public async Task GetMedicalRecordsAsync_ThrowsDatabaseException_WhenMediatorSendThrowsException()
        {
            // Arrange
            _mediator.Send(Arg.Any<GetAllMedicalRecordsQuery>()).Throws<Exception>();

            // Act and Assert
            await FluentActions.Invoking(async () => await _medicalRecordService.GetMedicalRecordsAsync())
              .Should().ThrowAsync<DatabaseException>();
        }

        [Test]
        public async Task GetMedicalRecordsByPatientAsync_ReturnsIReadOnlyListRespondMedicalRecordDto_WhenCalled()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            var respondMedicalRecordDtos = new List<RespondMedicalRecordDto>
            {
                new RespondMedicalRecordDto
                {
                    Id = Guid.NewGuid(),
                    PatientId = patientId,
                    DoctorId = Guid.NewGuid(),
                    Record = "Test Record",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };
            _mediator.Send(Arg.Any<GetAllMedicalRecordsByPatientIdQuery>()).Returns(respondMedicalRecordDtos);

            // Act
            var result = await _medicalRecordService.GetMedicalRecordsByPatientAsync(patientId);

            // Assert
            result.Should().BeEquivalentTo(respondMedicalRecordDtos);
        }

        [Test]
        public async Task GetMedicalRecordsByPatientAsync_ThrowsDatabaseException_WhenMediatorSendThrowsException()
        {
            // Arrange
            var patientId = Guid.NewGuid();
            _mediator.Send(Arg.Any<GetAllMedicalRecordsByPatientIdQuery>()).Throws<Exception>();

            // Act and Assert
            await FluentActions.Invoking(async () => await _medicalRecordService.GetMedicalRecordsByPatientAsync(patientId))
              .Should().ThrowAsync<DatabaseException>();
        }

        [Test]
        public async Task GetMedicalRecordsByDoctorAsync_ReturnsIReadOnlyListRespondMedicalRecordDto_WhenCalled()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            var respondMedicalRecordDtos = new List<RespondMedicalRecordDto>
            {
                new RespondMedicalRecordDto
                {
                    Id = Guid.NewGuid(),
                    PatientId = Guid.NewGuid(),
                    DoctorId = doctorId,
                    Record = "Test Record",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };
            _mediator.Send(Arg.Any<GetAllMedicalRecordsByDoctorIdQuery>()).Returns(respondMedicalRecordDtos);

            // Act
            var result = await _medicalRecordService.GetMedicalRecordsByDoctorAsync(doctorId);

            // Assert
            result.Should().BeEquivalentTo(respondMedicalRecordDtos);
        }

        [Test]
        public async Task GetMedicalRecordsByDoctorAsync_ThrowsDatabaseException_WhenMediatorSendThrowsException()
        {
            // Arrange
            var doctorId = Guid.NewGuid();
            _mediator.Send(Arg.Any<GetAllMedicalRecordsByDoctorIdQuery>()).Throws<Exception>();

            // Act and Assert
            await FluentActions.Invoking(async () => await _medicalRecordService.GetMedicalRecordsByDoctorAsync(doctorId))
              .Should().ThrowAsync<DatabaseException>();
        }
    }
}