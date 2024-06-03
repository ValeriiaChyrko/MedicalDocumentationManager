namespace MedicalDocumentationManager.Domain.Abstraction;

public class Patient : User
{
    public string InsuranceProvider { get; }
    public string InsurancePolicyNumber { get; }

    public Patient(Guid id, string name, DateTime birthDate, Address address, string phoneNumber, string email, 
        string insuranceProvider, string insurancePolicyNumber)
        : base(id, name, birthDate, address, phoneNumber, email)
    {
        InsuranceProvider = insuranceProvider;
        InsurancePolicyNumber = insurancePolicyNumber;
    }
    
    void SubscribeToMedicalRecordUpdates(MedicalRecord record)
    {
        record.Updated += OnMedicalRecordUpdated;
    }

    public void UnsubscribeFromMedicalRecordUpdates(MedicalRecord record)
    {
        record.Updated -= OnMedicalRecordUpdated;
    }

    private void OnMedicalRecordUpdated(object? sender, MessageEventArgs e)
    {
        var message = e.Message;
    }
}