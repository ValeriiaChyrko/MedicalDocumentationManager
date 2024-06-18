using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.Database;

public static class DependencyInjection
{
    public static void AddDatabaseServices(this IServiceCollection services)
    {
        services.AddSingleton<IMedicalDocumentationManagerDbContextProvider, MedicalDocumentationManagerDbContextProvider>();
        
        services.AddSingleton<IMedicalDocumentationManagerDbContextFactory>(provider =>
        {
            var contextFactoryProvider = provider.GetService<IMedicalDocumentationManagerDbContextProvider>();
            return contextFactoryProvider!.GetFactory();
        });
        
        services.AddSingleton<IMedicalDocumentationManagerDbContext>(provider =>
        {
            var contextFactory = provider.GetService<IMedicalDocumentationManagerDbContextFactory>();
            return contextFactory!.CreateDbContext();
        });
    }
}