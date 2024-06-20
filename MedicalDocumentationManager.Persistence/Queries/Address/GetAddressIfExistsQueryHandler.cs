using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public sealed class GetAddressIfExistsQueryHandler : IRequestHandler<GetAddressIfExistsQuery, AddressDto?>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAddressIfExistsQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AddressDto?> Handle(GetAddressIfExistsQuery query, CancellationToken cancellationToken)
    {
        var addressEntity = await _context
            .AddressEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(a =>
                    a.Street == query.AddressDto.Street &&
                    a.City == query.AddressDto.City &&
                    a.State == query.AddressDto.State &&
                    a.Zip == query.AddressDto.Zip,
                cancellationToken);

        return addressEntity != null ? _mapper.Map<AddressDto>(addressEntity) : null;
    }
}