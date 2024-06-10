using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Database.Contexts.Configurations.DataSeeds;

public static class SubscriptionsDataTableSeed
{
    internal static List<SubscriptionEntity> SeedSubscriptions(List<PatientEntity> patients,
        List<MedicalRecordEntity> medicalRecords)
    {
        var subscriptions = new List<SubscriptionEntity>();

        var random = new Random();
        string[] subscriptionTypes = { "Observer", "Notifier" };

        const int maxRecordAmount = 50;
        for (var i = 0; i < maxRecordAmount; i++)
        {
            var patientId = patients[random.Next(patients.Count)].Id;
            var medicalRecordId = medicalRecords[random.Next(medicalRecords.Count)].Id;
            var subscriptionType = subscriptionTypes[random.Next(subscriptionTypes.Length)];

            var subscription = new SubscriptionEntity
            {
                Id = i + 1,
                PatientId = patientId,
                MedicalRecordId = medicalRecordId,
                SubscriptionType = subscriptionType
            };

            subscriptions.Add(subscription);
        }

        return subscriptions;
    }
}