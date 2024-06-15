using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Configurations.DataSeeds;
using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalDocumentationManager.Database.Contexts.Implementations;

public class MedicalDocumentationManagerDbContext : DbContext, IMedicalDocumentationManagerDbContext
{
    public MedicalDocumentationManagerDbContext(DbContextOptions<MedicalDocumentationManagerDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(MedicalDocumentationManagerDbContext).Assembly);

        SeedDataBase(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning));
    }

    private static void SeedDataBase(ModelBuilder modelBuilder)
    {
        var addresses = AddressDataTableSeed.SeedAddresses();
        modelBuilder.Entity<AddressEntity>().HasData(addresses);
        var doctors = DoctorDataTableSeed.SeedDoctors(addresses);
        modelBuilder.Entity<DoctorEntity>().HasData(doctors);
        var patients = PatientsDataTableSeed.SeedPatients(addresses);
        modelBuilder.Entity<PatientEntity>().HasData(patients);
        var medicalRecords = MedicalRecordsDataTableSeed.SeedMedicalRecords(patients, doctors);
        modelBuilder.Entity<MedicalRecordEntity>().HasData(medicalRecords);
        var subscriptions = SubscriptionsDataTableSeed.SeedSubscriptions(patients, medicalRecords);
        modelBuilder.Entity<SubscriptionEntity>().HasData(subscriptions);
    }

    public DbSet<AddressEntity> AddressEntities { get; set; } = null!;
    public DbSet<DoctorEntity> DoctorEntities { get; set; } = null!;
    public DbSet<PatientEntity> PatientEntities { get; set; } = null!;
    public DbSet<MedicalRecordEntity> MedicalRecordEntities { get; set; } = null!;
    public DbSet<SubscriptionEntity> SubscriptionEntities { get; set; } = null!;

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AddressEntity>())
            if (entry.State is EntityState.Deleted or EntityState.Modified)
            {
                var addressEntity = entry.Entity;
                if (addressEntity.Doctors != null && !addressEntity.Doctors.Any()
                                                  && addressEntity.Patients != null && !addressEntity.Patients.Any())
                    entry.State = EntityState.Deleted;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public void DetachEntitiesInChangeTracker()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            entry.State = EntityState.Detached;
        }
    }

    public IDbContextTransaction BeginTransaction()
    {
        return Database.BeginTransaction();
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return await Database.BeginTransactionAsync(cancellationToken);
    }

    public void CommitTransaction(IDbContextTransaction transaction)
    {
        transaction.Commit();
    }

    public void RollbackTransaction(IDbContextTransaction transaction)
    {
        transaction.Rollback();
    }
}