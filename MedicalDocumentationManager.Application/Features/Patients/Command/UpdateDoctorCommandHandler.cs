using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Patients.Command;

public sealed class UpdateDoctorCommandHandler : ICommandHandler<UpdatePatientCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public UpdateDoctorCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
    {
        var patient = await _context
            .PatientEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (patient is null) return PatientErrors.NotFound(command.Id);

        patient.FullName = command.Name;
        patient.BirthDate = command.BirthDate;
        patient.PhoneNumber = command.PhoneNumber;
        patient.Email = command.Email;
        patient.AddressId = command.AddressId;
        patient.InsuranceProvider = command.InsuranceProvider;
        patient.InsurancePolicyNumber = command.InsurancePolicyNumber;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(patient);
    }
}