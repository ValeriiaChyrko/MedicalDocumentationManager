using MedicalDocumentationManager.Database.Contexts.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Database.Contexts.Implementations;

public class MedicalDocumentationManagerPostgresSqlDbContextFactory : IMedicalDocumentationManagerDbContextFactory
{
    private readonly IConfiguration _config;

    public MedicalDocumentationManagerPostgresSqlDbContextFactory(IConfiguration config)
    {
        _config = config?? throw new ArgumentNullException(nameof(config));
    }

    public MedicalDocumentationManagerDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<MedicalDocumentationManagerDbContext>();
        optionsBuilder.UseNpgsql(_config.GetConnectionString("DefaultConnection"));

        return new MedicalDocumentationManagerDbContext(optionsBuilder.Options);
    }
}