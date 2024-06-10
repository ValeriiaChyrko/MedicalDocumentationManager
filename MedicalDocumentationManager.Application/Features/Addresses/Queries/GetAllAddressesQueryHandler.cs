using MedicalDocumentationManager.Application.Abstractions;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Application.Features.Addresses.Queries;

public sealed class GetAllAddressesQueryHandler : IQueryHandler<GetAllAddressesQuery, List<AddressEntity>>
{
    private readonly IMedicalDocumentationManagerDbContext _context;

    public GetAllAddressesQueryHandler(IMedicalDocumentationManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<AddressEntity>>> Handle(GetAllAddressesQuery query,
        CancellationToken cancellationToken)
    {
        var addresses = await _context
            .AddressEntities
            .ToListAsync(cancellationToken);

        return Result.Success(addresses);
    }
}