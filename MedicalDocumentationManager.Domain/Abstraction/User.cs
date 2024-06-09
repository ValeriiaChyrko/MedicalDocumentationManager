namespace MedicalDocumentationManager.Domain.Abstraction;

public class User
{
    public Guid Id { get; }
    public string FullName { get; }
    public DateOnly BirthDate { get; }
    public Address Address { get; }
    public string PhoneNumber { get; }
    public string Email { get; }

    protected User(Guid id, string fullName, DateOnly birthDate, Address address, string phoneNumber, string email)
    {
        Id = id;
        FullName = fullName;
        BirthDate = birthDate;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}