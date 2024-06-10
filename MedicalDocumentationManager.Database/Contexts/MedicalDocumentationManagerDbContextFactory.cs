using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Database.Contexts;

public class
    MedicalDocumentationManagerDbContextFactory : IDesignTimeDbContextFactory<MedicalDocumentationManagerDbContext>
{
    public MedicalDocumentationManagerDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        return new MedicalDocumentationManagerDbContext(config);
    }
}