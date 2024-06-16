using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Abstraction;

public class Patient : User
{
    public string InsuranceProvider { get; }
    public string InsurancePolicyNumber { get; }

    private readonly IMedicalRecordObserver _medicalRecordObserver;
    private readonly IMedicalRecordNotifier _medicalRecordNotifier;

    protected Patient(Guid id, string fullName, DateOnly birthDate, Address address, string phoneNumber, string email,
        string insuranceProvider, string insurancePolicyNumber,
        IMedicalRecordObserver medicalRecordObserver, IMedicalRecordNotifier medicalRecordNotifier)
        : base(id, fullName, birthDate, address, phoneNumber, email)
    {
        InsuranceProvider = insuranceProvider;
        InsurancePolicyNumber = insurancePolicyNumber;
        _medicalRecordObserver = medicalRecordObserver;
        _medicalRecordNotifier = medicalRecordNotifier;
    }

    public static Patient Create(Guid id, string fullName, DateOnly birthDate, Address address, string phoneNumber, string email,
        string insuranceProvider, string insurancePolicyNumber,
        IMedicalRecordObserver medicalRecordObserver, IMedicalRecordNotifier medicalRecordNotifier)
    {
        var patient = new Patient(id, fullName, birthDate, address, phoneNumber, email, insuranceProvider, insurancePolicyNumber,
            medicalRecordObserver, medicalRecordNotifier);

        return patient;
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