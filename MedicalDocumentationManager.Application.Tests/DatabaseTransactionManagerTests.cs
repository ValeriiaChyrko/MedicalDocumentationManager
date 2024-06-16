using MedicalDocumentationManager.Application.Implementations;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalDocumentationManager.Application.Tests;

[TestFixture]
public class DatabaseTransactionManagerTests
{
    private IMedicalDocumentationManagerDbContext _context = null!;
    private DatabaseTransactionManager _transactionManager = null!;
    
    [SetUp]
    public void SetUp()
    {
        _context = Substitute.For<IMedicalDocumentationManagerDbContext>();
        _transactionManager = new DatabaseTransactionManager(_context);
    }

    [Test]
    public async Task SaveChangesAsync_WhenCalled_SavesChanges()
    {
        // Arrange
        var cancellationToken = new CancellationToken();

        // Act
        await _transactionManager.SaveChangesAsync(cancellationToken);

        // Assert
        await _context.Received(1).SaveChangesAsync(cancellationToken);
    }

    [Test]
    public async Task SaveChangesAsync_WhenCancellationRequested_ThrowsOperationCanceledException()
    {
        // Arrange
        var cancellationToken = new CancellationToken(true);

        // Act and Assert
        await FluentActions.Invoking(() => _transactionManager.SaveChangesAsync(cancellationToken))
            .Should()
            .ThrowAsync<OperationCanceledException>();
    }

    [Test]
    public async Task BeginTransactionAsync_WhenCalled_ReturnsTransaction()
    {
        // Act
        var transaction = await _transactionManager.BeginTransactionAsync();

        // Assert
        transaction.Should().NotBeNull();
        await _context.Received(1).BeginTransactionAsync();
    }

    [Test]
    public async Task BeginTransactionAsync_WhenTransactionAlreadyActive_ThrowsInvalidOperationException()
    {
        // Arrange
        await _transactionManager.BeginTransactionAsync();

        // Act and Assert
        await FluentActions.Invoking(() => _transactionManager.BeginTransactionAsync())
            .Should()
            .ThrowAsync<InvalidOperationException>();
    }

    [Test]
    public async Task CommitAsync_WhenCalled_CommitsTransaction()
    {
        // Arrange
        var transaction = await _transactionManager.BeginTransactionAsync();
        var cancellationToken = new CancellationToken();

        // Act
        await _transactionManager.CommitAsync(transaction, cancellationToken);

        // Assert
        await transaction.Received(1).CommitAsync(cancellationToken);
        await _context.Received(1).SaveChangesAsync(cancellationToken);
    }

    [Test]
    public async Task CommitAsync_WhenCancellationRequested_ThrowsOperationCanceledException()
    {
        // Arrange
        var transaction = await _transactionManager.BeginTransactionAsync();
        var cancellationToken = new CancellationToken(true);

        // Act and Assert
        await FluentActions.Invoking(() => _transactionManager.CommitAsync(transaction, cancellationToken))
            .Should()
            .ThrowAsync<OperationCanceledException>();
    }

    [Test]
    public async Task CommitAsync_WhenExceptionThrown_RollbacksTransactionAndThrowsDatabaseException()
    {
        // Arrange
        var transaction = await _transactionManager.BeginTransactionAsync();
        var cancellationToken = new CancellationToken();
        _context.SaveChangesAsync(cancellationToken).Throws<Exception>();

        // Act and Assert
        await FluentActions.Invoking(() => _transactionManager.CommitAsync(transaction, cancellationToken))
            .Should()
            .ThrowAsync<DatabaseException>();
        await transaction.Received(1).RollbackAsync(cancellationToken);
    }

    [Test]
    public async Task RollbackAsync_WhenCalled_RollbacksTransaction()
    {
        // Arrange
        var transaction = await _transactionManager.BeginTransactionAsync();
        var cancellationToken = new CancellationToken();

        // Act
        await _transactionManager.RollbackAsync(transaction, cancellationToken);

        // Assert
        await transaction.Received(1).RollbackAsync(cancellationToken);
    }

    [Test]
    public async Task RollbackAsync_WhenCancellationRequested_ThrowsOperationCanceledException()
    {
        // Arrange
        var transaction = await _transactionManager.BeginTransactionAsync();
        var cancellationToken = new CancellationToken(true);

        // Act and Assert
        await FluentActions.Invoking(() => _transactionManager.RollbackAsync(transaction, cancellationToken))
            .Should()
            .ThrowAsync<OperationCanceledException>();
    }

    [Test]
    public async Task DisposeAsync_DisposesTransaction()
    {
        // Arrange
        var transaction = await _transactionManager.BeginTransactionAsync();

        // Act
        await _transactionManager.DisposeAsync();

        // Assert
        await transaction.Received(1).DisposeAsync();
    }
    
