using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, AddressDto>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAddressCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<AddressDto> Handle(UpdateAddressCommand command, CancellationToken cancellationToken = default)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        var addressEntity = _mapper.Map<AddressEntity>(command.AddressDto);
        addressEntity.Id = command.Id;

        _context.AddressEntities.Update(addressEntity);

        return Task.FromResult(_mapper.Map<AddressDto>(addressEntity));
    }
}