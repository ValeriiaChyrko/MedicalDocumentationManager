using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Doctors.Commands;

public sealed class CreateDoctorCommandHandler : ICommandHandler<CreateDoctorCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public CreateDoctorCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(CreateDoctorCommand command, CancellationToken cancellationToken)
    {
        var doctor = new DoctorEntity
        {
            Id = command.Id,
            FullName = command.Name,
            BirthDate = command.BirthDate,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            AddressId = command.AddressId,
            Specialization = command.Specialization,
            ExperienceInYears = command.ExperienceInYears,
            Education = command.Education,
            RoomNumber = command.RoomNumber
        };

        _context
            .DoctorEntities
            .Add(doctor);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(doctor);
    }
}