using AutoMapper;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed class CreateAddressCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public CreateAddressCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AddressDto> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        
        var addressEntity = _mapper.Map<AddressEntity>(command.AddressDto);
        var addedEntity = await _context.AddressEntities.AddAsync(addressEntity, cancellationToken);
        _context.DetachEntity(addressEntity);

        return _mapper.Map<AddressDto>(addedEntity.Entity);
    }
}