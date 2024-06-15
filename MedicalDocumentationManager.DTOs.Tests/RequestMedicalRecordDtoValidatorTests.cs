using FluentValidation.TestHelper;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RequestsDTOs.validators;

namespace MedicalDocumentationManager.DTOs.Tests
{
    [TestFixture]
    public class RequestMedicalRecordDtoValidatorTests
    {
        private RequestMedicalRecordDtoValidator _validator = null!;

        [SetUp]
        public void Setup()
        {
            _validator = new RequestMedicalRecordDtoValidator();
        }

        [Test]
        public void Should_Have_Error_When_PatientId_Is_Empty()
        {
            var model = new RequestMedicalRecordDto
            {
                PatientId = Guid.Empty, DoctorId = Guid.NewGuid(), Record = "Some record", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PatientId)
                .WithErrorMessage("PatientId cannot be an empty GUID.");
        }

        [Test]
        public void Should_Have_Error_When_DoctorId_Is_Empty()
        {
            var model = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(), DoctorId = Guid.Empty, Record = "Some record", CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.DoctorId)
                .WithErrorMessage("DoctorId cannot be an empty GUID.");
        }

        [Test]
        public void Should_Have_Error_When_Record_Is_Empty()
        {
            var model = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(), DoctorId = Guid.NewGuid(), Record = string.Empty,
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Record)
                .WithErrorMessage("Record is required.");
        }

        [Test]
        public void Should_Have_Error_When_Record_Exceeds_Max_Length()
        {
            var model = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(), DoctorId = Guid.NewGuid(), Record = new string('a', 513),
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Record)
                .WithErrorMessage("Record must not exceed 512 characters.");
        }

        [Test]
        public void Should_Have_Error_When_CreatedAt_Is_In_The_Future()
        {
            var model = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(), DoctorId = Guid.NewGuid(), Record = "Some record",
                CreatedAt = DateTime.UtcNow.AddMinutes(1), UpdatedAt = DateTime.UtcNow.AddMinutes(1)
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.CreatedAt)
                .WithErrorMessage("CreatedAt cannot be in the future.");
        }

        [Test]
        public void Should_Have_Error_When_UpdatedAt_Is_Before_CreatedAt()
        {
            var model = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(), DoctorId = Guid.NewGuid(), Record = "Some record",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow.AddMinutes(-1)
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.UpdatedAt)
                .WithErrorMessage("UpdatedAt must be greater than or equal to CreatedAt.");
        }

        [Test]
        public void Should_Have_Error_When_UpdatedAt_Is_In_The_Future()
        {
            var model = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(), DoctorId = Guid.NewGuid(), Record = "Some record",
                CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow.AddMinutes(1)
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.UpdatedAt)
                .WithErrorMessage("UpdatedAt cannot be in the future.");
        }

        [Test]
        public void Should_Not_Have_Error_When_RequestMedicalRecordDto_Is_Valid()
        {
            var model = new RequestMedicalRecordDto
            {
                PatientId = Guid.NewGuid(),
                DoctorId = Guid.NewGuid(),
                Record = "Valid medical record",
                CreatedAt = DateTime.UtcNow.AddMinutes(-50),
                UpdatedAt = DateTime.UtcNow.AddMinutes(-50)
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}