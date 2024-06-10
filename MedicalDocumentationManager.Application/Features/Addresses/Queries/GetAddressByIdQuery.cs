using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Features.Addresses.Queries;

public record GetAddressByIdQuery(long Id) : IQuery<AddressEntity>;