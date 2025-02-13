﻿// <auto-generated />

#nullable disable

using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalDocumentationManager.Database.Migrations
{
    [DbContext(typeof(MedicalDocumentationManagerDbContext))]
    [Migration("20240608124409_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.AddressEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AddressEntities");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.DoctorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ExperienceInYears")
                        .HasColumnType("bigint");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("DoctorEntities");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.MedicalRecordEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("Record")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalRecordEntities");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.PatientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("AddressId")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InsurancePolicyNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InsuranceProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("InsurancePolicyNumber")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("PatientEntities");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.SubscriptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("MedicalRecordId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MedicalRecordId");

                    b.HasIndex("PatientId");

                    b.ToTable("SubscriptionEntities");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.DoctorEntity", b =>
                {
                    b.HasOne("MedicalDocumentationManager.Database.Entities.AddressEntity", "AddressEntity")
                        .WithMany("Doctors")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AddressEntity");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.MedicalRecordEntity", b =>
                {
                    b.HasOne("MedicalDocumentationManager.Database.Entities.DoctorEntity", "DoctorEntity")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MedicalDocumentationManager.Database.Entities.PatientEntity", "PatientEntity")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DoctorEntity");

                    b.Navigation("PatientEntity");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.PatientEntity", b =>
                {
                    b.HasOne("MedicalDocumentationManager.Database.Entities.AddressEntity", "AddressEntity")
                        .WithMany("Patients")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AddressEntity");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.SubscriptionEntity", b =>
                {
                    b.HasOne("MedicalDocumentationManager.Database.Entities.MedicalRecordEntity", "MedicalRecordEntity")
                        .WithMany("Subscriptions")
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalDocumentationManager.Database.Entities.PatientEntity", "PatientEntity")
                        .WithMany("Subscriptions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalRecordEntity");

                    b.Navigation("PatientEntity");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.AddressEntity", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.DoctorEntity", b =>
                {
                    b.Navigation("MedicalRecords");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.MedicalRecordEntity", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("MedicalDocumentationManager.Database.Entities.PatientEntity", b =>
                {
                    b.Navigation("MedicalRecords");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
