using FluentValidation;

namespace MedicalDocumentationManager.DTOs.RequestsDTOs.validators;

public class RequestPatientDtoValidator : AbstractValidator<RequestPatientDto>
{
    private const int MaxLengthTextPropertyLength = 255;

    public RequestPatientDtoValidator()
    {
        RuleFor(dto => dto.FullName)
            .NotEmpty().WithMessage("Full name cannot be empty.")
            .MaximumLength(MaxLengthTextPropertyLength)
            .WithMessage($"Full name cannot exceed {MaxLengthTextPropertyLength} characters.");

        RuleFor(dto => dto.BirthDate)
            .NotEmpty().WithMessage("Birth date cannot be empty.")
            .Must(BeValidBirthDate).WithMessage("Birth date must be before the current date.");

        RuleFor(dto => dto.AddressId)
            .NotEmpty().WithMessage("Address ID cannot be empty.")
            .GreaterThan(0).WithMessage("Address ID must be greater than zero.");

        RuleFor(dto => dto.PhoneNumber)
            .NotEmpty().WithMessage("Phone number cannot be empty.")
            .Matches(@"^\+\d{1,3}\d{5,14}$").WithMessage("Invalid phone number format.");

        RuleFor(dto => dto.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(dto => dto.InsuranceProvider)
            .NotEmpty().WithMessage("Insurance provider cannot be empty.")
            .MaximumLength(MaxLengthTextPropertyLength)
            .WithMessage($"Insurance provider cannot exceed {MaxLengthTextPropertyLength} characters.");

        RuleFor(dto => dto.InsurancePolicyNumber)
            .NotEmpty().WithMessage("Insurance policy number cannot be empty.")
            .MaximumLength(MaxLengthTextPropertyLength)
            .WithMessage($"Insurance policy number cannot exceed {MaxLengthTextPropertyLength} characters.");
    }

    private bool BeValidBirthDate(DateOnly birthDate)
    {
        return birthDate < DateOnly.FromDateTime(DateTime.Today);
    }
}