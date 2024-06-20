using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Doctor;

public sealed class GetDoctorByIdWithAddressQueryHandler : IRequestHandler<GetDoctorByIdWithAddressQuery, RespondDoctorDto?>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetDoctorByIdWithAddressQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondDoctorDto?> Handle(GetDoctorByIdWithAddressQuery query, CancellationToken cancellationToken)
    {
        var doctorEntity = await _context.DoctorEntities
            .Include(p => p.AddressEntity)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        return doctorEntity != null ? _mapper.Map<RespondDoctorDto>(doctorEntity) : null;
    }
}