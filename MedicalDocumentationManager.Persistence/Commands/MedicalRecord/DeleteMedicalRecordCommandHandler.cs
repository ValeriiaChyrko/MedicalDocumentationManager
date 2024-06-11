using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

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
        await _context
            .MedicalRecordEntities
            .Where(t => t.Id == command.Id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}