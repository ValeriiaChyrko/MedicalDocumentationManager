namespace MedicalDocumentationManager.Domain.Abstraction;

public class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Zip { get; }

    public Address(string street, string city, string state, string zip)
    {
        Street = street;
        City = city;
        State = state;
        Zip = zip;
    }
}