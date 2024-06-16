using FluentValidation.TestHelper;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RequestsDTOs.validators;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.Tests
{
    [TestFixture]
    public class RequestPatientDtoValidatorTests
    {
        private RequestPatientDtoValidator _validator = null!;

        [SetUp]
        public void Setup()
        {
            _validator = new RequestPatientDtoValidator();
        }

        [Test]
        public void Should_Have_Error_When_FullName_Is_Empty()
        {
            var model = new RequestPatientDto { FullName = string.Empty, BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FullName)
                .WithErrorMessage("Full name cannot be empty.");
        }

        [Test]
        public void Should_Have_Error_When_FullName_Exceeds_Max_Length()
        {
            var model = new RequestPatientDto { FullName = new string('a', 256), BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FullName)
                .WithErrorMessage("Full name cannot exceed 255 characters.");
        }

        [Test]
        public void Should_Have_Error_When_BirthDate_Is_Empty()
        {
            var model = new RequestPatientDto { FullName = "John Doe", PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate)
                .WithErrorMessage("Birth date cannot be empty.");
        }

        [Test]
        public void Should_Have_Error_When_BirthDate_Is_In_The_Future()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.BirthDate)
                .WithErrorMessage("Birth date must be before the current date.");
        }

        [Test]
        public void Should_Have_Error_When_Address_Is_Null()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = null!, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Address)
                .WithErrorMessage("Address cannot be null.");
        }

        [Test]
        public void Should_Have_Error_When_PhoneNumber_Is_Empty()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = string.Empty, Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
                .WithErrorMessage("Phone number cannot be empty.");
        }

        [Test]
        public void Should_Have_Error_When_PhoneNumber_Is_Invalid_Format()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "123456", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
                .WithErrorMessage("Invalid phone number format.");
        }

        [Test]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = string.Empty, Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage("Email cannot be empty.");
        }

        [Test]
        public void Should_Have_Error_When_Email_Is_Invalid_Format()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "invalid-email", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage("Invalid email format.");
        }

        [Test]
        public void Should_Have_Error_When_InsuranceProvider_Is_Empty()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = string.Empty, InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.InsuranceProvider)
                .WithErrorMessage("Insurance provider cannot be empty.");
        }

        [Test]
        public void Should_Have_Error_When_InsuranceProvider_Exceeds_Max_Length()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = new string('a', 256), InsurancePolicyNumber = "12345" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.InsuranceProvider)
                .WithErrorMessage("Insurance provider cannot exceed 255 characters.");
        }

        [Test]
        public void Should_Have_Error_When_InsurancePolicyNumber_Is_Empty()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = string.Empty };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.InsurancePolicyNumber)
                .WithErrorMessage("Insurance policy number cannot be empty.");
        }

        [Test]
        public void Should_Have_Error_When_InsurancePolicyNumber_Exceeds_Max_Length()
        {
            var model = new RequestPatientDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, InsuranceProvider = "Insurance Co", InsurancePolicyNumber = new string('a', 256) };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.InsurancePolicyNumber)
                .WithErrorMessage("Insurance policy number cannot exceed 255 characters.");
        }

        [Test]
        public void Should_Not_Have_Error_When_RequestPatientDto_Is_Valid()
        {
            var model = new RequestPatientDto
            {
                FullName = "John Doe",
                BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)),
                PhoneNumber = "+1234567890",
                Email = "test@example.com",
                Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" },
                InsuranceProvider = "Insurance Co",
                InsurancePolicyNumber = "12345"
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
