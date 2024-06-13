namespace MedicalDocumentationManager.DTOs.SharedDTOs;

public class AddressDto
{
    public long Id { get; set; }
    public required string Street { get; init; }
    public required string City { get; init; }
    public required string State { get; init; }
    public required string Zip { get; init; }
}