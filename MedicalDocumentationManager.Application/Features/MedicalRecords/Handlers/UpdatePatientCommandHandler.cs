using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.MedicalRecords.Handlers;

public sealed class UpdatePatientCommandHandler : ICommandHandler<UpdateMedicalRecordCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public UpdatePatientCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(UpdateMedicalRecordCommand command, CancellationToken cancellationToken)
    {
        var doctor = await _context
            .MedicalRecordEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (doctor is null) return MedicalRecordsErrors.NotFound(command.Id);

        doctor.PatientId = command.PatientId;
        doctor.DoctorId = command.DoctorId;
        doctor.Record = command.Record;
        doctor.CreatedAt = command.CreatedAt;
        doctor.UpdatedAt = command.UpdatedAt;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(doctor);
    }
}