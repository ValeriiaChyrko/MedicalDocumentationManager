using MedicalDocumentationManager.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalDocumentationManager.Persistence.Contexts.Configurations;

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecordEntity>
{
    public void Configure(EntityTypeBuilder<MedicalRecordEntity> builder)
    {
        builder.HasOne(mr => mr.PatientEntity)
            .WithMany(p => p.MedicalRecords)
            .HasForeignKey(mr => mr.PatientId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasOne(mr => mr.DoctorEntity)
            .WithMany(d => d.MedicalRecords)
            .HasForeignKey(mr => mr.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasMany(d => d.Subscriptions)
            .WithOne(a => a.MedicalRecordEntity)
            .HasForeignKey(d => d.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(mr => mr.Record).IsRequired();
    }
}