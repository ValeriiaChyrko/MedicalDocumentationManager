using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Addresses.Commands;

public sealed class DeleteAddressCommandHandler : ICommandHandler<DeleteAddressCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteAddressCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result> Handle(DeleteAddressCommand command, CancellationToken cancellationToken)
    {
        var address = await _context
            .AddressEntities
            .FirstOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

        if (address is null) return AddressErrors.NotFound(command.Id);

        _context.AddressEntities.Remove(address);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}