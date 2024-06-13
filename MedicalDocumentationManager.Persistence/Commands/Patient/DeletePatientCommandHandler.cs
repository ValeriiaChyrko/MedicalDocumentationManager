using MedicalDocumentationManager.Database.Contexts.Abstractions;

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
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        
        var patientEntity = await _context.PatientEntities.FindAsync(command.Id, cancellationToken);
        if (patientEntity!= null)
        {
            _context.PatientEntities.Remove(patientEntity);
        }
    }
}