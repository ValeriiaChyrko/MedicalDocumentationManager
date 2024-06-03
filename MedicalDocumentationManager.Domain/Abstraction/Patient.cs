namespace MedicalDocumentationManager.Domain.Abstraction;

public class Patient : User
{
    public string InsuranceProvider { get; }
    public string InsurancePolicyNumber { get; }

    private readonly IMedicalRecordObserver _medicalRecordObserver;

    public Patient(Guid id, string name, DateTime birthDate, Address address, string phoneNumber, string email,
        string insuranceProvider, string insurancePolicyNumber, IMedicalRecordObserver medicalRecordObserver)
        : base(id, name, birthDate, address, phoneNumber, email)
    {
        InsuranceProvider = insuranceProvider;
        InsurancePolicyNumber = insurancePolicyNumber;
        _medicalRecordObserver = medicalRecordObserver;
    }

    public void SubscribeToMedicalRecordUpdates()
    {
        _medicalRecordObserver.Subscribe();
    }

    public void UnsubscribeFromMedicalRecordUpdates()
    {
        _medicalRecordObserver.Unsubscribe();
    }
}