using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.Domain.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IMessageHandler, ConsoleMessageHandler>();
        services.AddScoped<IMedicalRecordNotifier, MedicalRecordNotifier>();
        services.AddScoped<IMedicalRecordObserver, MedicalRecordObserver>();
        
        services.AddSingleton<ILoggerFactoryProvider, LoggerFactoryProvider>();
        services.AddSingleton<ILoggerFactory>(provider =>
        {
            var loggerFactoryProvider = provider.GetService<ILoggerFactoryProvider>();
            return loggerFactoryProvider!.GetFactory();
        });
        services.AddSingleton<ILogger>(provider =>
        {
            var loggerFactory = provider.GetService<ILoggerFactory>();
            return loggerFactory!.CreateLogger();
        });
        
        return services;
    }
}