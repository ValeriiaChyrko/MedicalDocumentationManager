namespace MedicalDocumentationManager.DTOs.RequestsDTOs;

public class RequestAddressDto
{
    public required string Street { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string Zip { get; init; }
}