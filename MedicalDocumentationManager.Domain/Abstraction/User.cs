namespace MedicalDocumentationManager.Domain.Abstraction;

public class User
{
    public Guid Id { get; }
    public string Name { get; }
    public DateTime BirthDate { get; }
    public Address Address { get; }
    public string PhoneNumber { get; }
    public string Email { get; }

    protected User(Guid id, string name, DateTime birthDate, Address address, string phoneNumber, string email)
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}