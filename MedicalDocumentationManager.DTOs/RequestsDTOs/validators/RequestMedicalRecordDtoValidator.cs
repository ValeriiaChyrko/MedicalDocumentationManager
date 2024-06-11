using FluentValidation;

namespace MedicalDocumentationManager.DTOs.RequestsDTOs.validators;

public class RequestMedicalRecordDtoValidator : AbstractValidator<RequestMedicalRecordDto>
{
    private const int MaxLengthRecordPropertyLength = 512;
    
    public RequestMedicalRecordDtoValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty().WithMessage("PatientId is required.")
            .Must(id => id != Guid.Empty).WithMessage("PatientId cannot be an empty GUID.");

        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("DoctorId is required.")
            .Must(id => id != Guid.Empty).WithMessage("DoctorId cannot be an empty GUID.");

        RuleFor(x => x.Record)
            .NotEmpty().WithMessage("Record is required.")
            .MaximumLength(MaxLengthRecordPropertyLength).WithMessage($"Record must not exceed {MaxLengthRecordPropertyLength} characters.");

        RuleFor(x => x.CreatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("CreatedAt cannot be in the future.");

        RuleFor(x => x.UpdatedAt)
            .GreaterThanOrEqualTo(x => x.CreatedAt).WithMessage("UpdatedAt must be greater than or equal to CreatedAt.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("UpdatedAt cannot be in the future.");
    }
}