using FluentValidation;

namespace MedicalDocumentationManager.DTOs.RequestsDTOs.validators;

public class RequestSubscriptionDtoValidator : AbstractValidator<RequestSubscriptionDto>
{
    private const int MaxLengthTextPropertyLength = 50;

    public RequestSubscriptionDtoValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty().WithMessage("PatientId is required.")
            .Must(id => id != Guid.Empty).WithMessage("PatientId cannot be an empty GUID.");

        RuleFor(x => x.MedicalRecordId)
            .NotEmpty().WithMessage("MedicalRecordId is required.")
            .Must(id => id != Guid.Empty).WithMessage("MedicalRecordId cannot be an empty GUID.");

        RuleFor(x => x.SubscriptionType)
            .NotEmpty().WithMessage("SubscriptionType is required.")
            .MaximumLength(MaxLengthTextPropertyLength)
            .WithMessage($"SubscriptionType must not exceed {MaxLengthTextPropertyLength} characters.");
    }
}