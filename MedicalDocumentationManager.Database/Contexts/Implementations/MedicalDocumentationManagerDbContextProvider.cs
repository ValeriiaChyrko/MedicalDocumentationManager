using MedicalDocumentationManager.Database.Contexts.Abstractions;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Database.Contexts.Implementations;

public class MedicalDocumentationManagerDbContextProvider : IMedicalDocumentationManagerDbContextProvider
{
    private readonly IConfiguration _config;

    public MedicalDocumentationManagerDbContextProvider(IConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public IMedicalDocumentationManagerDbContextFactory GetFactory()
    {
        var dbContextType = _config["DbContext:Type"];

        return dbContextType switch
        {
            "InMemory" => new MedicalDocumentationManagerInMemoryDbContextFactory(),
            "PostgresSql" => new MedicalDocumentationManagerPostgresSqlDbContextFactory(_config),
            _ => throw new ArgumentException("Invalid DbContext type", nameof(dbContextType))
        };
    }
}