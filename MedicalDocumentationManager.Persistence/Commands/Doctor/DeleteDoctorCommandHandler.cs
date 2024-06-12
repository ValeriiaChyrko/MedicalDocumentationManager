using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Commands.Doctor;

public sealed class DeleteDoctorCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteDoctorCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(DeleteDoctorCommand command, CancellationToken cancellationToken)
    {
        await _context
            .DoctorEntities
            .Where(t => t.Id == command.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}