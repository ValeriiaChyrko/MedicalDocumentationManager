using MedicalDocumentationManager.Database.Contexts.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Database.Tests;

[TestFixture]
public class DatabasePostgresSqlDbContextFactoryTests
{
    [Test]
    public void CreateDbContext_ReturnsDbContextInstance()
    {
        // Arrange
        var factory = new MedicalDocumentationManagerPostgresSqlDbContextFactory();

        // Act
        var dbContext = factory.CreateDbContext();

        // Assert
        dbContext.Should().NotBeNull();
        dbContext.Should().BeAssignableTo<MedicalDocumentationManagerDbContext>();
    }

    [Test]
    public void CreateDbContext_ConfigurationIsLoadedCorrectly()
    {
        // Arrange
        var factory = new MedicalDocumentationManagerPostgresSqlDbContextFactory();
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        // Act
        var dbContext = factory.CreateDbContext();

        // Assert
        dbContext.Database.GetDbConnection().ConnectionString.Should()
            .Be(config.GetConnectionString("DefaultConnection"));
    }

    [Test]
    public void CreateDbContext_OptionsBuilderIsConfiguredCorrectly()
    {
        // Arrange
        var factory = new MedicalDocumentationManagerPostgresSqlDbContextFactory();

        // Act
        var dbContext = factory.CreateDbContext();

        // Assert
        dbContext.Database.ProviderName.Should().Be("Npgsql.EntityFrameworkCore.PostgreSQL");
    }
}