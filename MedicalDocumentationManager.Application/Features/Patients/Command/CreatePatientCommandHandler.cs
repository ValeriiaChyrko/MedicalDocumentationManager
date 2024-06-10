using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Patients.Command;

public sealed class CreatePatientCommandHandler : ICommandHandler<CreatePatientCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public CreatePatientCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
    {
        var patient = new PatientEntity
        {
            Id = command.Id,
            FullName = command.Name,
            BirthDate = command.BirthDate,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            AddressId = command.AddressId,
            InsuranceProvider = command.InsuranceProvider,
            InsurancePolicyNumber = command.InsurancePolicyNumber
        };

        _context
            .PatientEntities
            .Add(patient);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(patient);
    }
}