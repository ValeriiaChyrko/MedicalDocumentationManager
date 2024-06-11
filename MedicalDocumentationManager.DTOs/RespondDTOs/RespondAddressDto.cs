namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondAddressDto
{
    public long Id { get; init; }
    public string Street { get; } = null!;
    public string City { get; } = null!;
    public string State { get; } = null!;
    public string Zip { get; } = null!;
}