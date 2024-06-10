using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Database.Contexts.Configurations.DataSeeds;

public static class MedicalRecordsDataTableSeed
{
    internal static List<MedicalRecordEntity> SeedMedicalRecords(List<PatientEntity> patients,
        List<DoctorEntity> doctors)
    {
        var medicalRecords = new List<MedicalRecordEntity>();

        var random = new Random();

        const int maxRecordAmount = 30;
        for (var i = 0; i < maxRecordAmount; i++)
        {
            var patientId = patients[random.Next(patients.Count)].Id;
            var doctorId = doctors[random.Next(doctors.Count)].Id;
            var record = $"Medical record {i + 1} for patient {patientId} and doctor {doctorId}";

            var medicalRecord = new MedicalRecordEntity
            {
                Id = Guid.NewGuid(),
                PatientId = patientId,
                DoctorId = doctorId,
                Record = record,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            medicalRecords.Add(medicalRecord);
        }

        return medicalRecords;
    }
}