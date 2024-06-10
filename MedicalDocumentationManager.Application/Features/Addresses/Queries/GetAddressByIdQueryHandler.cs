using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Abstractions.Errors;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Addresses.Queries;

public sealed class GetAddressByIdQueryHandler : IQueryHandler<GetAddressByIdQuery, AddressEntity>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetAddressByIdQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<AddressEntity>> Handle(GetAddressByIdQuery query, CancellationToken cancellationToken)
    {
        var address = await _context
            .AddressEntities
            .FirstOrDefaultAsync(a => a.Id == query.Id, cancellationToken);

        return address is null ? AddressErrors.NotFound(query.Id) : Result.Success(address);
    }
}