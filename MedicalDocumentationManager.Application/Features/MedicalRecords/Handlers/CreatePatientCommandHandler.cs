using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.MedicalRecords.Handlers;

public sealed class CreatePatientCommandHandler : ICommandHandler<CreateMedicalRecordCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public CreatePatientCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(CreateMedicalRecordCommand command, CancellationToken cancellationToken)
    {
        var medicalRecord = new MedicalRecordEntity
        {
            Id = command.Id,
            PatientId = command.PatientId,
            DoctorId = command.DoctorId,
            Record = command.Record,
            CreatedAt = command.CreatedAt,
            UpdatedAt = command.UpdatedAt
        };

        _context
            .MedicalRecordEntities
            .Add(medicalRecord);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(medicalRecord);
    }
}