using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Commands.Patient;

public sealed class DeletePatientCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeletePatientCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(DeletePatientCommand command, CancellationToken cancellationToken)
    {
        await _context
            .PatientEntities
            .Where(t => t.Id == command.Id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}