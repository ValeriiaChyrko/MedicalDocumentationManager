using MedicalDocumentationManager.Database.Contexts.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace MedicalDocumentationManager.Database.Tests;

[TestFixture]
public class MedicalDocumentationManagerDbContextTests
{
    private IMedicalDocumentationManagerDbContext _dbContext = null!;
    private IDbContextTransaction _mockTransaction = null!;

    [SetUp]
    public void Setup()
    {
        // Arrange
        var configMock = Substitute.For<IConfiguration>();
        configMock["DbContext:Type"].Returns("InMemory"); 

        var services = new ServiceCollection();
        services.AddSingleton(configMock);
        services.AddDatabaseServices();

        var serviceProvider = services.BuildServiceProvider();

        // Act
        _dbContext = serviceProvider.GetRequiredService<IMedicalDocumentationManagerDbContext>();
        _mockTransaction = Substitute.For<IDbContextTransaction>();
    }

    [Test]
    public void BeginTransaction_ReturnsTransaction()
    {
        // Act
        var transaction = _dbContext.BeginTransaction();

        // Assert
        transaction.Should().NotBeNull();
        transaction.Should().BeAssignableTo<IDbContextTransaction>();
    }

    [Test]
    public async Task BeginTransactionAsync_ReturnsTransactionAsync()
    {
        // Act
        var transaction = await _dbContext.BeginTransactionAsync();

        // Assert
        transaction.Should().NotBeNull();
        transaction.Should().BeAssignableTo<IDbContextTransaction>();
    }

    [Test]
    public void CommitTransaction_CommitsTransaction()
    {
        // Act
        Action act = () => _dbContext.CommitTransaction(_mockTransaction);

        // Assert
        act.Should().NotThrow();
    }

    [Test]
    public void RollbackTransaction_RollsBackTransaction()
    {
        // Act
        Action act = () => _dbContext.RollbackTransaction(_mockTransaction);

        // Assert
        act.Should().NotThrow();
    }
}