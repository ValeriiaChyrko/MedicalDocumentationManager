#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalDocumentationManager.Database.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("40bc2fbd-e28a-4f9c-96e0-4c7e61cecb3b"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("49e28d01-2067-4d9e-a086-556be1e39ed3"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("81968a99-7398-4900-a6e5-9a1412171465"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("c17268dc-5e86-48c6-bf7f-bb0211a34597"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("0c046b8d-a551-4fd3-aceb-074b82ffb4a8"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("0d2a9c25-3e6e-483d-a5c0-2547d5748934"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("0ecd7d76-e6be-4670-a244-e6aa4a4ba521"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("105d5675-08a4-4c9f-836d-bdb854eb768d"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("18a56a17-d8f2-4ca3-8c2c-521b0901c8e2"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("1dcc8a35-cf12-4415-b663-f70aa65b2c9d"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("3429bfdb-3329-4c36-8100-92aef6c397af"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("53a3cfc2-cb2d-4bb7-859f-b7c2b39fd06c"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("605d9a42-dcdb-44b5-abeb-42561d787886"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("7d98a5f3-c3b6-4805-92fa-7727100a1d57"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("94f20bb9-db5e-4d5d-870b-a5c8a957a952"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("9ad502c0-f6ed-4218-bc5a-c312540f8ede"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("aa65dd8a-868c-40ca-9587-819f774ee3b3"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("aaf9fc1a-4568-4d7e-b67b-3bd1c4cc8723"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("b19e9788-a9e1-4219-89e9-8b94f2bda161"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("b7449f37-34c2-4691-bd25-b2d136ad48bf"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("bedf1488-76ea-49e5-b68c-b651434e005b"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("c0e98bac-aaa0-4292-a6f3-79f32b8b5548"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("ca25957b-d494-4d9d-bd23-e48b31b01690"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("ce814387-a5fd-493b-b140-ec4909daaabf"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("cf4c8a2c-6641-4cf3-b637-224e01439d1f"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("feadd605-be98-4f27-8513-2e90d9e331f0"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("4941f913-50d9-478c-8023-47ca581018b5"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("63ce2675-2880-4359-a842-7d92a3e5d478"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("d967207e-5cf9-43a0-8dc5-88184da40fbd"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("da630793-8f6d-456d-8c9b-6ee2d601e293"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("e592809c-495b-4a54-af87-ff2a4dc2c0f1"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("7aa0a526-a3ea-4f8a-a7f4-83d129145930"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"));

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "New York", "TX", "Cedar Ln", "62938" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Chicago", "NY", "Washington Ave", "63525" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "City", "State", "Zip" },
                values: new object[] { "San Antonio", "TX", "28391" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Philadelphia", "TX", "Maple Ave", "31653" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "City", "Zip" },
                values: new object[] { "San Jose", "30857" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "City", "Street", "Zip" },
                values: new object[] { "Houston", "Pine St", "87519" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Los Angeles", "TX", "Main St", "79545" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "State", "Street", "Zip" },
                values: new object[] { "TX", "Maple Ave", "37241" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Phoenix", "IL", "Washington Ave", "95257" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Diego", "CA", "Highland Ave", "64316" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Philadelphia", "CA", "Broadway", "96286" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "City", "Zip" },
                values: new object[] { "Houston", "33430" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Jose", "NY", "Pine St", "66242" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Philadelphia", "IL", "Washington Ave", "83399" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Antonio", "CA", "Sunset Blvd", "47465" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "Street", "Zip" },
                values: new object[] { "Maple Ave", "11116" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "City", "Street", "Zip" },
                values: new object[] { "Philadelphia", "Pine St", "58277" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Houston", "IL", "Main St", "48687" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "State", "Street", "Zip" },
                values: new object[] { "PA", "Cedar Ln", "33206" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "New York", "TX", "Elm St", "49897" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "City", "Street", "Zip" },
                values: new object[] { "Phoenix", "Maple Ave", "25255" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Dallas", "AZ", "Broadway", "13349" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Diego", "CA", "Oak St", "18220" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Los Angeles", "IL", "Highland Ave", "10741" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "City", "State", "Zip" },
                values: new object[] { "San Jose", "PA", "68823" });

            migrationBuilder.InsertData(
                table: "DoctorEntities",
                columns: new[] { "Id", "AddressId", "BirthDate", "Education", "Email", "ExperienceInYears", "FullName", "PhoneNumber", "RoomNumber", "Specialization" },
                values: new object[,]
                {
                    { new Guid("013cb794-a21b-45a5-a678-5dcce26be03e"), 1L, new DateOnly(1997, 7, 24), "Medical Degree", "james.jones7@aol.com", 4L, "James Jones", "+1-999-361-2192", "D-502", "Orthopedics" },
                    { new Guid("1345f6de-2771-46d4-9f77-a4e05956c87e"), 12L, new DateOnly(1965, 9, 6), "Medical Degree", "john.smith7@gmail.com", 23L, "John Smith", "+1-888-592-4121", "B-344", "Pediatrics" },
                    { new Guid("1e12dcc5-2e38-44d3-9f5a-073574fc6922"), 3L, new DateOnly(1969, 6, 9), "Medical Degree", "emma.brown3@hotmail.com", 2L, "Emma Brown", "+1-666-327-5395", "C-833", "Cardiology" },
                    { new Guid("22576f99-412a-4956-aec6-bf1da155fffc"), 23L, new DateOnly(1996, 2, 12), "Medical Degree", "michael.williams2@outlook.com", 26L, "Michael Williams", "+1-777-237-4183", "E-366", "Cardiology" },
                    { new Guid("31e273ed-bb90-4ecb-9b04-b4da014f895e"), 20L, new DateOnly(1955, 2, 11), "Medical Degree", "emily.johnson1@yahoo.com", 28L, "Emily Johnson", "+1-999-547-2482", "B-437", "Orthopedics" },
                    { new Guid("42951efb-c4ad-4cb7-8ccd-6747c3842f4c"), 15L, new DateOnly(1977, 11, 14), "Medical Degree", "john.smith2@yahoo.com", 17L, "John Smith", "+1-555-693-4716", "A-226", "Oncology" },
                    { new Guid("5cc0d903-59fd-48b7-9e14-6495a0e78a2d"), 6L, new DateOnly(1990, 1, 9), "Medical Degree", "james.jones7@outlook.com", 11L, "James Jones", "+1-666-262-8868", "B-372", "Orthopedics" },
                    { new Guid("63ada4f7-602e-4452-8b87-37ca17b66de8"), 19L, new DateOnly(1958, 6, 5), "Medical Degree", "emma.brown5@yahoo.com", 18L, "Emma Brown", "+1-666-834-2483", "D-319", "Orthopedics" },
                    { new Guid("9494b0d4-ae59-4812-9b25-05fee61fc6e5"), 2L, new DateOnly(1987, 5, 12), "Medical Degree", "james.jones7@hotmail.com", 17L, "James Jones", "+1-555-206-5187", "D-456", "Cardiology" },
                    { new Guid("bd080fc2-856e-416e-a698-90a7e5bda48a"), 2L, new DateOnly(1984, 3, 20), "Medical Degree", "emma.brown2@gmail.com", 30L, "Emma Brown", "+1-777-584-7011", "D-439", "Cardiology" },
                    { new Guid("ceb037f8-430e-43e5-a394-786daf2891f2"), 10L, new DateOnly(1974, 6, 15), "Medical Degree", "emma.brown0@hotmail.com", 25L, "Emma Brown", "+1-888-529-7395", "E-561", "Pediatrics" },
                    { new Guid("e43570fe-4aa4-4a9b-abc2-e6ae573ba2a3"), 23L, new DateOnly(1988, 12, 13), "Medical Degree", "john.smith0@yahoo.com", 18L, "John Smith", "+1-999-981-8955", "E-271", "Oncology" },
                    { new Guid("e5e17ffd-ed56-4335-bcc1-205e6364efa8"), 7L, new DateOnly(1951, 11, 5), "Medical Degree", "emily.johnson4@hotmail.com", 16L, "Emily Johnson", "+1-888-826-1597", "C-551", "Oncology" },
                    { new Guid("ebea2a4a-f8c3-4d85-ade2-4a9aafc1f1e8"), 13L, new DateOnly(1987, 4, 20), "Medical Degree", "emily.johnson6@outlook.com", 6L, "Emily Johnson", "+1-666-584-9061", "E-396", "Orthopedics" },
                    { new Guid("ef0222ff-5282-4b29-a62f-71d853c0aaff"), 16L, new DateOnly(1976, 4, 21), "Medical Degree", "emma.brown0@aol.com", 9L, "Emma Brown", "+1-666-757-1347", "D-458", "Orthopedics" }
                });

            migrationBuilder.InsertData(
                table: "PatientEntities",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "FullName", "InsurancePolicyNumber", "InsuranceProvider", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("00fed484-9f9a-4339-bc08-d3c5e9467801"), 9L, new DateOnly(1974, 8, 20), "amelia.clark8@outlook.com", "Amelia Clark", "783225190", "Aetna", "+1-444-927-7906" },
                    { new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"), 8L, new DateOnly(1982, 9, 10), "mason.harris5@outlook.com", "Mason Harris", "738630681", "Oscar Health", "+1-222-749-9011" },
                    { new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"), 23L, new DateOnly(1968, 10, 10), "ethan.jackson4@gmail.com", "Ethan Jackson", "122785605", "Health Net", "+1-111-146-3560" },
                    { new Guid("460dbf3b-0312-4da5-895e-86834eb43b43"), 14L, new DateOnly(1990, 11, 6), "amelia.clark3@gmail.com", "Amelia Clark", "159637843", "Aetna", "+1-444-950-4514" },
                    { new Guid("589b5b02-38e4-4c53-a813-dd5021f6da39"), 9L, new DateOnly(1994, 10, 18), "daniel.johnson4@aol.com", "Daniel Johnson", "566915016", "Bright Health", "+1-111-494-3164" },
                    { new Guid("6b036ff0-f402-489e-bad7-f88dd8f23a81"), 20L, new DateOnly(1973, 12, 27), "mason.harris2@outlook.com", "Mason Harris", "141716852", "Health Net", "+1-111-733-6282" },
                    { new Guid("87e46f1c-885c-442e-b445-8d734797deeb"), 7L, new DateOnly(1954, 10, 22), "amelia.clark3@outlook.com", "Amelia Clark", "498497902", "Anthem", "+1-111-910-2133" },
                    { new Guid("8fb4f8c8-32d2-4cba-8fc5-33463f65fffa"), 18L, new DateOnly(1990, 9, 12), "ava.white1@outlook.com", "Ava White", "366797850", "Aetna", "+1-222-545-2774" },
                    { new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095"), 14L, new DateOnly(1968, 7, 9), "ethan.jackson7@outlook.com", "Ethan Jackson", "559517151", "Molina Healthcare", "+1-222-840-4085" },
                    { new Guid("a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0"), 8L, new DateOnly(1958, 2, 12), "ava.white9@aol.com", "Ava White", "596000616", "Friday Health Plans", "+1-333-854-1552" },
                    { new Guid("af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8"), 2L, new DateOnly(1991, 3, 4), "ava.white0@aol.com", "Ava White", "457438627", "Bright Health", "+1-111-279-5968" },
                    { new Guid("bf2bae64-5991-4ca2-8231-6083c7e009ae"), 5L, new DateOnly(1963, 8, 25), "sophia.taylor2@outlook.com", "Sophia Taylor", "738055621", "Oxford Health Plans", "+1-333-337-1587" },
                    { new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8"), 4L, new DateOnly(1994, 6, 18), "ethan.jackson2@hotmail.com", "Ethan Jackson", "809307597", "Oxford Health Plans", "+1-333-664-5474" },
                    { new Guid("ed2b29cc-0fa4-42dc-b373-e3800af239ef"), 17L, new DateOnly(1959, 3, 15), "sophia.taylor3@yahoo.com", "Sophia Taylor", "112118029", "Oscar Health", "+1-222-296-3129" },
                    { new Guid("f4982d4f-f4dc-4268-bd99-1327918ad120"), 2L, new DateOnly(1971, 1, 11), "amelia.clark9@hotmail.com", "Amelia Clark", "217106838", "Oxford Health Plans", "+1-111-359-7582" }
                });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("08dffb4a-2a7e-47a3-98b3-0caa774a297a"), new Guid("8fb4f8c8-32d2-4cba-8fc5-33463f65fffa") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("25aaf1c2-4e2b-4946-b2f4-f2034e8002de"), new Guid("00fed484-9f9a-4339-bc08-d3c5e9467801") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("43c2d659-876f-4d60-b974-62778c8bdf8f"), new Guid("bf2bae64-5991-4ca2-8231-6083c7e009ae") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("43c2d659-876f-4d60-b974-62778c8bdf8f"), new Guid("460dbf3b-0312-4da5-895e-86834eb43b43") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("692f03b9-ffcc-4a1e-96f8-2dd0e802023d"), new Guid("589b5b02-38e4-4c53-a813-dd5021f6da39"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("8c69d425-f59a-4770-a495-5a47d3225e4b"), new Guid("a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("9cd0a48c-8bab-4ccb-a0e1-f6a01d4acfbf"), new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("e478d4f9-53c2-4fd4-9728-648fe750f13a"), new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("43c2d659-876f-4d60-b974-62778c8bdf8f"), new Guid("87e46f1c-885c-442e-b445-8d734797deeb"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("4046602e-2e70-469f-8b56-096a360bd0ff"), new Guid("589b5b02-38e4-4c53-a813-dd5021f6da39"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("3b91cc7e-c889-47c3-9cc3-b645c7175698"), new Guid("6b036ff0-f402-489e-bad7-f88dd8f23a81"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("43c2d659-876f-4d60-b974-62778c8bdf8f"), new Guid("ed2b29cc-0fa4-42dc-b373-e3800af239ef") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("8c69d425-f59a-4770-a495-5a47d3225e4b"), new Guid("589b5b02-38e4-4c53-a813-dd5021f6da39"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("e73d1adb-dabb-4486-b8c4-ad7dd35b7a8a"), new Guid("f4982d4f-f4dc-4268-bd99-1327918ad120") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("043d5d32-578b-4281-85c4-948ba1b8d48c"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("7edef27a-7feb-45fe-a297-68fc46908921"), new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("043d5d32-578b-4281-85c4-948ba1b8d48c"), new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("9e91cf2a-78d8-49a6-bd01-1e89b9b51ddd"), new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("7edef27a-7feb-45fe-a297-68fc46908921"), new Guid("af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("043d5d32-578b-4281-85c4-948ba1b8d48c"), new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("eaeca881-df6d-441d-a31a-af0ee0bbfaa1"), new Guid("f4982d4f-f4dc-4268-bd99-1327918ad120"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("08dffb4a-2a7e-47a3-98b3-0caa774a297a"), new Guid("460dbf3b-0312-4da5-895e-86834eb43b43"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("9e91cf2a-78d8-49a6-bd01-1e89b9b51ddd"), new Guid("87e46f1c-885c-442e-b445-8d734797deeb"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("25aaf1c2-4e2b-4946-b2f4-f2034e8002de"), new Guid("460dbf3b-0312-4da5-895e-86834eb43b43") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("9e91cf2a-78d8-49a6-bd01-1e89b9b51ddd"), new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("33111f91-72f3-4287-a135-e8c3935e51c3"), new Guid("00fed484-9f9a-4339-bc08-d3c5e9467801") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("3037466f-e974-48c8-98f2-fb823ba1a833"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("90252700-eb4c-441a-b1fa-cf68e16dd826"), new Guid("ed2b29cc-0fa4-42dc-b373-e3800af239ef"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("25aaf1c2-4e2b-4946-b2f4-f2034e8002de"), new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("08dffb4a-2a7e-47a3-98b3-0caa774a297a"), new Guid("6b036ff0-f402-489e-bad7-f88dd8f23a81") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("90252700-eb4c-441a-b1fa-cf68e16dd826"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("08dffb4a-2a7e-47a3-98b3-0caa774a297a"), new Guid("6b036ff0-f402-489e-bad7-f88dd8f23a81") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("5e3c7a5e-9d95-4200-8c4f-1bec92a0aafa"), new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("7c177960-96ae-4418-a3dc-3e42cf399ec0"), new Guid("af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("e478d4f9-53c2-4fd4-9728-648fe750f13a"), new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("6eb8aa5b-33b8-4c99-9e04-0af0be9cda0c"), new Guid("460dbf3b-0312-4da5-895e-86834eb43b43"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("9cd0a48c-8bab-4ccb-a0e1-f6a01d4acfbf"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("90252700-eb4c-441a-b1fa-cf68e16dd826"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("cc832aa3-44ae-4310-ae9b-3b08ec8fdcf9"), new Guid("af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("5e3c7a5e-9d95-4200-8c4f-1bec92a0aafa"), new Guid("00fed484-9f9a-4339-bc08-d3c5e9467801"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("8c69d425-f59a-4770-a495-5a47d3225e4b"), new Guid("a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("e607ebfa-fa1f-48d0-833b-b848ea923eca"), new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("692f03b9-ffcc-4a1e-96f8-2dd0e802023d"), new Guid("00fed484-9f9a-4339-bc08-d3c5e9467801") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("3b91cc7e-c889-47c3-9cc3-b645c7175698"), new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("7c177960-96ae-4418-a3dc-3e42cf399ec0"), new Guid("589b5b02-38e4-4c53-a813-dd5021f6da39"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("e478d4f9-53c2-4fd4-9728-648fe750f13a"), new Guid("8fb4f8c8-32d2-4cba-8fc5-33463f65fffa") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("09a59ed7-016a-4fe2-a030-d77db56e53f1"), new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("8c69d425-f59a-4770-a495-5a47d3225e4b"), new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("6893e409-cd81-443d-93cf-ce5f962f2412"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("4a2c65cf-e17d-404f-9795-bd72fd725375"), new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c") });

            migrationBuilder.InsertData(
                table: "MedicalRecordEntities",
                columns: new[] { "Id", "CreatedAt", "DoctorId", "PatientId", "Record", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("043d5d32-578b-4281-85c4-948ba1b8d48c"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6461), new Guid("42951efb-c4ad-4cb7-8ccd-6747c3842f4c"), new Guid("6b036ff0-f402-489e-bad7-f88dd8f23a81"), "Medical record 2 for patient 6b036ff0-f402-489e-bad7-f88dd8f23a81 and doctor 42951efb-c4ad-4cb7-8ccd-6747c3842f4c", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6461) },
                    { new Guid("08dffb4a-2a7e-47a3-98b3-0caa774a297a"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6759), new Guid("1345f6de-2771-46d4-9f77-a4e05956c87e"), new Guid("ed2b29cc-0fa4-42dc-b373-e3800af239ef"), "Medical record 17 for patient ed2b29cc-0fa4-42dc-b373-e3800af239ef and doctor 1345f6de-2771-46d4-9f77-a4e05956c87e", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6760) },
                    { new Guid("09a59ed7-016a-4fe2-a030-d77db56e53f1"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6723), new Guid("bd080fc2-856e-416e-a698-90a7e5bda48a"), new Guid("a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0"), "Medical record 14 for patient a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0 and doctor bd080fc2-856e-416e-a698-90a7e5bda48a", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6724) },
                    { new Guid("25aaf1c2-4e2b-4946-b2f4-f2034e8002de"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6652), new Guid("e5e17ffd-ed56-4335-bcc1-205e6364efa8"), new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"), "Medical record 7 for patient 293a3eb3-7212-424a-bec5-d6b37f51841c and doctor e5e17ffd-ed56-4335-bcc1-205e6364efa8", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6653) },
                    { new Guid("2e7251c3-67f1-44b5-b144-85b0fbd6658a"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6919), new Guid("ceb037f8-430e-43e5-a394-786daf2891f2"), new Guid("bf2bae64-5991-4ca2-8231-6083c7e009ae"), "Medical record 28 for patient bf2bae64-5991-4ca2-8231-6083c7e009ae and doctor ceb037f8-430e-43e5-a394-786daf2891f2", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6920) },
                    { new Guid("3037466f-e974-48c8-98f2-fb823ba1a833"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6623), new Guid("e43570fe-4aa4-4a9b-abc2-e6ae573ba2a3"), new Guid("460dbf3b-0312-4da5-895e-86834eb43b43"), "Medical record 6 for patient 460dbf3b-0312-4da5-895e-86834eb43b43 and doctor e43570fe-4aa4-4a9b-abc2-e6ae573ba2a3", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6624) },
                    { new Guid("33111f91-72f3-4287-a135-e8c3935e51c3"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6782), new Guid("ef0222ff-5282-4b29-a62f-71d853c0aaff"), new Guid("460dbf3b-0312-4da5-895e-86834eb43b43"), "Medical record 19 for patient 460dbf3b-0312-4da5-895e-86834eb43b43 and doctor ef0222ff-5282-4b29-a62f-71d853c0aaff", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6783) },
                    { new Guid("3b91cc7e-c889-47c3-9cc3-b645c7175698"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6834), new Guid("ef0222ff-5282-4b29-a62f-71d853c0aaff"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8"), "Medical record 24 for patient e073a299-2f0c-4584-bf4c-2278e935cdd8 and doctor ef0222ff-5282-4b29-a62f-71d853c0aaff", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6835) },
                    { new Guid("4046602e-2e70-469f-8b56-096a360bd0ff"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6772), new Guid("31e273ed-bb90-4ecb-9b04-b4da014f895e"), new Guid("ed2b29cc-0fa4-42dc-b373-e3800af239ef"), "Medical record 18 for patient ed2b29cc-0fa4-42dc-b373-e3800af239ef and doctor 31e273ed-bb90-4ecb-9b04-b4da014f895e", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6772) },
                    { new Guid("43c2d659-876f-4d60-b974-62778c8bdf8f"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6810), new Guid("013cb794-a21b-45a5-a678-5dcce26be03e"), new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"), "Medical record 22 for patient 0f9e953b-5402-42f6-ab5e-3badc7ea1309 and doctor 013cb794-a21b-45a5-a678-5dcce26be03e", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6811) },
                    { new Guid("4a12586c-2f89-42b7-b697-4f1260055486"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6473), new Guid("42951efb-c4ad-4cb7-8ccd-6747c3842f4c"), new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095"), "Medical record 3 for patient 910c3e7e-a55f-4844-b5cd-ce831e0fa095 and doctor 42951efb-c4ad-4cb7-8ccd-6747c3842f4c", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6474) },
                    { new Guid("4a2c65cf-e17d-404f-9795-bd72fd725375"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6485), new Guid("22576f99-412a-4956-aec6-bf1da155fffc"), new Guid("87e46f1c-885c-442e-b445-8d734797deeb"), "Medical record 4 for patient 87e46f1c-885c-442e-b445-8d734797deeb and doctor 22576f99-412a-4956-aec6-bf1da155fffc", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6486) },
                    { new Guid("5898d1f4-ec6f-4634-bd5d-b3ec2fd508ad"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6750), new Guid("013cb794-a21b-45a5-a678-5dcce26be03e"), new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"), "Medical record 16 for patient 0f9e953b-5402-42f6-ab5e-3badc7ea1309 and doctor 013cb794-a21b-45a5-a678-5dcce26be03e", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6751) },
                    { new Guid("5e3c7a5e-9d95-4200-8c4f-1bec92a0aafa"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6714), new Guid("013cb794-a21b-45a5-a678-5dcce26be03e"), new Guid("6b036ff0-f402-489e-bad7-f88dd8f23a81"), "Medical record 13 for patient 6b036ff0-f402-489e-bad7-f88dd8f23a81 and doctor 013cb794-a21b-45a5-a678-5dcce26be03e", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6715) },
                    { new Guid("6893e409-cd81-443d-93cf-ce5f962f2412"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6790), new Guid("1345f6de-2771-46d4-9f77-a4e05956c87e"), new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"), "Medical record 20 for patient 0f9e953b-5402-42f6-ab5e-3badc7ea1309 and doctor 1345f6de-2771-46d4-9f77-a4e05956c87e", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6791) },
                    { new Guid("692f03b9-ffcc-4a1e-96f8-2dd0e802023d"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6739), new Guid("013cb794-a21b-45a5-a678-5dcce26be03e"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8"), "Medical record 15 for patient e073a299-2f0c-4584-bf4c-2278e935cdd8 and doctor 013cb794-a21b-45a5-a678-5dcce26be03e", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6740) },
                    { new Guid("6eb8aa5b-33b8-4c99-9e04-0af0be9cda0c"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6684), new Guid("e5e17ffd-ed56-4335-bcc1-205e6364efa8"), new Guid("a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0"), "Medical record 10 for patient a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0 and doctor e5e17ffd-ed56-4335-bcc1-205e6364efa8", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6685) },
                    { new Guid("7c177960-96ae-4418-a3dc-3e42cf399ec0"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6802), new Guid("5cc0d903-59fd-48b7-9e14-6495a0e78a2d"), new Guid("8fb4f8c8-32d2-4cba-8fc5-33463f65fffa"), "Medical record 21 for patient 8fb4f8c8-32d2-4cba-8fc5-33463f65fffa and doctor 5cc0d903-59fd-48b7-9e14-6495a0e78a2d", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6803) },
                    { new Guid("7edef27a-7feb-45fe-a297-68fc46908921"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6845), new Guid("63ada4f7-602e-4452-8b87-37ca17b66de8"), new Guid("f4982d4f-f4dc-4268-bd99-1327918ad120"), "Medical record 25 for patient f4982d4f-f4dc-4268-bd99-1327918ad120 and doctor 63ada4f7-602e-4452-8b87-37ca17b66de8", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6846) },
                    { new Guid("8c69d425-f59a-4770-a495-5a47d3225e4b"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6703), new Guid("42951efb-c4ad-4cb7-8ccd-6747c3842f4c"), new Guid("af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8"), "Medical record 12 for patient af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8 and doctor 42951efb-c4ad-4cb7-8ccd-6747c3842f4c", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6703) },
                    { new Guid("90252700-eb4c-441a-b1fa-cf68e16dd826"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6039), new Guid("e5e17ffd-ed56-4335-bcc1-205e6364efa8"), new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8"), "Medical record 1 for patient e073a299-2f0c-4584-bf4c-2278e935cdd8 and doctor e5e17ffd-ed56-4335-bcc1-205e6364efa8", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6342) },
                    { new Guid("9cd0a48c-8bab-4ccb-a0e1-f6a01d4acfbf"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6662), new Guid("bd080fc2-856e-416e-a698-90a7e5bda48a"), new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095"), "Medical record 8 for patient 910c3e7e-a55f-4844-b5cd-ce831e0fa095 and doctor bd080fc2-856e-416e-a698-90a7e5bda48a", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6663) },
                    { new Guid("9e91cf2a-78d8-49a6-bd01-1e89b9b51ddd"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6909), new Guid("1345f6de-2771-46d4-9f77-a4e05956c87e"), new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"), "Medical record 27 for patient 293a3eb3-7212-424a-bec5-d6b37f51841c and doctor 1345f6de-2771-46d4-9f77-a4e05956c87e", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6910) },
                    { new Guid("bd59dabd-3396-47eb-8faa-5790bbeda62b"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6497), new Guid("bd080fc2-856e-416e-a698-90a7e5bda48a"), new Guid("ed2b29cc-0fa4-42dc-b373-e3800af239ef"), "Medical record 5 for patient ed2b29cc-0fa4-42dc-b373-e3800af239ef and doctor bd080fc2-856e-416e-a698-90a7e5bda48a", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6497) },
                    { new Guid("cc832aa3-44ae-4310-ae9b-3b08ec8fdcf9"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6692), new Guid("bd080fc2-856e-416e-a698-90a7e5bda48a"), new Guid("a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0"), "Medical record 11 for patient a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0 and doctor bd080fc2-856e-416e-a698-90a7e5bda48a", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6693) },
                    { new Guid("d4f0c5e3-f275-4317-9591-24e3a348299a"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6937), new Guid("e43570fe-4aa4-4a9b-abc2-e6ae573ba2a3"), new Guid("bf2bae64-5991-4ca2-8231-6083c7e009ae"), "Medical record 30 for patient bf2bae64-5991-4ca2-8231-6083c7e009ae and doctor e43570fe-4aa4-4a9b-abc2-e6ae573ba2a3", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6938) },
                    { new Guid("e478d4f9-53c2-4fd4-9728-648fe750f13a"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6855), new Guid("e43570fe-4aa4-4a9b-abc2-e6ae573ba2a3"), new Guid("af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8"), "Medical record 26 for patient af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8 and doctor e43570fe-4aa4-4a9b-abc2-e6ae573ba2a3", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6856) },
                    { new Guid("e607ebfa-fa1f-48d0-833b-b848ea923eca"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6670), new Guid("bd080fc2-856e-416e-a698-90a7e5bda48a"), new Guid("460dbf3b-0312-4da5-895e-86834eb43b43"), "Medical record 9 for patient 460dbf3b-0312-4da5-895e-86834eb43b43 and doctor bd080fc2-856e-416e-a698-90a7e5bda48a", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6671) },
                    { new Guid("e73d1adb-dabb-4486-b8c4-ad7dd35b7a8a"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6928), new Guid("9494b0d4-ae59-4812-9b25-05fee61fc6e5"), new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"), "Medical record 29 for patient 0f9e953b-5402-42f6-ab5e-3badc7ea1309 and doctor 9494b0d4-ae59-4812-9b25-05fee61fc6e5", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6929) },
                    { new Guid("eaeca881-df6d-441d-a31a-af0ee0bbfaa1"), new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6824), new Guid("ceb037f8-430e-43e5-a394-786daf2891f2"), new Guid("ed2b29cc-0fa4-42dc-b373-e3800af239ef"), "Medical record 23 for patient ed2b29cc-0fa4-42dc-b373-e3800af239ef and doctor ceb037f8-430e-43e5-a394-786daf2891f2", new DateTime(2024, 6, 10, 8, 26, 48, 855, DateTimeKind.Utc).AddTicks(6825) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecordEntities_Record",
                table: "MedicalRecordEntities",
                column: "Record",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressEntities_Street_City_State_Zip",
                table: "AddressEntities",
                columns: new[] { "Street", "City", "State", "Zip" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MedicalRecordEntities_Record",
                table: "MedicalRecordEntities");

            migrationBuilder.DropIndex(
                name: "IX_AddressEntities_Street_City_State_Zip",
                table: "AddressEntities");

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("1e12dcc5-2e38-44d3-9f5a-073574fc6922"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("ebea2a4a-f8c3-4d85-ade2-4a9aafc1f1e8"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("043d5d32-578b-4281-85c4-948ba1b8d48c"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("08dffb4a-2a7e-47a3-98b3-0caa774a297a"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("09a59ed7-016a-4fe2-a030-d77db56e53f1"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("25aaf1c2-4e2b-4946-b2f4-f2034e8002de"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("2e7251c3-67f1-44b5-b144-85b0fbd6658a"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("3037466f-e974-48c8-98f2-fb823ba1a833"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("33111f91-72f3-4287-a135-e8c3935e51c3"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("3b91cc7e-c889-47c3-9cc3-b645c7175698"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("4046602e-2e70-469f-8b56-096a360bd0ff"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("43c2d659-876f-4d60-b974-62778c8bdf8f"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("4a12586c-2f89-42b7-b697-4f1260055486"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("4a2c65cf-e17d-404f-9795-bd72fd725375"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("5898d1f4-ec6f-4634-bd5d-b3ec2fd508ad"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("5e3c7a5e-9d95-4200-8c4f-1bec92a0aafa"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("6893e409-cd81-443d-93cf-ce5f962f2412"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("692f03b9-ffcc-4a1e-96f8-2dd0e802023d"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("6eb8aa5b-33b8-4c99-9e04-0af0be9cda0c"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("7c177960-96ae-4418-a3dc-3e42cf399ec0"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("7edef27a-7feb-45fe-a297-68fc46908921"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("8c69d425-f59a-4770-a495-5a47d3225e4b"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("90252700-eb4c-441a-b1fa-cf68e16dd826"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("9cd0a48c-8bab-4ccb-a0e1-f6a01d4acfbf"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("9e91cf2a-78d8-49a6-bd01-1e89b9b51ddd"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("bd59dabd-3396-47eb-8faa-5790bbeda62b"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("cc832aa3-44ae-4310-ae9b-3b08ec8fdcf9"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("d4f0c5e3-f275-4317-9591-24e3a348299a"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("e478d4f9-53c2-4fd4-9728-648fe750f13a"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("e607ebfa-fa1f-48d0-833b-b848ea923eca"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("e73d1adb-dabb-4486-b8c4-ad7dd35b7a8a"));

            migrationBuilder.DeleteData(
                table: "MedicalRecordEntities",
                keyColumn: "Id",
                keyValue: new Guid("eaeca881-df6d-441d-a31a-af0ee0bbfaa1"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("00fed484-9f9a-4339-bc08-d3c5e9467801"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("589b5b02-38e4-4c53-a813-dd5021f6da39"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("013cb794-a21b-45a5-a678-5dcce26be03e"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("1345f6de-2771-46d4-9f77-a4e05956c87e"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("22576f99-412a-4956-aec6-bf1da155fffc"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("31e273ed-bb90-4ecb-9b04-b4da014f895e"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("42951efb-c4ad-4cb7-8ccd-6747c3842f4c"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("5cc0d903-59fd-48b7-9e14-6495a0e78a2d"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("63ada4f7-602e-4452-8b87-37ca17b66de8"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("9494b0d4-ae59-4812-9b25-05fee61fc6e5"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("bd080fc2-856e-416e-a698-90a7e5bda48a"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("ceb037f8-430e-43e5-a394-786daf2891f2"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("e43570fe-4aa4-4a9b-abc2-e6ae573ba2a3"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("e5e17ffd-ed56-4335-bcc1-205e6364efa8"));

            migrationBuilder.DeleteData(
                table: "DoctorEntities",
                keyColumn: "Id",
                keyValue: new Guid("ef0222ff-5282-4b29-a62f-71d853c0aaff"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("0f9e953b-5402-42f6-ab5e-3badc7ea1309"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("293a3eb3-7212-424a-bec5-d6b37f51841c"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("460dbf3b-0312-4da5-895e-86834eb43b43"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("6b036ff0-f402-489e-bad7-f88dd8f23a81"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("87e46f1c-885c-442e-b445-8d734797deeb"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("8fb4f8c8-32d2-4cba-8fc5-33463f65fffa"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("910c3e7e-a55f-4844-b5cd-ce831e0fa095"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("a14e0b01-78d2-43bb-9c4e-e9075c3a7fa0"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("af5eb748-e0fa-4fb7-8b0f-6c40ae19e3c8"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("bf2bae64-5991-4ca2-8231-6083c7e009ae"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("e073a299-2f0c-4584-bf4c-2278e935cdd8"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("ed2b29cc-0fa4-42dc-b373-e3800af239ef"));

            migrationBuilder.DeleteData(
                table: "PatientEntities",
                keyColumn: "Id",
                keyValue: new Guid("f4982d4f-f4dc-4268-bd99-1327918ad120"));

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Houston", "IL", "Pine St", "59412" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Phoenix", "AZ", "Cedar Ln", "28511" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "City", "State", "Zip" },
                values: new object[] { "Phoenix", "CA", "62989" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Chicago", "CA", "Broadway", "89195" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "City", "Zip" },
                values: new object[] { "New York", "55146" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "City", "Street", "Zip" },
                values: new object[] { "Phoenix", "Elm St", "17759" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Philadelphia", "CA", "Highland Ave", "90566" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "State", "Street", "Zip" },
                values: new object[] { "NY", "Highland Ave", "89579" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Houston", "TX", "Broadway", "11700" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Philadelphia", "AZ", "Cedar Ln", "85922" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Diego", "TX", "Cedar Ln", "41120" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "City", "Zip" },
                values: new object[] { "San Jose", "28375" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Diego", "CA", "Washington Ave", "56816" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Phoenix", "CA", "Maple Ave", "67096" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Chicago", "IL", "Main St", "43753" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "Street", "Zip" },
                values: new object[] { "Pine St", "33124" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "City", "Street", "Zip" },
                values: new object[] { "San Jose", "Washington Ave", "51876" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Antonio", "CA", "Pine St", "40948" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "State", "Street", "Zip" },
                values: new object[] { "CA", "Oak St", "64937" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Philadelphia", "IL", "Sunset Blvd", "24105" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "City", "Street", "Zip" },
                values: new object[] { "Los Angeles", "Oak St", "96933" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Jose", "CA", "Elm St", "80464" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "Los Angeles", "AZ", "Elm St", "71229" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "City", "State", "Street", "Zip" },
                values: new object[] { "San Diego", "TX", "Cedar Ln", "29983" });

            migrationBuilder.UpdateData(
                table: "AddressEntities",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "City", "State", "Zip" },
                values: new object[] { "Houston", "AZ", "29319" });

            migrationBuilder.InsertData(
                table: "DoctorEntities",
                columns: new[] { "Id", "AddressId", "BirthDate", "Education", "Email", "ExperienceInYears", "FullName", "PhoneNumber", "RoomNumber", "Specialization" },
                values: new object[,]
                {
                    { new Guid("40bc2fbd-e28a-4f9c-96e0-4c7e61cecb3b"), 5L, new DateOnly(1961, 6, 13), "Medical Degree", "john.smith2@hotmail.com", 29L, "John Smith", "+1-999-663-2419", "E-278", "Cardiology" },
                    { new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"), 14L, new DateOnly(1956, 7, 28), "Medical Degree", "emma.brown6@aol.com", 8L, "Emma Brown", "+1-666-942-1352", "D-821", "Oncology" },
                    { new Guid("49e28d01-2067-4d9e-a086-556be1e39ed3"), 14L, new DateOnly(1952, 11, 19), "Medical Degree", "james.jones9@yahoo.com", 16L, "James Jones", "+1-666-534-8080", "C-448", "Orthopedics" },
                    { new Guid("63ce2675-2880-4359-a842-7d92a3e5d478"), 9L, new DateOnly(1998, 4, 8), "Medical Degree", "john.smith8@gmail.com", 2L, "John Smith", "+1-888-451-6312", "A-545", "Neurology" },
                    { new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"), 20L, new DateOnly(1950, 1, 21), "Medical Degree", "emma.brown4@gmail.com", 16L, "Emma Brown", "+1-666-313-4352", "A-189", "Oncology" },
                    { new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), 7L, new DateOnly(1985, 11, 23), "Medical Degree", "michael.williams3@hotmail.com", 12L, "Michael Williams", "+1-666-978-1711", "E-172", "Neurology" },
                    { new Guid("81968a99-7398-4900-a6e5-9a1412171465"), 13L, new DateOnly(1980, 10, 3), "Medical Degree", "emily.johnson7@aol.com", 6L, "Emily Johnson", "+1-666-406-7822", "A-492", "Neurology" },
                    { new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), 7L, new DateOnly(1958, 12, 28), "Medical Degree", "emily.johnson8@gmail.com", 1L, "Emily Johnson", "+1-555-519-7797", "A-470", "Orthopedics" },
                    { new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), 7L, new DateOnly(1976, 10, 23), "Medical Degree", "emily.johnson3@hotmail.com", 1L, "Emily Johnson", "+1-888-145-9442", "B-621", "Oncology" },
                    { new Guid("c17268dc-5e86-48c6-bf7f-bb0211a34597"), 20L, new DateOnly(1986, 11, 28), "Medical Degree", "emily.johnson1@hotmail.com", 30L, "Emily Johnson", "+1-666-446-5712", "B-358", "Orthopedics" },
                    { new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"), 12L, new DateOnly(1964, 3, 21), "Medical Degree", "emma.brown4@outlook.com", 19L, "Emma Brown", "+1-666-323-7491", "C-206", "Pediatrics" },
                    { new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"), 20L, new DateOnly(1991, 10, 12), "Medical Degree", "michael.williams0@gmail.com", 28L, "Michael Williams", "+1-999-567-7611", "C-313", "Pediatrics" },
                    { new Guid("d967207e-5cf9-43a0-8dc5-88184da40fbd"), 4L, new DateOnly(1997, 4, 12), "Medical Degree", "emily.johnson2@outlook.com", 23L, "Emily Johnson", "+1-888-791-7585", "C-150", "Pediatrics" },
                    { new Guid("da630793-8f6d-456d-8c9b-6ee2d601e293"), 22L, new DateOnly(1995, 11, 18), "Medical Degree", "emma.brown8@hotmail.com", 26L, "Emma Brown", "+1-999-364-1479", "A-484", "Cardiology" },
                    { new Guid("e592809c-495b-4a54-af87-ff2a4dc2c0f1"), 24L, new DateOnly(1997, 8, 1), "Medical Degree", "emily.johnson4@outlook.com", 13L, "Emily Johnson", "+1-666-375-8159", "C-146", "Oncology" }
                });

            migrationBuilder.InsertData(
                table: "PatientEntities",
                columns: new[] { "Id", "AddressId", "BirthDate", "Email", "FullName", "InsurancePolicyNumber", "InsuranceProvider", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), 20L, new DateOnly(1983, 5, 26), "daniel.johnson7@yahoo.com", "Daniel Johnson", "885532910", "Molina Healthcare", "+1-111-912-2804" },
                    { new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), 5L, new DateOnly(1960, 12, 16), "ethan.jackson2@outlook.com", "Ethan Jackson", "637449363", "Bright Health", "+1-222-418-9073" },
                    { new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"), 9L, new DateOnly(1989, 1, 16), "amelia.clark0@hotmail.com", "Amelia Clark", "470661119", "BlueCross", "+1-444-480-1763" },
                    { new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), 17L, new DateOnly(1993, 1, 18), "ethan.jackson9@aol.com", "Ethan Jackson", "870700416", "Oxford Health Plans", "+1-444-937-7637" },
                    { new Guid("4941f913-50d9-478c-8023-47ca581018b5"), 6L, new DateOnly(1965, 5, 3), "isabella.martinez3@gmail.com", "Isabella Martinez", "359509772", "Bright Health", "+1-111-586-7391" },
                    { new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"), 15L, new DateOnly(1974, 4, 20), "amelia.clark3@outlook.com", "Amelia Clark", "346720637", "Friday Health Plans", "+1-222-677-1723" },
                    { new Guid("7aa0a526-a3ea-4f8a-a7f4-83d129145930"), 18L, new DateOnly(1963, 3, 16), "sophia.taylor3@outlook.com", "Sophia Taylor", "626979715", "Health Net", "+1-444-206-2857" },
                    { new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"), 10L, new DateOnly(1997, 10, 20), "liam.anderson1@yahoo.com", "Liam Anderson", "283103060", "UnitedHealthcare", "+1-111-487-3876" },
                    { new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), 18L, new DateOnly(1975, 10, 16), "olivia.davis9@outlook.com", "Olivia Davis", "731210957", "Health Net", "+1-111-329-4695" },
                    { new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), 11L, new DateOnly(1974, 2, 22), "daniel.johnson2@hotmail.com", "Daniel Johnson", "866395060", "Oxford Health Plans", "+1-111-871-6640" },
                    { new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), 4L, new DateOnly(1994, 10, 11), "ava.white4@aol.com", "Ava White", "242645711", "UnitedHealthcare", "+1-333-834-3648" },
                    { new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"), 4L, new DateOnly(1969, 8, 10), "william.wilson1@yahoo.com", "William Wilson", "176908483", "Bright Health", "+1-222-138-2085" },
                    { new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), 22L, new DateOnly(1983, 6, 13), "isabella.martinez9@aol.com", "Isabella Martinez", "559334818", "Bright Health", "+1-222-253-8147" },
                    { new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"), 1L, new DateOnly(1963, 1, 10), "isabella.martinez6@yahoo.com", "Isabella Martinez", "364696528", "Anthem", "+1-222-927-5891" },
                    { new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"), 21L, new DateOnly(1983, 12, 13), "amelia.clark4@aol.com", "Amelia Clark", "367660253", "Aetna", "+1-222-305-7904" }
                });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"), new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("53a3cfc2-cb2d-4bb7-859f-b7c2b39fd06c"), new Guid("4941f913-50d9-478c-8023-47ca581018b5") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("3429bfdb-3329-4c36-8100-92aef6c397af"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("9ad502c0-f6ed-4218-bc5a-c312540f8ede"), new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"), new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("53a3cfc2-cb2d-4bb7-859f-b7c2b39fd06c"), new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("0c046b8d-a551-4fd3-aceb-074b82ffb4a8"), new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("feadd605-be98-4f27-8513-2e90d9e331f0"), new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("ce814387-a5fd-493b-b140-ec4909daaabf"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("ca25957b-d494-4d9d-bd23-e48b31b01690"), new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("b7449f37-34c2-4691-bd25-b2d136ad48bf"), new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"), new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"), new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("9ad502c0-f6ed-4218-bc5a-c312540f8ede"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"), new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("0d2a9c25-3e6e-483d-a5c0-2547d5748934"), new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("cf4c8a2c-6641-4cf3-b637-224e01439d1f"), new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("94f20bb9-db5e-4d5d-870b-a5c8a957a952"), new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("1dcc8a35-cf12-4415-b663-f70aa65b2c9d"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("c0e98bac-aaa0-4292-a6f3-79f32b8b5548"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"), new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"), new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("18a56a17-d8f2-4ca3-8c2c-521b0901c8e2"), new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("b7449f37-34c2-4691-bd25-b2d136ad48bf"), new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("605d9a42-dcdb-44b5-abeb-42561d787886"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("7d98a5f3-c3b6-4805-92fa-7727100a1d57"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("605d9a42-dcdb-44b5-abeb-42561d787886"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("0ecd7d76-e6be-4670-a244-e6aa4a4ba521"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"), new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("0c046b8d-a551-4fd3-aceb-074b82ffb4a8"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("aaf9fc1a-4568-4d7e-b67b-3bd1c4cc8723"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("feadd605-be98-4f27-8513-2e90d9e331f0"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Notifier" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "MedicalRecordId", "PatientId", "SubscriptionType" },
                values: new object[] { new Guid("0ecd7d76-e6be-4670-a244-e6aa4a4ba521"), new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"), "Observer" });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63") });

            migrationBuilder.UpdateData(
                table: "SubscriptionEntities",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "MedicalRecordId", "PatientId" },
                values: new object[] { new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"), new Guid("4941f913-50d9-478c-8023-47ca581018b5") });

            migrationBuilder.InsertData(
                table: "MedicalRecordEntities",
                columns: new[] { "Id", "CreatedAt", "DoctorId", "PatientId", "Record", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2073), new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"), "Medical record 19 for patient 13315216-3e0a-4c15-a6a8-fcdb85f9224c and doctor 8f3aea52-ba1e-462a-8bf7-3c99d509e3d5", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2073) },
                    { new Guid("0c046b8d-a551-4fd3-aceb-074b82ffb4a8"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1982), new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Medical record 3 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor bd0177b8-41cc-44fb-9255-ea455e7c91be", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1983) },
                    { new Guid("0d2a9c25-3e6e-483d-a5c0-2547d5748934"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2078), new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), "Medical record 20 for patient a2b616ce-0588-4fb9-8fcb-eca1d8a22570 and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2078) },
                    { new Guid("0ecd7d76-e6be-4670-a244-e6aa4a4ba521"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2087), new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"), new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"), "Medical record 22 for patient 8d8128db-4e79-49a6-b473-8ac2abf64d83 and doctor cfb1814f-64b4-4c28-817d-77530d91fc4b", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2087) },
                    { new Guid("105d5675-08a4-4c9f-836d-bdb854eb768d"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2028), new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Medical record 12 for patient b4749c5a-ebcd-4c16-acef-e2b3bc11adcb and doctor 8f3aea52-ba1e-462a-8bf7-3c99d509e3d5", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2029) },
                    { new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1987), new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Medical record 4 for patient b4749c5a-ebcd-4c16-acef-e2b3bc11adcb and doctor bd0177b8-41cc-44fb-9255-ea455e7c91be", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1987) },
                    { new Guid("18a56a17-d8f2-4ca3-8c2c-521b0901c8e2"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2082), new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), "Medical record 21 for patient b9993fbc-df24-4ff8-82d4-d2c71ac9a52e and doctor cfb1814f-64b4-4c28-817d-77530d91fc4b", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2083) },
                    { new Guid("1dcc8a35-cf12-4415-b663-f70aa65b2c9d"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2019), new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Medical record 10 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor 8f3aea52-ba1e-462a-8bf7-3c99d509e3d5", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2019) },
                    { new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2004), new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), "Medical record 7 for patient b9993fbc-df24-4ff8-82d4-d2c71ac9a52e and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2004) },
                    { new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1969), new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"), new Guid("7aa0a526-a3ea-4f8a-a7f4-83d129145930"), "Medical record 1 for patient 7aa0a526-a3ea-4f8a-a7f4-83d129145930 and doctor 49a5c2b0-cc81-4a40-bbfc-d02b5bde249a", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1970) },
                    { new Guid("3429bfdb-3329-4c36-8100-92aef6c397af"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2063), new Guid("63ce2675-2880-4359-a842-7d92a3e5d478"), new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), "Medical record 17 for patient 0b7db7b1-31ca-44b2-9113-9b969130b4f3 and doctor 63ce2675-2880-4359-a842-7d92a3e5d478", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2063) },
                    { new Guid("53a3cfc2-cb2d-4bb7-859f-b7c2b39fd06c"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2046), new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"), new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"), "Medical record 15 for patient 5bf4f189-f9ea-4341-99f7-7df0c5085cca and doctor 6631aa0a-2474-4777-8c6a-92a439cf6672", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2046) },
                    { new Guid("605d9a42-dcdb-44b5-abeb-42561d787886"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2039), new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Medical record 14 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor d584ab75-8bd8-4ab6-bf81-22ffccb7f43c", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2039) },
                    { new Guid("7d98a5f3-c3b6-4805-92fa-7727100a1d57"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2105), new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"), "Medical record 26 for patient d0115f46-dda7-4f2c-b2e5-3a7bb37760cd and doctor 6631aa0a-2474-4777-8c6a-92a439cf6672", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2106) },
                    { new Guid("94f20bb9-db5e-4d5d-870b-a5c8a957a952"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2068), new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Medical record 18 for patient aeb8aba4-7483-4001-9d9c-d005e9be32f0 and doctor 8f3aea52-ba1e-462a-8bf7-3c99d509e3d5", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2069) },
                    { new Guid("9ad502c0-f6ed-4218-bc5a-c312540f8ede"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2034), new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"), new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"), "Medical record 13 for patient cc573f43-b2b2-4f81-bd93-2755b5f9a8f5 and doctor cfb1814f-64b4-4c28-817d-77530d91fc4b", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2034) },
                    { new Guid("aa65dd8a-868c-40ca-9587-819f774ee3b3"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2110), new Guid("e592809c-495b-4a54-af87-ff2a4dc2c0f1"), new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"), "Medical record 27 for patient b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c and doctor e592809c-495b-4a54-af87-ff2a4dc2c0f1", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2111) },
                    { new Guid("aaf9fc1a-4568-4d7e-b67b-3bd1c4cc8723"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1992), new Guid("da630793-8f6d-456d-8c9b-6ee2d601e293"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"), "Medical record 5 for patient d0115f46-dda7-4f2c-b2e5-3a7bb37760cd and doctor da630793-8f6d-456d-8c9b-6ee2d601e293", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1992) },
                    { new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2119), new Guid("da630793-8f6d-456d-8c9b-6ee2d601e293"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Medical record 29 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor da630793-8f6d-456d-8c9b-6ee2d601e293", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2119) },
                    { new Guid("b19e9788-a9e1-4219-89e9-8b94f2bda161"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2058), new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"), "Medical record 16 for patient d0115f46-dda7-4f2c-b2e5-3a7bb37760cd and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2058) },
                    { new Guid("b7449f37-34c2-4691-bd25-b2d136ad48bf"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1997), new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Medical record 6 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor 49a5c2b0-cc81-4a40-bbfc-d02b5bde249a", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1997) },
                    { new Guid("bedf1488-76ea-49e5-b68c-b651434e005b"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2101), new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"), new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"), "Medical record 25 for patient 8d8128db-4e79-49a6-b473-8ac2abf64d83 and doctor d584ab75-8bd8-4ab6-bf81-22ffccb7f43c", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2102) },
                    { new Guid("c0e98bac-aaa0-4292-a6f3-79f32b8b5548"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2097), new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"), new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"), "Medical record 24 for patient cc573f43-b2b2-4f81-bd93-2755b5f9a8f5 and doctor d584ab75-8bd8-4ab6-bf81-22ffccb7f43c", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2098) },
                    { new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2115), new Guid("d967207e-5cf9-43a0-8dc5-88184da40fbd"), new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"), "Medical record 28 for patient b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c and doctor d967207e-5cf9-43a0-8dc5-88184da40fbd", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2115) },
                    { new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2093), new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"), "Medical record 23 for patient 8d8128db-4e79-49a6-b473-8ac2abf64d83 and doctor bd0177b8-41cc-44fb-9255-ea455e7c91be", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2093) },
                    { new Guid("ca25957b-d494-4d9d-bd23-e48b31b01690"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1976), new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"), "Medical record 2 for patient d0115f46-dda7-4f2c-b2e5-3a7bb37760cd and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1977) },
                    { new Guid("ce814387-a5fd-493b-b140-ec4909daaabf"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2013), new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), "Medical record 9 for patient b9993fbc-df24-4ff8-82d4-d2c71ac9a52e and doctor bd0177b8-41cc-44fb-9255-ea455e7c91be", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2013) },
                    { new Guid("cf4c8a2c-6641-4cf3-b637-224e01439d1f"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2009), new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"), new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"), "Medical record 8 for patient b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c and doctor 6631aa0a-2474-4777-8c6a-92a439cf6672", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2010) },
                    { new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2024), new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Medical record 11 for patient 0b00c1de-5038-4aba-a635-8c8de68c92a2 and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2024) },
                    { new Guid("feadd605-be98-4f27-8513-2e90d9e331f0"), new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2124), new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"), new Guid("7aa0a526-a3ea-4f8a-a7f4-83d129145930"), "Medical record 30 for patient 7aa0a526-a3ea-4f8a-a7f4-83d129145930 and doctor 49a5c2b0-cc81-4a40-bbfc-d02b5bde249a", new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2124) }
                });
        }
    }
}
