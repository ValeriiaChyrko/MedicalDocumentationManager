using MedicalDocumentationManager.Database.Contexts.Abstractions;

namespace MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

public sealed class DeleteMedicalRecordCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteMedicalRecordCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(DeleteMedicalRecordCommand command, CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        
        var medicalRecordEntity = await _context.MedicalRecordEntities.FindAsync(command.Id, cancellationToken);
        if (medicalRecordEntity!= null)
        {
            _context.MedicalRecordEntities.Remove(medicalRecordEntity);
        }
    }
}