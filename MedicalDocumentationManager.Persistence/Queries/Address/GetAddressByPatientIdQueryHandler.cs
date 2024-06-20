using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public sealed class GetAddressByPatientIdQueryHandler : IRequestHandler<GetAddressByPatientIdQuery, AddressDto?>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAddressByPatientIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AddressDto?> Handle(GetAddressByPatientIdQuery query, CancellationToken cancellationToken)
    {
        var addressEntity = await _context.AddressEntities
            .Include(a => a.Patients)
            .AsNoTracking()
            .FirstOrDefaultAsync(a =>
                    a.Patients != null &&
                    a.Patients.Any(p => p.Id == query.PatientId),
                cancellationToken);

        return addressEntity != null ? _mapper.Map<AddressDto>(addressEntity) : null;
    }
}