using MedicalDocumentationManager.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalDocumentationManager.Database.Contexts.Configurations;

internal class DoctorConfigurations : IEntityTypeConfiguration<DoctorEntity>
{
    public void Configure(EntityTypeBuilder<DoctorEntity> builder)
    {
        builder.HasIndex(b => b.Email).IsUnique();
        builder.HasIndex(b => b.PhoneNumber).IsUnique();
    }
}