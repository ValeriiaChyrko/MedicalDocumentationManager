using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Patient;

public sealed class GetPatientByIdWithAddressQueryHandler : IRequestHandler<GetPatientByIdWithAddressQuery, RespondPatientDto?>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetPatientByIdWithAddressQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondPatientDto?> Handle(GetPatientByIdWithAddressQuery query, CancellationToken cancellationToken)
    {
        var patientEntity = await _context.PatientEntities
            .Include(p => p.AddressEntity) 
            .FirstOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        return patientEntity != null ? _mapper.Map<RespondPatientDto>(patientEntity) : null;
    }
}