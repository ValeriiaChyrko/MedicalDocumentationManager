using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Address;

public sealed class GetAddressByDoctorIdQueryHandler : IRequestHandler<GetAddressByDoctorIdQuery, AddressDto?>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAddressByDoctorIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AddressDto?> Handle(GetAddressByDoctorIdQuery query, CancellationToken cancellationToken)
    {
        var addressEntity = await _context.AddressEntities
            .Include(a => a.Doctors)
            .FirstOrDefaultAsync(a =>
                    a.Doctors != null &&
                    a.Doctors.Any(p => p.Id == query.DoctorId),
                cancellationToken);

        return addressEntity != null ? _mapper.Map<AddressDto>(addressEntity) : null;
    }
}