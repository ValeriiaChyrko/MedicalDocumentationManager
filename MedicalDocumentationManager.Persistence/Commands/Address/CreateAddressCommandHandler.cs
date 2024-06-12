using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

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

    public async Task<RespondAddressDto> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
    {
        var addressEntity = _mapper.Map<AddressEntity>(command.RequestAddressDto);
        var addedEntity = await _context.AddressEntities.AddAsync(addressEntity, cancellationToken);

        return _mapper.Map<RespondAddressDto>(addedEntity.Entity);
    }
}