using FluentValidation;

namespace MedicalDocumentationManager.DTOs.RequestsDTOs.validators;

public class RequestDoctorDtoValidator : AbstractValidator<RequestDoctorDto>
{
    private const int MaxLengthTextPropertyLength = 255;
    private const int MaxLengthRoomNumberPropertyLength = 15;
        
    public RequestDoctorDtoValidator()
    {
        RuleFor(dto => dto.FullName)
            .NotEmpty().WithMessage("Full name cannot be empty.")
            .MaximumLength(MaxLengthTextPropertyLength).WithMessage($"Full name cannot exceed {MaxLengthTextPropertyLength} characters.");

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

        RuleFor(dto => dto.Specialization)
            .NotEmpty().WithMessage("Specialization cannot be empty.")
            .MaximumLength(MaxLengthTextPropertyLength).WithMessage($"Specialization cannot exceed {MaxLengthTextPropertyLength} characters.");

        RuleFor(dto => dto.ExperienceInYears)
            .NotEmpty().WithMessage("Experience in years cannot be empty.")
            .GreaterThan(0).WithMessage("Experience in years must be greater than zero.");

        RuleFor(dto => dto.Education)
            .NotEmpty().WithMessage("Education cannot be empty.")
            .MaximumLength(MaxLengthTextPropertyLength).WithMessage($"Education cannot exceed {MaxLengthTextPropertyLength} characters.");

        RuleFor(dto => dto.RoomNumber)
            .NotEmpty().WithMessage("Room number cannot be empty.")
            .MaximumLength(MaxLengthRoomNumberPropertyLength).WithMessage($"Room number cannot exceed {MaxLengthRoomNumberPropertyLength} characters.");
    }
    
    private bool BeValidBirthDate(DateOnly birthDate)
    {
        return birthDate < DateOnly.FromDateTime(DateTime.Today);
    }
}