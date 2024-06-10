using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Application.Features.Doctors.Commands;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.MedicalRecords.Handlers;

public sealed class DeleteMedicalRecordCommandHandler : ICommandHandler<DeleteDoctorCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteMedicalRecordCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(DeleteDoctorCommand command, CancellationToken cancellationToken)
    {
        var medicalRecord = await _context
            .MedicalRecordEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (medicalRecord is null) return MedicalRecordsErrors.NotFound(command.Id);

        _context
            .MedicalRecordEntities
            .Remove(medicalRecord);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}