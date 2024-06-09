using MedicalDocumentationManager.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalDocumentationManager.Persistence.Contexts.Configurations;

internal class DoctorConfigurations : IEntityTypeConfiguration<DoctorEntity>
{
    public void Configure(EntityTypeBuilder<DoctorEntity> builder)
    {
        builder.HasIndex(b => b.Email).IsUnique();
        builder.HasIndex(b => b.PhoneNumber).IsUnique();
    }
}