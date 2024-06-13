using MedicalDocumentationManager.Database.Contexts.Abstractions;

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
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var doctorEntity = await _context.DoctorEntities.FindAsync(command.Id, cancellationToken);
        if (doctorEntity!= null)
        {
            _context.DoctorEntities.Remove(doctorEntity);
        }
    }
}