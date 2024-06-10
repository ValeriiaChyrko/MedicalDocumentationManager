using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Addresses.Commands;

public sealed class CreateAddressCommandHandler : ICommandHandler<CreateAddressCommand, AddressEntity>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public CreateAddressCommandHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Result<AddressEntity>> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
    {
        var address = new AddressEntity
        {
            Street = command.Street,
            City = command.City,
            State = command.State,
            Zip = command.Zip
        };

        _context
            .AddressEntities
            .Add(address);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(address);
    }
}