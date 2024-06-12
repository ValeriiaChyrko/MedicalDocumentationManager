using MedicalDocumentationManager.Database.Contexts.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Database.Contexts.Implementations;

public class MedicalDocumentationManagerPostgresSqlDbContextFactory : IMedicalDocumentationManagerDbContextFactory
{
    public MedicalDocumentationManagerDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<MedicalDocumentationManagerDbContext>();
        optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

        return new MedicalDocumentationManagerDbContext(optionsBuilder.Options);
    }
}