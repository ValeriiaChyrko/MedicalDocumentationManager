using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Persistence.Queries.Doctor;

public sealed class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, RespondDoctorDto?>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetDoctorByIdQueryHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RespondDoctorDto?> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
    {
        var doctorEntity = await _context
            .DoctorEntities
            .AsNoTracking()
            .FirstOrDefaultAsync(mr => mr.Id == query.Id, cancellationToken);

        return doctorEntity != null ? _mapper.Map<RespondDoctorDto>(doctorEntity) : null;
    }
}