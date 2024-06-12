using MedicalDocumentationManager.Database.Contexts.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Database.Contexts.Implementations;

public class MedicalDocumentationManagerInMemoryDbContextFactory : IMedicalDocumentationManagerDbContextFactory
{
    public MedicalDocumentationManagerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MedicalDocumentationManagerDbContext>();
        optionsBuilder.UseInMemoryDatabase("MedicalDocumentationManagerDb");

        return new MedicalDocumentationManagerDbContext(optionsBuilder.Options);
    }
}