    [Test]
    public void HasActiveTransaction_ReturnsFalse_WhenNoTransaction()
    {
        // Arrange
        var transactionManager = new DatabaseTransactionManager(Substitute.For<IMedicalDocumentationManagerDbContext>());

        // Act and Assert
        transactionManager.HasActiveTransaction.Should().BeFalse();
    }

    [Test]
    public void HasActiveTransaction_ReturnsTrue_WhenTransactionActive()
    {
        // Arrange
        var transactionManager = new DatabaseTransactionManager(Substitute.For<IMedicalDocumentationManagerDbContext>());
        _ = transactionManager.BeginTransactionAsync();

        // Act and Assert
        transactionManager.HasActiveTransaction.Should().BeTrue();
    }
    
    [Test]
    public async Task RollbackAsync_ThrowsArgumentNullException_WhenTransactionIsNull()
    {
        // Arrange
        IDbContextTransaction transaction = null!;

        // Act and Assert
        await FluentActions.Invoking(() =>  _transactionManager.RollbackAsync(transaction, CancellationToken.None))
            .Should()
            .ThrowAsync<ArgumentNullException>();
    }
    
    [Test]
    public async Task RollbackAsync_ThrowsInvalidOperationException_WhenTransactionIsNotCurrent()
    {
        // Arrange
        _ = await _transactionManager.BeginTransactionAsync();
        var differentTransaction = Substitute.For<IDbContextTransaction>();

        // Act and Assert
        await FluentActions.Invoking(() =>  _transactionManager.RollbackAsync(differentTransaction, CancellationToken.None))
            .Should()
            .ThrowAsync<InvalidOperationException>();
    }
    
    [Test]
    public async Task RollbackAsync_ThrowsOperationCanceledException_WhenCancellationTokenIsCancelled()
    {
        // Arrange
        var transaction = await _transactionManager.BeginTransactionAsync();
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var cancellationToken = cancellationTokenSource.Token;

        // Act and Assert
        await FluentActions.Invoking(() =>   _transactionManager.RollbackAsync(transaction, cancellationToken))
            .Should()
            .ThrowAsync<OperationCanceledException>();
    }
    
    [Test]
    public async Task CommitAsync_ThrowsArgumentNullException_WhenTransactionIsNull()
    {
        // Arrange
        IDbContextTransaction transaction = null!;

        // Act and Assert
        await FluentActions.Invoking(() =>   _transactionManager.CommitAsync(transaction, CancellationToken.None))
            .Should()
            .ThrowAsync<ArgumentNullException>();
    }
    
    [Test]
    public async Task CommitAsync_ThrowsInvalidOperationException_WhenTransactionIsNotCurrent()
    {
        // Arrange
        _ = await _transactionManager.BeginTransactionAsync();
        var differentTransaction = Substitute.For<IDbContextTransaction>();

        // Act and Assert
        await FluentActions.Invoking(() => _transactionManager.CommitAsync(differentTransaction, CancellationToken.None))
            .Should()
            .ThrowAsync<InvalidOperationException>();
    }
    
    [Test]
    public async Task CommitAsync_ThrowsOperationCanceledException_WhenCancellationTokenIsCancelled()
    {
        // Arrange
        var transaction = await _transactionManager.BeginTransactionAsync();
        var cancellationTokenSource = new CancellationTokenSource();
        cancellationTokenSource.Cancel();
        var cancellationToken = cancellationTokenSource.Token;

        // Act and Assert
        await FluentActions.Invoking(() => _transactionManager.CommitAsync(transaction, cancellationToken))
            .Should()
            .ThrowAsync<OperationCanceledException>();
    }

    [Test]
    public void GetCurrentTransaction_ReturnsNull_WhenNoTransaction()
    {
        // Arrange
        var transactionManager = new DatabaseTransactionManager(Substitute.For<IMedicalDocumentationManagerDbContext>());

        // Act and Assert
        transactionManager.GetCurrentTransaction().Should().BeNull();
    }

    [Test]
    public async Task GetCurrentTransaction_ReturnsTransaction_WhenTransactionActive()
    {
        // Arrange
        var transactionManager = new DatabaseTransactionManager(Substitute.For<IMedicalDocumentationManagerDbContext>());
        var transaction = await transactionManager.BeginTransactionAsync();

        // Act and Assert
        transactionManager.GetCurrentTransaction().Should().Be(transaction);
    }
    
    [Test]
    public async Task Dispose_DisposesTransaction()
    {
        // Arrange
        var transactionManager = new DatabaseTransactionManager(Substitute.For<IMedicalDocumentationManagerDbContext>());
        var transaction = await transactionManager.BeginTransactionAsync(); 

        // Act
        transactionManager.Dispose();

        // Assert
        transactionManager.GetCurrentTransaction().Should().BeNull();
        transaction.Received(1).Dispose();
    }
}