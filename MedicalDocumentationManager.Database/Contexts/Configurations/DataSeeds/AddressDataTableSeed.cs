using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Database.Contexts.Configurations.DataSeeds;

public static class AddressDataTableSeed
{
    internal static List<AddressEntity> SeedAddresses()
    {
        var addresses = new List<AddressEntity>();

        var random = new Random();

        string[] streets =
        {
            "Main St", "Oak St", "Maple Ave", "Elm St", "Cedar Ln", "Pine St", "Washington Ave",
            "Broadway", "Sunset Blvd", "Highland Ave"
        };
        string[] cities =
        {
            "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio",
            "San Diego", "Dallas", "San Jose"
        };
        string[] states = { "NY", "CA", "IL", "TX", "AZ", "PA", "TX", "CA", "TX", "CA" };

        const int maxRecordAmount = 25;
        for (var i = 0; i < maxRecordAmount; i++)
        {
            var address = new AddressEntity
            {
                Id = i + 1,
                Street = streets[random.Next(streets.Length)],
                City = cities[random.Next(cities.Length)],
                State = states[random.Next(states.Length)],
                Zip = random.Next(10000, 99999).ToString("D5")
            };

            addresses.Add(address);
        }

        return addresses;
    }
}