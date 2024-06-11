using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public sealed class GetAddressByDoctorIdQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAddressByDoctorIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondAddressDto?> Handle(GetAddressByDoctorIdQuery query, CancellationToken cancellationToken)
    {
        var addressEntity = await _context.AddressEntities
            .Include(a => a.Doctors)
            .FirstOrDefaultAsync(a =>
                    a.Doctors != null &&
                    a.Doctors.Any(p => p.Id == query.Id), 
                cancellationToken);

        return addressEntity != null ? _mapper.Map<RespondAddressDto>(addressEntity) : null;
    }
}