﻿using MedicalDocumentationManager.Database.Contexts.Implementations;
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
        var configuration = new ConfigurationBuilder().Build();
        var factory = new MedicalDocumentationManagerPostgresSqlDbContextFactory(configuration);

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
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../MedicalDocumentationManager.Presentation");
        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", false, true)
            .Build();
        var factory = new MedicalDocumentationManagerPostgresSqlDbContextFactory(config);

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
        var configuration = new ConfigurationBuilder().Build();
        var factory = new MedicalDocumentationManagerPostgresSqlDbContextFactory(configuration);

        // Act
        var dbContext = factory.CreateDbContext();

        // Assert
        dbContext.Database.ProviderName.Should().Be("Npgsql.EntityFrameworkCore.PostgreSQL");
    }
}