using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IMedicalRecordService, MedicalRecordService>();
        services.AddSingleton<IDoctorService, DoctorService>();
        services.AddSingleton<IPatientService, PatientService>();
        services.AddSingleton<ISubscriptionService, SubscriptionService>();
        
        services.AddScoped<IDatabaseTransactionManager, DatabaseTransactionManager>();
        
        return services;
    }
}