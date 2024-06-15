using FluentValidation.TestHelper;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RequestsDTOs.validators;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.Tests;

[TestFixture]
public class RequestDoctorDtoValidatorTests
{
    private RequestDoctorDtoValidator _validator = null!;

    [SetUp]
    public void Setup()
    {
        _validator = new RequestDoctorDtoValidator();
    }

    [Test]
    public void Should_Have_Error_When_FullName_Is_Empty()
    {
        var model = new RequestDoctorDto { FullName = string.Empty, BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FullName)
            .WithErrorMessage("Full name cannot be empty.");
    }

    [Test]
    public void Should_Have_Error_When_FullName_Exceeds_Max_Length()
    {
        var model = new RequestDoctorDto { FullName = new string('a', 256), BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FullName)
            .WithErrorMessage("Full name cannot exceed 255 characters.");
    }

    [Test]
    public void Should_Have_Error_When_BirthDate_Is_Empty()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.BirthDate)
            .WithErrorMessage("Birth date cannot be empty.");
    }

    [Test]
    public void Should_Have_Error_When_BirthDate_Is_Invalid()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(1)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.BirthDate)
            .WithErrorMessage("Birth date must be before the current date.");
    }

    [Test]
    public void Should_Have_Error_When_Address_Is_Null()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = null, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Address)
            .WithErrorMessage("Address cannot be null.");
    }

    [Test]
    public void Should_Have_Error_When_PhoneNumber_Is_Empty()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = string.Empty, Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
            .WithErrorMessage("Phone number cannot be empty.");
    }

    [Test]
    public void Should_Have_Error_When_PhoneNumber_Is_Invalid()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "12345", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
            .WithErrorMessage("Invalid phone number format.");
    }

    [Test]
    public void Should_Have_Error_When_Email_Is_Empty()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = string.Empty, Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Email cannot be empty.");
    }

    [Test]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "invalid-email", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage("Invalid email format.");
    }

    [Test]
    public void Should_Have_Error_When_Specialization_Is_Empty()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = string.Empty, ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Specialization)
            .WithErrorMessage("Specialization cannot be empty.");
    }

    [Test]
    public void Should_Have_Error_When_Specialization_Exceeds_Max_Length()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = new string('a', 256), ExperienceInYears = 10, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Specialization)
            .WithErrorMessage("Specialization cannot exceed 255 characters.");
    }

    [Test]
    public void Should_Have_Error_When_ExperienceInYears_Is_Empty()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 0, Education = "Medical School", RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ExperienceInYears)
            .WithErrorMessage("Experience in years must be greater than zero.");
    }

    [Test]
    public void Should_Have_Error_When_Education_Is_Empty()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = string.Empty, RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Education)
            .WithErrorMessage("Education cannot be empty.");
    }

    [Test]
    public void Should_Have_Error_When_Education_Exceeds_Max_Length()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = new string('a', 256), RoomNumber = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Education)
            .WithErrorMessage("Education cannot exceed 255 characters.");
    }

    [Test]
    public void Should_Have_Error_When_RoomNumber_Is_Empty()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = string.Empty };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.RoomNumber)
            .WithErrorMessage("Room number cannot be empty.");
    }

    [Test]
    public void Should_Have_Error_When_RoomNumber_Exceeds_Max_Length()
    {
        var model = new RequestDoctorDto { FullName = "John Doe", BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)), PhoneNumber = "+1234567890", Email = "test@example.com", Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" }, Specialization = "Cardiology", ExperienceInYears = 10, Education = "Medical School", RoomNumber = new string('a', 16) };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.RoomNumber)
            .WithErrorMessage("Room number cannot exceed 15 characters.");
    }

    [Test]
    public void Should_Not_Have_Error_When_RequestDoctorDto_Is_Valid()
    {
        var model = new RequestDoctorDto
        {
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-30)),
            PhoneNumber = "+1234567890",
            Email = "test@example.com",
            Address = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" },
            Specialization = "Cardiology",
            ExperienceInYears = 10,
            Education = "Medical School",
            RoomNumber = "123"
        };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}