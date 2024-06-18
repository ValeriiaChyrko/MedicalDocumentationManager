using System.Reflection;
using FluentValidation;
using MedicalDocumentationManager.DTOs.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.DTOs;

public static class DependencyInjection
{
    public static IServiceCollection AddDtosServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<AddressMappingProfile>();
            cfg.AddProfile<DoctorMappingProfile>();
            cfg.AddProfile<DomainModelsMappingProfile>();
            cfg.AddProfile<MedicalRecordMappingProfile>();
            cfg.AddProfile<PatientMappingProfile>();
            cfg.AddProfile<SubscriptionMappingProfile>();
        });

        return services;
    }
}