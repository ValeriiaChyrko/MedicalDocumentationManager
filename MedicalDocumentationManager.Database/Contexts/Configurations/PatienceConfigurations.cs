using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalDocumentationManager.Database.Contexts.Configurations;

public class PatienceConfigurations : IEntityTypeConfiguration<PatientEntity>
{
    public void Configure(EntityTypeBuilder<PatientEntity> builder)
    {
        builder.HasIndex(b => b.Email).IsUnique();
        builder.HasIndex(b => b.PhoneNumber).IsUnique();
        builder.HasIndex(b => b.InsurancePolicyNumber).IsUnique();

        builder
            .HasMany(d => d.Subscriptions)
            .WithOne(a => a.PatientEntity)
            .HasForeignKey(d => d.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}