using MedicalDocumentationManager.Persistence.Abstractions.Errors;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;
using MedicalDocumentationManager.Persistence.Behaviors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MedicalDocumentationManager.Persistence.Tests.Behaviors
{
    [TestFixture]
    public class DatabaseErrorBehaviorDataSimulationTests
    {
        private class TestDbContext : DbContext
        {
            public DbSet<TestEntity> TestEntities { get; set; } = null!;

            public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
            {
            }
        }

        private class TestEntity
        {
            public int Id { get; set; }
            public required string Name { get; set; }
        }

        private class TestRequest : IRequest<string>
        {
        }

        private DbContextOptions<TestDbContext> _options = null!;
        private TestDbContext _context = null!;
        private DatabaseErrorBehavior<TestRequest, string> _behavior = null!;

        [SetUp]
        public void SetUp()
        {
            _options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new TestDbContext(_options);
            _behavior = new DatabaseErrorBehavior<TestRequest, string>();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task Handle_DatabaseError_ThrowsDatabaseErrorException()
        {
            _context.TestEntities.Add(new TestEntity { Id = 1, Name = "Test" });
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            var requestDelegate = new RequestHandlerDelegate<string>(() =>
            {
                var entry = _context.Entry(new TestEntity { Id = 1, Name = "Test Updated" });
                entry.State = EntityState.Modified;
                throw new DbUpdateException("Test Exception", new Exception("Inner Exception"),
                    new List<EntityEntry> { entry });
            });

            Func<Task> act = async () =>
                await _behavior.Handle(new TestRequest(), requestDelegate, CancellationToken.None);

            var exception = await act.Should().ThrowAsync<DatabaseErrorException>()
                .WithMessage("Database error for query: TestRequest");

            exception.Which.Errors.Should().ContainSingle()
                .Which.Should().BeEquivalentTo(new DataBaseError
                {
                    Table = "TestEntity",
                    Message = "Inner Exception"
                });
        }

        [Test]
        public async Task Handle_DatabaseError_WithMultipleEntries_ThrowsDatabaseErrorException()
        {
            _context.TestEntities.AddRange(
                new TestEntity { Id = 1, Name = "Test" },
                new TestEntity { Id = 2, Name = "Test2" }
            );
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            var requestDelegate = new RequestHandlerDelegate<string>(() =>
            {
                var entry1 = _context.Entry(new TestEntity { Id = 1, Name = "Test Updated" });
                entry1.State = EntityState.Modified;

                var entry2 = _context.Entry(new TestEntity { Id = 2, Name = "Test2 Updated" });
                entry2.State = EntityState.Modified;

                throw new DbUpdateException("Test Exception", new Exception("Inner Exception"),
                    new List<EntityEntry> { entry1, entry2 });
            });

            Func<Task> act = async () =>
                await _behavior.Handle(new TestRequest(), requestDelegate, CancellationToken.None);

            var exception = await act.Should().ThrowAsync<DatabaseErrorException>()
                .WithMessage("Database error for query: TestRequest");

            exception.Which.Errors.Should().HaveCount(2);
            exception.Which.Errors.Should()
                .Contain(error => error.Table == "TestEntity" && error.Message == "Inner Exception");
        }

        [Test]
        public async Task Handle_SuccessfulRequest_ReturnsResponse()
        {
            _context.TestEntities.Add(new TestEntity { Id = 1, Name = "Test" });
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            var requestDelegate = new RequestHandlerDelegate<string>(() => Task.FromResult("Success"));

            var result = await _behavior.Handle(new TestRequest(), requestDelegate, CancellationToken.None);

            result.Should().Be("Success");
        }
        
        [Test]
        public async Task Handle_DatabaseError_WithNullMembers_ThrowsDatabaseErrorException()
        {
            _context.TestEntities.Add(new TestEntity { Id = 1, Name = "Test" });
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            var requestDelegate = new RequestHandlerDelegate<string>(() =>
            {
                var entry = _context.Entry(new TestEntity { Id = 1, Name = "Test Updated" });
                entry.State = EntityState.Modified;
                throw new DbUpdateException("Test Exception", new Exception("Inner Exception"),
                    new List<EntityEntry> { entry });
            });

            Func<Task> act = async () =>
                await _behavior.Handle(new TestRequest(), requestDelegate, CancellationToken.None);

            var exception = await act.Should().ThrowAsync<DatabaseErrorException>()
                .WithMessage("Database error for query: TestRequest");

            exception.Which.Errors.Should().ContainSingle()
                .Which.Should().BeEquivalentTo(new DataBaseError
                {
                    Table = "TestEntity",
                    Message = "Inner Exception"
                });
        }
        
        [Test]
        public async Task Handle_DatabaseError_WithNoEntries_ThrowsDatabaseErrorException()
        {
            var requestDelegate = new RequestHandlerDelegate<string>(
                () => throw new DbUpdateException("Test Exception", 
                    new Exception("Inner Exception"), new List<EntityEntry>()));

            Func<Task> act = async () =>
                await _behavior.Handle(new TestRequest(), requestDelegate, CancellationToken.None);

            var exception = await act.Should().ThrowAsync<DatabaseErrorException>()
                .WithMessage("Database error for query: TestRequest");

            exception.Which.Errors.Should().BeEmpty();
        }
    }
}
