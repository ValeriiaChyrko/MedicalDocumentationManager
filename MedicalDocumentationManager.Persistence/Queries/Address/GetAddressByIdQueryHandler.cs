using AutoMapper;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public sealed class GetAddressByIdQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAddressByIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondAddressDto?> Handle(GetAddressByIdQuery query, CancellationToken cancellationToken)
    {
        var addressEntity = await _context.AddressEntities.FindAsync(new object[] { query.Id }, cancellationToken);

        return addressEntity != null ? _mapper.Map<RespondAddressDto>(addressEntity) : null;
    }
}