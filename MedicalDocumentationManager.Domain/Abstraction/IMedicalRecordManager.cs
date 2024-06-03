namespace MedicalDocumentationManager.Domain.Abstraction;

public interface IMedicalRecordManager
{
    MedicalRecord? GetMedicalRecord(Guid medicalRecordId);
    IReadOnlyCollection<MedicalRecord> GetMedicalHistory(Guid patientId);
    
    void AddMedicalRecord(MedicalRecord medicalRecord);
    void UpdateMedicalRecord(MedicalRecord medicalRecord);
    void DeleteMedicalRecord(Guid medicalRecordId);
}