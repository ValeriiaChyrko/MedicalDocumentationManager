using MedicalDocumentationManager.Database.Entities;
using Random = System.Random;

namespace MedicalDocumentationManager.Database.Contexts.Configurations.DataSeeds;

public static class PatientsDataTableSeed
{
    internal static List<PatientEntity> SeedPatients(IReadOnlyList<AddressEntity> addressEntities)
    {
        var patients = new List<PatientEntity>();

        var random = new Random();
        var addressesRecordsAmount = addressEntities.Count - 1;

        string[] names =
        {
            "Daniel Johnson", "Olivia Davis", "William Wilson", "Isabella Martinez", "Liam Anderson",
            "Sophia Taylor", "Ethan Jackson", "Ava White", "Mason Harris", "Amelia Clark"
        };
        string[] phonePrefixes = { "111", "222", "333", "444" };
        string[] emailDomains = { "gmail.com", "yahoo.com", "outlook.com", "hotmail.com", "aol.com" };
        string[] insuranceProviders =
        {
            "BlueCross", "Aetna", "UnitedHealthcare", "Anthem", "Molina Healthcare",
            "Oscar Health", "Bright Health", "Friday Health Plans", "Oxford Health Plans", "Health Net"
        };

        const int maxRecordAmount = 15;
        for (var i = 0; i < maxRecordAmount; i++)
        {
            var addressId = random.Next(0, addressesRecordsAmount);
            var name = names[random.Next(names.Length)];
            var patient = new PatientEntity
            {
                Id = Guid.NewGuid(),
                FullName = name,
                BirthDate = new DateOnly(random.Next(1950, 2000), random.Next(1, 13), random.Next(1, 29)),
                AddressId = addressEntities[addressId].Id,
                PhoneNumber =
                    $"+1-{phonePrefixes[random.Next(phonePrefixes.Length)]}-{random.Next(100, 1000)}-{random.Next(1000, 10000)}",
                Email =
                    $"{name.ToLower().Replace(" ", ".")}{random.Next(0, 10)}@{emailDomains[random.Next(emailDomains.Length)]}",
                InsuranceProvider = insuranceProviders[random.Next(insuranceProviders.Length)],
                InsurancePolicyNumber = $"{random.Next(100000000, 999999999)}"
            };

            patients.Add(patient);
        }

        return patients;
    }
}