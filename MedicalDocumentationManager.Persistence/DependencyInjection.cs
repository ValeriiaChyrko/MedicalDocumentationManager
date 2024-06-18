using System.Reflection;
using MediatR;
using MedicalDocumentationManager.Persistence.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DatabaseErrorBehavior<,>));
        
        return services;
    }
}