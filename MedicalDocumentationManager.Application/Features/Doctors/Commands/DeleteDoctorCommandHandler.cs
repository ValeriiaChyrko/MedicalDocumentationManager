using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Doctors.Commands;

public sealed class DeleteDoctorCommandHandler : ICommandHandler<DeleteDoctorCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteDoctorCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(DeleteDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = await _context
            .DoctorEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (doctor is null) return DoctorErrors.NotFound(command.Id);

        _context
            .DoctorEntities
            .Remove(doctor);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}