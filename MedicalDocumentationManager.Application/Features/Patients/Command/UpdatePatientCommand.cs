using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.Patients.Command;

public sealed record UpdatePatientCommand(Guid Id, string Name, DateOnly BirthDate, string PhoneNumber, string Email,
    long AddressId, string InsuranceProvider, string InsurancePolicyNumber) : ICommand;