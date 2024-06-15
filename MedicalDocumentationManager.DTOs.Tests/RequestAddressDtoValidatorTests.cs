using FluentValidation.TestHelper;
using MedicalDocumentationManager.DTOs.RequestsDTOs.validators;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.Tests;

[TestFixture]
public class RequestAddressDtoValidatorTests
{
    private RequestAddressDtoValidator _validator = null!;

    [SetUp]
    public void Setup()
    {
        _validator = new RequestAddressDtoValidator();
    }

    [Test]
    public void Should_Have_Error_When_Street_Is_Empty()
    {
        var model = new AddressDto { Street = string.Empty, City = "Some City", State = "Some State", Zip = "12345" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Street)
            .WithErrorMessage("Street is required.");
    }

    [Test]
    public void Should_Have_Error_When_Street_Exceeds_Max_Length()
    {
        var model = new AddressDto { Street = new string('a', 256), City = "Some City", State = "Some State", Zip = "12345" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Street)
            .WithErrorMessage("Street must not exceed 255 characters.");
    }

    [Test]
    public void Should_Have_Error_When_City_Is_Empty()
    {
        var model = new AddressDto { Street = "Some Street", City = string.Empty, State = "Some State", Zip = "12345" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.City)
            .WithErrorMessage("City is required.");
    }

    [Test]
    public void Should_Have_Error_When_City_Exceeds_Max_Length()
    {
        var model = new AddressDto { Street = "Some Street", City = new string('a', 256), State = "Some State", Zip = "12345" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.City)
            .WithErrorMessage("City must not exceed 255 characters.");
    }

    [Test]
    public void Should_Have_Error_When_State_Is_Empty()
    {
        var model = new AddressDto { Street = "Some Street", City = "Some City", State = string.Empty, Zip = "12345" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.State)
            .WithErrorMessage("State is required.");
    }

    [Test]
    public void Should_Have_Error_When_State_Exceeds_Max_Length()
    {
        var model = new AddressDto { Street = "Some Street", City = "Some City", State = new string('a', 256), Zip = "12345" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.State)
            .WithErrorMessage("State must not exceed 255 characters.");
    }

    [Test]
    public void Should_Have_Error_When_Zip_Is_Empty()
    {
        var model = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = string.Empty };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Zip)
            .WithErrorMessage("Zip is required.");
    }

    [Test]
    public void Should_Have_Error_When_Zip_Is_Invalid()
    {
        var model = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "1234" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Zip)
            .WithErrorMessage("Zip must be a valid postal code.");
    }

    [Test]
    public void Should_Not_Have_Error_When_Address_Is_Valid()
    {
        var model = new AddressDto { Street = "Some Street", City = "Some City", State = "Some State", Zip = "12345" };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}