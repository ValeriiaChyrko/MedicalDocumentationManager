using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Patients.Command;

public sealed class DeletePatientCommandHandler : ICommandHandler<DeletePatientCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeletePatientCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(DeletePatientCommand command, CancellationToken cancellationToken)
    {
        var patient = await _context
            .PatientEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (patient is null) return PatientErrors.NotFound(command.Id);

        _context
            .PatientEntities
            .Remove(patient);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}