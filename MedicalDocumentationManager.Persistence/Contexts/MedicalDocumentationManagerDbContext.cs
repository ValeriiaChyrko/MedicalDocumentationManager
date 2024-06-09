using MedicalDocumentationManager.Persistence.Contexts.Configurations.DataSeeds;
using MedicalDocumentationManager.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Persistence.Contexts;

public class MedicalDocumentationManagerDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public MedicalDocumentationManagerDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(MedicalDocumentationManagerDbContext).Assembly);

        SeedDataBase(modelBuilder);

        base.OnModelCreating(modelBuilder);
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
    
    DbSet<AddressEntity> AddressEntities { get; set; } = null!;
    DbSet<DoctorEntity> DoctorEntities { get; set; } = null!;
    DbSet<PatientEntity> PatientEntities { get; set; } = null!;
    DbSet<MedicalRecordEntity> MedicalRecordEntities { get; set; } = null!;
    private DbSet<SubscriptionEntity> SubscriptionEntities { get; set; } = null!;
}