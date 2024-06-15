using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public DeleteAddressCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Handle(DeleteAddressCommand command, CancellationToken cancellationToken)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        var addressEntity = await _context.AddressEntities.FindAsync(command.Id, cancellationToken);
        if (addressEntity != null) _context.AddressEntities.Remove(addressEntity);
    }
}