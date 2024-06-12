using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public sealed class GetAllAddressesQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllAddressesQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondAddressDto?> Handle(GetAddressIfExistsQuery query, CancellationToken cancellationToken)
    {
        var addressEntity = await _context.AddressEntities
            .FirstOrDefaultAsync(a =>
                    a.Street == query.RequestAddressDto.Street &&
                    a.City == query.RequestAddressDto.City &&
                    a.State == query.RequestAddressDto.State &&
                    a.Zip == query.RequestAddressDto.Zip,
                cancellationToken);

        return addressEntity != null ? _mapper.Map<RespondAddressDto>(addressEntity) : null;
    }
}