using MedicalDocumentationManager.Persistence.Entities;
using Random = System.Random;

namespace MedicalDocumentationManager.Persistence.Contexts.Configurations.DataSeeds;

public static class DoctorDataTableSeed
{
    internal static List<DoctorEntity> SeedDoctors(IReadOnlyList<AddressEntity> addressEntities)
    {
        var doctors = new List<DoctorEntity>();

        var random = new Random();
        var addressesRecordsAmount = addressEntities.Count - 1;

        string[] names = { "John Smith", "Emily Johnson", "Michael Williams", "Emma Brown", "James Jones" };
        string[] phonePrefixes = { "555", "666", "777", "888", "999" };
        string[] emailDomains = { "gmail.com", "yahoo.com", "outlook.com", "hotmail.com", "aol.com" };
        string[] specializations = { "Cardiology", "Neurology", "Orthopedics", "Pediatrics", "Oncology" };
        string[] roomPrefixes = { "A", "B", "C", "D", "E" };

        const int maxRecordAmount = 15;
        for (var i = 0; i < maxRecordAmount; i++)
        {
            var addressId = random.Next(0, addressesRecordsAmount);
            var name = names[random.Next(names.Length)];
            var doctor = new DoctorEntity
            {
                Id = Guid.NewGuid(),
                FullName = name,
                BirthDate = new DateOnly(random.Next(1950, 2000), random.Next(1, 13), random.Next(1, 29)),
                AddressId = addressEntities[addressId].Id,
                PhoneNumber =
                    $"+1-{phonePrefixes[random.Next(phonePrefixes.Length)]}-{random.Next(100, 1000)}-{random.Next(1000, 10000)}",
                Email = $"{name.ToLower().Replace(" ", ".")}{random.Next(0, 10)}@{emailDomains[random.Next(emailDomains.Length)]}",
                Specialization = specializations[random.Next(specializations.Length)],
                ExperienceInYears = random.Next(1, 31),
                Education = "Medical Degree",
                RoomNumber = $"{roomPrefixes[random.Next(roomPrefixes.Length)]}-{random.Next(100, 1000)}"
            };

            doctors.Add(doctor);
        }

        return doctors;
    }
}