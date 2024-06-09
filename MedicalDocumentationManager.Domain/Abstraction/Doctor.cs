namespace MedicalDocumentationManager.Domain.Abstraction;

public class Doctor : User
{
    public string Specialization { get; }
    public uint ExperienceInYears { get; }
    public string Education { get; }
    public string RoomNumber { get; }

    public Doctor(Guid id, string name, DateOnly birthDate, Address address, string phoneNumber, string email, 
        string specialization, uint experienceInYears, string education, string roomNumber) 
        : base(id, name, birthDate, address, phoneNumber, email)
    {
        Specialization = specialization;
        ExperienceInYears = experienceInYears;
        Education = education;
        RoomNumber = roomNumber;
    }
}