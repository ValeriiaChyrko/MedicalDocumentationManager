using AutoMapper;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Doctor;

public sealed class GetAllDoctorsQueryHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetAllDoctorsQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<RespondDoctorDto>> Handle(GetAllDoctorsQuery query,
        CancellationToken cancellationToken)
    {
        var doctors = await _context
            .DoctorEntities
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return doctors.Select(entityModel => _mapper.Map<RespondDoctorDto>(entityModel)).ToList();
    }
}