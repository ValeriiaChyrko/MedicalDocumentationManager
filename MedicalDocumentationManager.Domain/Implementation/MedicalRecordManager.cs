using MedicalDocumentationManager.Domain.Abstraction;

namespace MedicalDocumentationManager.Domain.Implementation;

public class MedicalRecordManager : IMedicalRecordManager
{
    private readonly Dictionary<Guid, MedicalRecord> _medicalRecords = new();

    public MedicalRecord? GetMedicalRecord(Guid medicalRecordId)
    {
        return _medicalRecords.TryGetValue(medicalRecordId, out var medicalRecord)
            ? medicalRecord
            : null;
    }

    public IReadOnlyCollection<MedicalRecord> GetMedicalHistory(Guid patientId)
    {
        return _medicalRecords.Values.Where(mr => mr.PatientId == patientId).ToList().AsReadOnly();
    }

    public void AddMedicalRecord(MedicalRecord medicalRecord)
    {
        _medicalRecords[medicalRecord.Id] = medicalRecord;
    }

    public void UpdateMedicalRecord(MedicalRecord medicalRecord)
    {
        if (_medicalRecords.TryGetValue(medicalRecord.Id, out var existingRecord))
        {
            existingRecord.Update(medicalRecord.PatientId, medicalRecord.DoctorId, medicalRecord.Record);
        }
        else
        {
            throw new InvalidOperationException("Medical record not found");
        }
    }

    public void DeleteMedicalRecord(Guid medicalRecordId)
    {
        _medicalRecords.Remove(medicalRecordId);
    }
}