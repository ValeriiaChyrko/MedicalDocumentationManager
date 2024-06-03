namespace MedicalDocumentationManager.Domain.Abstraction;

public class Doctor : User
{
    public string Specialization { get; }
    public int Experience { get; }
    public string Education { get; }
    public string RoomNumber { get; }

    public Doctor(Guid id, string name, DateTime birthDate, Address address, string phoneNumber, string email, 
        string specialization, int experience, string education, string roomNumber) 
        : base(id, name, birthDate, address, phoneNumber, email)
    {
        Specialization = specialization;
        Experience = experience;
        Education = education;
        RoomNumber = roomNumber;
    }
}