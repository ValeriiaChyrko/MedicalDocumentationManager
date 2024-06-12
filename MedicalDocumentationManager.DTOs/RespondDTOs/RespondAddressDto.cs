namespace MedicalDocumentationManager.DTOs.RespondDTOs;

public class RespondAddressDto
{
    public long Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; } 
    public required string State { get; set; }
    public required string Zip { get; set; }
}