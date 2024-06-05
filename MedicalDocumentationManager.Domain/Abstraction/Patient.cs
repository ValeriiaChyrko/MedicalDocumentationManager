namespace MedicalDocumentationManager.Domain.Abstraction;

public class Patient : User
{
    public string InsuranceProvider { get; }
    public string InsurancePolicyNumber { get; }

    private readonly IMedicalRecordObserver _medicalRecordObserver;
    private readonly IMedicalRecordNotifier _medicalRecordNotifier;

    public Patient(Guid id, string name, DateTime birthDate, Address address, string phoneNumber, string email,
        string insuranceProvider, string insurancePolicyNumber, 
        IMedicalRecordObserver medicalRecordObserver, IMedicalRecordNotifier medicalRecordNotifier)
        : base(id, name, birthDate, address, phoneNumber, email)
    {
        InsuranceProvider = insuranceProvider;
        InsurancePolicyNumber = insurancePolicyNumber;
        _medicalRecordObserver = medicalRecordObserver;
        _medicalRecordNotifier = medicalRecordNotifier;
    }

    public void SubscribeToMedicalRecordUpdates()
    {
        _medicalRecordObserver.Subscribe();
    }

    public void UnsubscribeFromMedicalRecordUpdates()
    {
        _medicalRecordObserver.Unsubscribe();
    }
    
    public void SubscribeToMedicalRecordNotifications()
    {
        _medicalRecordNotifier.Subscribe();
    }

    public void UnsubscribeFromMedicalRecordNotifications()
    {
        _medicalRecordNotifier.Unsubscribe();
    }
}