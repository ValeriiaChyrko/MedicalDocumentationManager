namespace MedicalDocumentationManager.Database.Contexts.Abstractions;

public interface IMedicalDocumentationManagerDbContextProvider
{
    IMedicalDocumentationManagerDbContextFactory GetFactory();
}