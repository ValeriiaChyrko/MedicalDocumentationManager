using FluentValidation;

namespace MedicalDocumentationManager.DTOs.RequestsDTOs.validators;

public class RequestAddressDtoValidator : AbstractValidator<RequestAddressDto>
{
    private const int MaxLengthPropertyLength = 255;
    
    public RequestAddressDtoValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required.")
            .MaximumLength(MaxLengthPropertyLength).WithMessage($"Street must not exceed {MaxLengthPropertyLength} characters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(MaxLengthPropertyLength).WithMessage($"City must not exceed {MaxLengthPropertyLength} characters.");

        RuleFor(x => x.State)
            .NotEmpty().WithMessage("State is required.")
            .MaximumLength(MaxLengthPropertyLength).WithMessage($"State must not exceed {MaxLengthPropertyLength} characters.");

        RuleFor(x => x.Zip)
            .NotEmpty().WithMessage("Zip is required.")
            .Matches(@"^\d{5}(-\d{4})?$").WithMessage($"Zip must be a valid postal code.");
    }
}