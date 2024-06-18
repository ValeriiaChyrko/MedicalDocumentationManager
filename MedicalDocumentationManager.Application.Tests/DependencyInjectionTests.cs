using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Implementations;

namespace MedicalDocumentationManager.Application.Tests;

[TestFixture]
public class DependencyInjectionTests
{
    [Test]
    public void AddApplicationServices_RegistersServicesCorrectly()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddApplicationServices();

        // Assert
        services.Should().Contain(sd => sd.ServiceType == typeof(IMedicalRecordService) && sd.ImplementationType == typeof(MedicalRecordService));
        services.Should().Contain(sd => sd.ServiceType == typeof(IDoctorService) && sd.ImplementationType == typeof(DoctorService));
        services.Should().Contain(sd => sd.ServiceType == typeof(IPatientService) && sd.ImplementationType == typeof(PatientService));
        services.Should().Contain(sd => sd.ServiceType == typeof(ISubscriptionService) && sd.ImplementationType == typeof(SubscriptionService));
        services.Should().Contain(sd => sd.ServiceType == typeof(IDatabaseTransactionManager) && sd.ImplementationType == typeof(DatabaseTransactionManager));
    }
    
}