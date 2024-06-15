using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Queries.Patient;

public sealed class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, RespondPatientDto?>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetPatientByIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondPatientDto?> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
    {
        var patientEntity = await _context.PatientEntities.FindAsync(new object[] { query.Id }, cancellationToken);

        return patientEntity != null ? _mapper.Map<RespondPatientDto>(patientEntity) : null;
    }
}