using FluentValidation.TestHelper;
using MedicalDocumentationManager.DTOs.RequestsDTOs.validators;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.Tests
{
    [TestFixture]
    public class RequestSubscriptionDtoValidatorTests
    {
        private RequestSubscriptionDtoValidator _validator = null!;

        [SetUp]
        public void Setup()
        {
            _validator = new RequestSubscriptionDtoValidator();
        }

        [Test]
        public void Should_Have_Error_When_PatientId_Is_Empty()
        {
            var model = new SubscriptionDto { PatientId = Guid.Empty, MedicalRecordId = Guid.NewGuid(), SubscriptionType = "Monthly" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PatientId)
                .WithErrorMessage("PatientId cannot be an empty GUID.");
        }

        [Test]
        public void Should_Have_Error_When_MedicalRecordId_Is_Empty()
        {
            var model = new SubscriptionDto { PatientId = Guid.NewGuid(), MedicalRecordId = Guid.Empty, SubscriptionType = "Monthly" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.MedicalRecordId)
                .WithErrorMessage("MedicalRecordId cannot be an empty GUID.");
        }

        [Test]
        public void Should_Have_Error_When_SubscriptionType_Is_Empty()
        {
            var model = new SubscriptionDto { PatientId = Guid.NewGuid(), MedicalRecordId = Guid.NewGuid(), SubscriptionType = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.SubscriptionType)
                .WithErrorMessage("SubscriptionType is required.");
        }

        [Test]
        public void Should_Have_Error_When_SubscriptionType_Exceeds_Max_Length()
        {
            var model = new SubscriptionDto { PatientId = Guid.NewGuid(), MedicalRecordId = Guid.NewGuid(), SubscriptionType = new string('a', 51) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.SubscriptionType)
                .WithErrorMessage("SubscriptionType must not exceed 50 characters.");
        }

        [Test]
        public void Should_Not_Have_Error_When_RequestSubscriptionDto_Is_Valid()
        {
            var model = new SubscriptionDto
            {
                PatientId = Guid.NewGuid(),
                MedicalRecordId = Guid.NewGuid(),
                SubscriptionType = "Monthly"
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
