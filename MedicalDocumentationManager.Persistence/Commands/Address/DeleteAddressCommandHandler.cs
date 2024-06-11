using MedicalDocumentationManager.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed class DeleteAddressCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteAddressCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(DeleteAddressCommand command, CancellationToken cancellationToken)
    {
        await _context
            .AddressEntities
            .Where(t => t.Id == command.Id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }
}