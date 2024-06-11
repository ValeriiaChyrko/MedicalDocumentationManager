using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed class UpdateAddressCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAddressCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<RespondAddressDto> Handle(UpdateAddressCommand command)
    {
        var addressEntity = _mapper.Map<AddressEntity>(command.RequestAddressDto);
        addressEntity.Id = command.Id;

        _context.AddressEntities.Update(addressEntity);

        return Task.FromResult(_mapper.Map<RespondAddressDto>(addressEntity));
    }
}