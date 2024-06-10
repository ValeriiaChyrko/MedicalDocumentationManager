using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Doctors.Commands;

public sealed class UpdateDoctorCommandHandler : ICommandHandler<UpdateDoctorCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public UpdateDoctorCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = await _context
            .DoctorEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (doctor is null) return DoctorErrors.NotFound(command.Id);

        doctor.FullName = command.Name;
        doctor.BirthDate = command.BirthDate;
        doctor.PhoneNumber = command.PhoneNumber;
        doctor.Email = command.Email;
        doctor.AddressId = command.AddressId;
        doctor.Specialization = command.Specialization;
        doctor.ExperienceInYears = command.ExperienceInYears;
        doctor.Education = command.Education;
        doctor.RoomNumber = command.RoomNumber;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(doctor);
    }
}