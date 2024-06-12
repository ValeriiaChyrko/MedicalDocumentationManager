#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MedicalDocumentationManager.Database.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "AddressEntities",
            table => new
            {
                Id = table.Column<long>("bigint", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Street = table.Column<string>("text", nullable: false),
                City = table.Column<string>("text", nullable: false),
                State = table.Column<string>("text", nullable: false),
                Zip = table.Column<string>("text", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_AddressEntities", x => x.Id); });

        migrationBuilder.CreateTable(
            "DoctorEntities",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                FullName = table.Column<string>("text", nullable: false),
                BirthDate = table.Column<DateOnly>("date", nullable: false),
                AddressId = table.Column<long>("bigint", nullable: false),
                PhoneNumber = table.Column<string>("text", nullable: false),
                Email = table.Column<string>("text", nullable: false),
                Specialization = table.Column<string>("text", nullable: false),
                ExperienceInYears = table.Column<long>("bigint", nullable: false),
                Education = table.Column<string>("text", nullable: false),
                RoomNumber = table.Column<string>("text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DoctorEntities", x => x.Id);
                table.ForeignKey(
                    "FK_DoctorEntities_AddressEntities_AddressId",
                    x => x.AddressId,
                    "AddressEntities",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "PatientEntities",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                FullName = table.Column<string>("text", nullable: false),
                BirthDate = table.Column<DateOnly>("date", nullable: false),
                AddressId = table.Column<long>("bigint", nullable: false),
                PhoneNumber = table.Column<string>("text", nullable: false),
                Email = table.Column<string>("text", nullable: false),
                InsuranceProvider = table.Column<string>("text", nullable: false),
                InsurancePolicyNumber = table.Column<string>("text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PatientEntities", x => x.Id);
                table.ForeignKey(
                    "FK_PatientEntities_AddressEntities_AddressId",
                    x => x.AddressId,
                    "AddressEntities",
                    "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            "MedicalRecordEntities",
            table => new
            {
                Id = table.Column<Guid>("uuid", nullable: false),
                PatientId = table.Column<Guid>("uuid", nullable: false),
                DoctorId = table.Column<Guid>("uuid", nullable: false),
                Record = table.Column<string>("text", nullable: false),
                CreatedAt = table.Column<DateTime>("timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>("timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MedicalRecordEntities", x => x.Id);
                table.ForeignKey(
                    "FK_MedicalRecordEntities_DoctorEntities_DoctorId",
                    x => x.DoctorId,
                    "DoctorEntities",
                    "Id");
                table.ForeignKey(
                    "FK_MedicalRecordEntities_PatientEntities_PatientId",
                    x => x.PatientId,
                    "PatientEntities",
                    "Id");
            });

        migrationBuilder.CreateTable(
            "SubscriptionEntities",
            table => new
            {
                Id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                PatientId = table.Column<Guid>("uuid", nullable: false),
                MedicalRecordId = table.Column<Guid>("uuid", nullable: false),
                SubscriptionType = table.Column<string>("text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SubscriptionEntities", x => x.Id);
                table.ForeignKey(
                    "FK_SubscriptionEntities_MedicalRecordEntities_MedicalRecordId",
                    x => x.MedicalRecordId,
                    "MedicalRecordEntities",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_SubscriptionEntities_PatientEntities_PatientId",
                    x => x.PatientId,
                    "PatientEntities",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_DoctorEntities_AddressId",
            "DoctorEntities",
            "AddressId");

        migrationBuilder.CreateIndex(
            "IX_DoctorEntities_Email",
            "DoctorEntities",
            "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_DoctorEntities_PhoneNumber",
            "DoctorEntities",
            "PhoneNumber",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_MedicalRecordEntities_DoctorId",
            "MedicalRecordEntities",
            "DoctorId");

        migrationBuilder.CreateIndex(
            "IX_MedicalRecordEntities_PatientId",
            "MedicalRecordEntities",
            "PatientId");

        migrationBuilder.CreateIndex(
            "IX_PatientEntities_AddressId",
            "PatientEntities",
            "AddressId");

        migrationBuilder.CreateIndex(
            "IX_PatientEntities_Email",
            "PatientEntities",
            "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_PatientEntities_InsurancePolicyNumber",
            "PatientEntities",
            "InsurancePolicyNumber",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_PatientEntities_PhoneNumber",
            "PatientEntities",
            "PhoneNumber",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_SubscriptionEntities_MedicalRecordId",
            "SubscriptionEntities",
            "MedicalRecordId");

        migrationBuilder.CreateIndex(
            "IX_SubscriptionEntities_PatientId",
            "SubscriptionEntities",
            "PatientId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "SubscriptionEntities");

        migrationBuilder.DropTable(
            "MedicalRecordEntities");

        migrationBuilder.DropTable(
            "DoctorEntities");

        migrationBuilder.DropTable(
            "PatientEntities");

        migrationBuilder.DropTable(
            "AddressEntities");
    }
}