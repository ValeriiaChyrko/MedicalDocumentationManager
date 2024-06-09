using MedicalDocumentationManager.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalDocumentationManager.Persistence.Contexts.Configurations;

internal class AddressConfigurations : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder
            .HasMany(d => d.Doctors)
            .WithOne(a => a.AddressEntity)
            .HasForeignKey(d => d.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasMany(d => d.Patients)
            .WithOne(a => a.AddressEntity)
            .HasForeignKey(d => d.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}