using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalDocumentationManager.Database.Contexts.Abstractions;

public interface IMedicalDocumentationManagerDbContext : IUnitOfWork
{
    DbSet<AddressEntity> AddressEntities { get; set; }
    DbSet<DoctorEntity> DoctorEntities { get; set; }
    DbSet<PatientEntity> PatientEntities { get; set; }
    DbSet<MedicalRecordEntity> MedicalRecordEntities { get; set; }
    DbSet<SubscriptionEntity> SubscriptionEntities { get; set; }
}