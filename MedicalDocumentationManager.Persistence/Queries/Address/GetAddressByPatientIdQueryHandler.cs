using AutoMapper;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public sealed class GetAddressByPatientIdQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAddressByPatientIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondAddressDto?> Handle(GetAddressByPatientIdQuery query, CancellationToken cancellationToken)
    {
        var addressEntity = await _context.AddressEntities
            .Include(a => a.Patients)
            .FirstOrDefaultAsync(a =>
                    a.Patients != null &&
                    a.Patients.Any(p => p.Id == query.PatientId), 
                cancellationToken);

        return addressEntity != null ? _mapper.Map<RespondAddressDto>(addressEntity) : null;
    }
}