using MedicalDocumentationManager.Database.Contexts.Implementations;

namespace MedicalDocumentationManager.Database.Contexts.Abstractions;

public interface IMedicalDocumentationManagerDbContextFactory
{
    MedicalDocumentationManagerDbContext CreateDbContext(string[] args);
}