#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MedicalDocumentationManager.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressEntities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Specialization = table.Column<string>(type: "text", nullable: false),
                    ExperienceInYears = table.Column<long>(type: "bigint", nullable: false),
                    Education = table.Column<string>(type: "text", nullable: false),
                    RoomNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorEntities_AddressEntities_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    InsuranceProvider = table.Column<string>(type: "text", nullable: false),
                    InsurancePolicyNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientEntities_AddressEntities_AddressId",
                        column: x => x.AddressId,
                        principalTable: "AddressEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecordEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Record = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecordEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecordEntities_DoctorEntities_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "DoctorEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalRecordEntities_PatientEntities_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientEntities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionEntities_MedicalRecordEntities_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecordEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionEntities_PatientEntities_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEntities_AddressId",
                table: "DoctorEntities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEntities_Email",
                table: "DoctorEntities",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEntities_PhoneNumber",
                table: "DoctorEntities",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntities_DoctorId",
                table: "MedicalRecordEntities",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntities_PatientId",
                table: "MedicalRecordEntities",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEntities_AddressId",
                table: "PatientEntities",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientEntities_Email",
                table: "PatientEntities",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientEntities_InsurancePolicyNumber",
                table: "PatientEntities",
                column: "InsurancePolicyNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientEntities_PhoneNumber",
                table: "PatientEntities",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionEntities_MedicalRecordId",
                table: "SubscriptionEntities",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionEntities_PatientId",
                table: "SubscriptionEntities",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionEntities");

            migrationBuilder.DropTable(
                name: "MedicalRecordEntities");

            migrationBuilder.DropTable(
                name: "DoctorEntities");

            migrationBuilder.DropTable(
                name: "PatientEntities");

            migrationBuilder.DropTable(
                name: "AddressEntities");
        }
    }
}
