using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Addresses.Commands;

public sealed class UpdateAddressCommandHandler : ICommandHandler<UpdateAddressCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public UpdateAddressCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(UpdateAddressCommand command, CancellationToken cancellationToken)
    {
        var address = await _context
            .AddressEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (address is null) return AddressErrors.NotFound(command.Id);

        address.Street = command.Street;
        address.City = command.City;
        address.State = command.State;
        address.Zip = command.Zip;

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(address);
    }
}