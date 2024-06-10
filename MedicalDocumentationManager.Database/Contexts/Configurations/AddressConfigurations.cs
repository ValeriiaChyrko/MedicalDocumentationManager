using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalDocumentationManager.Database.Contexts.Configurations;

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
        
        builder
            .HasIndex(a => new { a.Street, a.City, a.State, a.Zip })
            .IsUnique();
    }
}