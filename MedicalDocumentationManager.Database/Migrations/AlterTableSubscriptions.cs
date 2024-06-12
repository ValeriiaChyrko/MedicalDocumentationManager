#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalDocumentationManager.Database.Migrations;

/// <inheritdoc />
public partial class AlterTableSubscriptions : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("7a18f5d6-6ed2-47de-9be6-774a85d3f842"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("857d323a-6fb7-4751-a8c2-6338a98389bc"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("a862d15f-7651-4c0a-8a6f-58b39d0c7c35"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("2bb5242b-205c-4626-a5d1-59bddbb74335"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("2c3ed2bb-afe0-4430-b07f-e5a8a3806268"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("6f5bda39-07c0-43fd-bdea-3b1a8144f8de"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("8741d404-bf5f-4768-bd05-1a0e6e562457"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("8a6b4292-e653-436e-81c9-eedec4f78f41"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("8b80619b-eff1-4dd9-83ae-cfdacf1e142d"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("e7be8d0a-4c55-43f2-977d-f847808c231c"));

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            1);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            2);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            3);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            4);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            5);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            6);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            7);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            8);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            9);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            10);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            11);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            12);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            13);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            14);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            15);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            16);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            17);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            18);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            19);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            20);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            21);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            22);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            23);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            24);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            25);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            26);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            27);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            28);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            29);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            30);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            31);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            32);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            33);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            34);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            35);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            36);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            37);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            38);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            39);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            40);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            41);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            42);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            43);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            44);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            45);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            46);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            47);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            48);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            49);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            50);

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("4c5101df-9fd4-42ef-a2a6-30757fc0c78e"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("7a42e927-9837-40ae-819b-dfca4058a3df"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("00f9a2f4-afbf-41e9-87dc-70ea1a3ea8a9"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("11492bff-ce05-4b98-9d9f-d2b754329504"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("1eba5bba-673a-4d55-baf4-39a3d711c3d3"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("2540134b-a81f-4e04-9f9a-761a339ffbc0"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("255d4a8a-b657-4e4e-b595-265f56584b11"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("2f644c81-241e-49ea-aec9-043a89caa107"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("313f3635-3e70-47c5-b515-e536522ab881"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("34b867d1-ed38-4c6d-ace0-33784526f18c"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("40e50140-66d2-4e35-bc6b-164c75ee3329"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("502905cd-eebb-4cc8-992e-a3633ca2a2fb"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("5fcff655-a07f-4aa6-8f7a-bfc2260743c4"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("6cdec137-1db9-4031-b31c-99d86591b0e5"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("6dc4d648-8ab0-4f62-ba16-a7aed239f9bd"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("870f2507-20bc-40aa-a613-407e88e6a1ba"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("9446f4a3-93b7-4b3f-976b-2b8b9e657da5"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("96ca3060-29a9-4f74-ad35-f624d940fe1a"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("97a2391b-48d5-42c6-871a-8d9e680aa2ac"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("b50fc554-4110-4887-b2d9-90e9b242da75"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("be4d2840-5126-498b-8390-cfef9e4bcdc3"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("ce0f1789-fa24-4e66-a935-00f0ed7d724b"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("ec5ed62f-12dd-48de-a548-76c8b55f8f92"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("f4573ca4-d36f-4d21-beeb-629b01628d39"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("f785ae7d-488a-4544-8066-775ea77f187b"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("4fbc5155-e9f2-47e4-9cd2-b021726cdd80"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("ab413ddc-0b02-48e7-b387-436a832f7d44"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("ec60232f-032e-4b90-b122-33237264cc02"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("02fc69ec-c9b2-4bc9-aa83-2ab764d17e12"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("214683bd-14f0-49cd-a03f-043b1c754fd4"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("55c2dd3d-fa52-4f72-b63f-8442105f2b22"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("6a81a708-8a8c-4166-832d-e8b2bbf42579"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("accf60ef-aa52-4318-9a38-413b26c02acc"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("adb7f2bf-3f3b-4693-ade2-0367c23238db"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("f8cf402f-174d-4383-8311-9c10e3a5ae29"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("fa88ccfd-d5a9-41fd-a5f3-975280ea1c9f"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("fc21f2ff-e569-4fc7-a635-c6069f64e043"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("3606c837-ae0d-46b7-ad9a-6fc2c866715a"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("534bebae-0954-43a8-bb59-064d727e17e7"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("643e41eb-9b21-4fab-8f59-668ae46395fa"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("8042d801-bdc4-4dca-879d-ee57ee45cb9e"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("9f5cb4d7-1e3c-49a6-a71f-d9605e18ea6d"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("c24f9152-fb5d-4df3-b752-c713506c2b7a"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("e465c73a-da65-4979-8ca4-c0042cc18c06"));

        migrationBuilder.AlterColumn<long>(
                "Id",
                "SubscriptionEntities",
                "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
            .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            1L,
            new[] { "City", "Street", "Zip" },
            new object[] { "Houston", "Pine St", "59412" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            2L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Phoenix", "AZ", "Cedar Ln", "28511" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            3L,
            new[] { "City", "Street", "Zip" },
            new object[] { "Phoenix", "Oak St", "62989" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            4L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Chicago", "CA", "Broadway", "89195" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            5L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "New York", "CA", "Oak St", "55146" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            6L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Phoenix", "TX", "Elm St", "17759" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            7L,
            new[] { "City", "Street", "Zip" },
            new object[] { "Philadelphia", "Highland Ave", "90566" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            8L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Houston", "NY", "Highland Ave", "89579" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            9L,
            new[] { "City", "Street", "Zip" },
            new object[] { "Houston", "Broadway", "11700" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            10L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Philadelphia", "AZ", "Cedar Ln", "85922" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            11L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "San Diego", "TX", "Cedar Ln", "41120" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            12L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "San Jose", "TX", "Washington Ave", "28375" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            13L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "San Diego", "CA", "Washington Ave", "56816" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            14L,
            new[] { "State", "Street", "Zip" },
            new object[] { "CA", "Maple Ave", "67096" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            15L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Chicago", "IL", "Main St", "43753" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            16L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Philadelphia", "TX", "Pine St", "33124" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            17L,
            new[] { "City", "Street", "Zip" },
            new object[] { "San Jose", "Washington Ave", "51876" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            18L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "San Antonio", "CA", "Pine St", "40948" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            19L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "San Diego", "CA", "Oak St", "64937" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            20L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Philadelphia", "IL", "Sunset Blvd", "24105" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            21L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Los Angeles", "TX", "Oak St", "96933" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            22L,
            new[] { "City", "Zip" },
            new object[] { "San Jose", "80464" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            23L,
            new[] { "City", "Street", "Zip" },
            new object[] { "Los Angeles", "Elm St", "71229" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            24L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "San Diego", "TX", "Cedar Ln", "29983" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            25L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Houston", "AZ", "Pine St", "29319" });

        migrationBuilder.InsertData(
            "DoctorEntities",
            new[]
            {
                "Id", "AddressId", "BirthDate", "Education", "Email", "ExperienceInYears", "FullName", "PhoneNumber",
                "RoomNumber", "Specialization"
            },
            new object[,]
            {
                {
                    new Guid("40bc2fbd-e28a-4f9c-96e0-4c7e61cecb3b"), 5L, new DateOnly(1961, 6, 13), "Medical Degree",
                    "john.smith2@hotmail.com", 29L, "John Smith", "+1-999-663-2419", "E-278", "Cardiology"
                },
                {
                    new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"), 14L, new DateOnly(1956, 7, 28), "Medical Degree",
                    "emma.brown6@aol.com", 8L, "Emma Brown", "+1-666-942-1352", "D-821", "Oncology"
                },
                {
                    new Guid("49e28d01-2067-4d9e-a086-556be1e39ed3"), 14L, new DateOnly(1952, 11, 19), "Medical Degree",
                    "james.jones9@yahoo.com", 16L, "James Jones", "+1-666-534-8080", "C-448", "Orthopedics"
                },
                {
                    new Guid("63ce2675-2880-4359-a842-7d92a3e5d478"), 9L, new DateOnly(1998, 4, 8), "Medical Degree",
                    "john.smith8@gmail.com", 2L, "John Smith", "+1-888-451-6312", "A-545", "Neurology"
                },
                {
                    new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"), 20L, new DateOnly(1950, 1, 21), "Medical Degree",
                    "emma.brown4@gmail.com", 16L, "Emma Brown", "+1-666-313-4352", "A-189", "Oncology"
                },
                {
                    new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), 7L, new DateOnly(1985, 11, 23), "Medical Degree",
                    "michael.williams3@hotmail.com", 12L, "Michael Williams", "+1-666-978-1711", "E-172", "Neurology"
                },
                {
                    new Guid("81968a99-7398-4900-a6e5-9a1412171465"), 13L, new DateOnly(1980, 10, 3), "Medical Degree",
                    "emily.johnson7@aol.com", 6L, "Emily Johnson", "+1-666-406-7822", "A-492", "Neurology"
                },
                {
                    new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), 7L, new DateOnly(1958, 12, 28), "Medical Degree",
                    "emily.johnson8@gmail.com", 1L, "Emily Johnson", "+1-555-519-7797", "A-470", "Orthopedics"
                },
                {
                    new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), 7L, new DateOnly(1976, 10, 23), "Medical Degree",
                    "emily.johnson3@hotmail.com", 1L, "Emily Johnson", "+1-888-145-9442", "B-621", "Oncology"
                },
                {
                    new Guid("c17268dc-5e86-48c6-bf7f-bb0211a34597"), 20L, new DateOnly(1986, 11, 28), "Medical Degree",
                    "emily.johnson1@hotmail.com", 30L, "Emily Johnson", "+1-666-446-5712", "B-358", "Orthopedics"
                },
                {
                    new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"), 12L, new DateOnly(1964, 3, 21), "Medical Degree",
                    "emma.brown4@outlook.com", 19L, "Emma Brown", "+1-666-323-7491", "C-206", "Pediatrics"
                },
                {
                    new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"), 20L, new DateOnly(1991, 10, 12), "Medical Degree",
                    "michael.williams0@gmail.com", 28L, "Michael Williams", "+1-999-567-7611", "C-313", "Pediatrics"
                },
                {
                    new Guid("d967207e-5cf9-43a0-8dc5-88184da40fbd"), 4L, new DateOnly(1997, 4, 12), "Medical Degree",
                    "emily.johnson2@outlook.com", 23L, "Emily Johnson", "+1-888-791-7585", "C-150", "Pediatrics"
                },
                {
                    new Guid("da630793-8f6d-456d-8c9b-6ee2d601e293"), 22L, new DateOnly(1995, 11, 18), "Medical Degree",
                    "emma.brown8@hotmail.com", 26L, "Emma Brown", "+1-999-364-1479", "A-484", "Cardiology"
                },
                {
                    new Guid("e592809c-495b-4a54-af87-ff2a4dc2c0f1"), 24L, new DateOnly(1997, 8, 1), "Medical Degree",
                    "emily.johnson4@outlook.com", 13L, "Emily Johnson", "+1-666-375-8159", "C-146", "Oncology"
                }
            });

        migrationBuilder.InsertData(
            "PatientEntities",
            new[]
            {
                "Id", "AddressId", "BirthDate", "Email", "FullName", "InsurancePolicyNumber", "InsuranceProvider",
                "PhoneNumber"
            },
            new object[,]
            {
                {
                    new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), 20L, new DateOnly(1983, 5, 26),
                    "daniel.johnson7@yahoo.com", "Daniel Johnson", "885532910", "Molina Healthcare", "+1-111-912-2804"
                },
                {
                    new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), 5L, new DateOnly(1960, 12, 16),
                    "ethan.jackson2@outlook.com", "Ethan Jackson", "637449363", "Bright Health", "+1-222-418-9073"
                },
                {
                    new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"), 9L, new DateOnly(1989, 1, 16),
                    "amelia.clark0@hotmail.com", "Amelia Clark", "470661119", "BlueCross", "+1-444-480-1763"
                },
                {
                    new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), 17L, new DateOnly(1993, 1, 18),
                    "ethan.jackson9@aol.com", "Ethan Jackson", "870700416", "Oxford Health Plans", "+1-444-937-7637"
                },
                {
                    new Guid("4941f913-50d9-478c-8023-47ca581018b5"), 6L, new DateOnly(1965, 5, 3),
                    "isabella.martinez3@gmail.com", "Isabella Martinez", "359509772", "Bright Health", "+1-111-586-7391"
                },
                {
                    new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"), 15L, new DateOnly(1974, 4, 20),
                    "amelia.clark3@outlook.com", "Amelia Clark", "346720637", "Friday Health Plans", "+1-222-677-1723"
                },
                {
                    new Guid("7aa0a526-a3ea-4f8a-a7f4-83d129145930"), 18L, new DateOnly(1963, 3, 16),
                    "sophia.taylor3@outlook.com", "Sophia Taylor", "626979715", "Health Net", "+1-444-206-2857"
                },
                {
                    new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"), 10L, new DateOnly(1997, 10, 20),
                    "liam.anderson1@yahoo.com", "Liam Anderson", "283103060", "UnitedHealthcare", "+1-111-487-3876"
                },
                {
                    new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), 18L, new DateOnly(1975, 10, 16),
                    "olivia.davis9@outlook.com", "Olivia Davis", "731210957", "Health Net", "+1-111-329-4695"
                },
                {
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), 11L, new DateOnly(1974, 2, 22),
                    "daniel.johnson2@hotmail.com", "Daniel Johnson", "866395060", "Oxford Health Plans",
                    "+1-111-871-6640"
                },
                {
                    new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), 4L, new DateOnly(1994, 10, 11),
                    "ava.white4@aol.com", "Ava White", "242645711", "UnitedHealthcare", "+1-333-834-3648"
                },
                {
                    new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"), 4L, new DateOnly(1969, 8, 10),
                    "william.wilson1@yahoo.com", "William Wilson", "176908483", "Bright Health", "+1-222-138-2085"
                },
                {
                    new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), 22L, new DateOnly(1983, 6, 13),
                    "isabella.martinez9@aol.com", "Isabella Martinez", "559334818", "Bright Health", "+1-222-253-8147"
                },
                {
                    new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"), 1L, new DateOnly(1963, 1, 10),
                    "isabella.martinez6@yahoo.com", "Isabella Martinez", "364696528", "Anthem", "+1-222-927-5891"
                },
                {
                    new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"), 21L, new DateOnly(1983, 12, 13),
                    "amelia.clark4@aol.com", "Amelia Clark", "367660253", "Aetna", "+1-222-305-7904"
                }
            });

        migrationBuilder.InsertData(
            "MedicalRecordEntities",
            new[] { "Id", "CreatedAt", "DoctorId", "PatientId", "Record", "UpdatedAt" },
            new object[,]
            {
                {
                    new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2073),
                    new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"),
                    "Medical record 19 for patient 13315216-3e0a-4c15-a6a8-fcdb85f9224c and doctor 8f3aea52-ba1e-462a-8bf7-3c99d509e3d5",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2073)
                },
                {
                    new Guid("0c046b8d-a551-4fd3-aceb-074b82ffb4a8"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1982),
                    new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"),
                    "Medical record 3 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor bd0177b8-41cc-44fb-9255-ea455e7c91be",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1983)
                },
                {
                    new Guid("0d2a9c25-3e6e-483d-a5c0-2547d5748934"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2078),
                    new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"),
                    "Medical record 20 for patient a2b616ce-0588-4fb9-8fcb-eca1d8a22570 and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2078)
                },
                {
                    new Guid("0ecd7d76-e6be-4670-a244-e6aa4a4ba521"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2087),
                    new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"), new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"),
                    "Medical record 22 for patient 8d8128db-4e79-49a6-b473-8ac2abf64d83 and doctor cfb1814f-64b4-4c28-817d-77530d91fc4b",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2087)
                },
                {
                    new Guid("105d5675-08a4-4c9f-836d-bdb854eb768d"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2028),
                    new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"),
                    "Medical record 12 for patient b4749c5a-ebcd-4c16-acef-e2b3bc11adcb and doctor 8f3aea52-ba1e-462a-8bf7-3c99d509e3d5",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2029)
                },
                {
                    new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1987),
                    new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"),
                    "Medical record 4 for patient b4749c5a-ebcd-4c16-acef-e2b3bc11adcb and doctor bd0177b8-41cc-44fb-9255-ea455e7c91be",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1987)
                },
                {
                    new Guid("18a56a17-d8f2-4ca3-8c2c-521b0901c8e2"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2082),
                    new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"),
                    "Medical record 21 for patient b9993fbc-df24-4ff8-82d4-d2c71ac9a52e and doctor cfb1814f-64b4-4c28-817d-77530d91fc4b",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2083)
                },
                {
                    new Guid("1dcc8a35-cf12-4415-b663-f70aa65b2c9d"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2019),
                    new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"),
                    "Medical record 10 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor 8f3aea52-ba1e-462a-8bf7-3c99d509e3d5",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2019)
                },
                {
                    new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2004),
                    new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"),
                    "Medical record 7 for patient b9993fbc-df24-4ff8-82d4-d2c71ac9a52e and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2004)
                },
                {
                    new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1969),
                    new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"), new Guid("7aa0a526-a3ea-4f8a-a7f4-83d129145930"),
                    "Medical record 1 for patient 7aa0a526-a3ea-4f8a-a7f4-83d129145930 and doctor 49a5c2b0-cc81-4a40-bbfc-d02b5bde249a",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1970)
                },
                {
                    new Guid("3429bfdb-3329-4c36-8100-92aef6c397af"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2063),
                    new Guid("63ce2675-2880-4359-a842-7d92a3e5d478"), new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"),
                    "Medical record 17 for patient 0b7db7b1-31ca-44b2-9113-9b969130b4f3 and doctor 63ce2675-2880-4359-a842-7d92a3e5d478",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2063)
                },
                {
                    new Guid("53a3cfc2-cb2d-4bb7-859f-b7c2b39fd06c"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2046),
                    new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"), new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"),
                    "Medical record 15 for patient 5bf4f189-f9ea-4341-99f7-7df0c5085cca and doctor 6631aa0a-2474-4777-8c6a-92a439cf6672",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2046)
                },
                {
                    new Guid("605d9a42-dcdb-44b5-abeb-42561d787886"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2039),
                    new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"),
                    "Medical record 14 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor d584ab75-8bd8-4ab6-bf81-22ffccb7f43c",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2039)
                },
                {
                    new Guid("7d98a5f3-c3b6-4805-92fa-7727100a1d57"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2105),
                    new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"),
                    "Medical record 26 for patient d0115f46-dda7-4f2c-b2e5-3a7bb37760cd and doctor 6631aa0a-2474-4777-8c6a-92a439cf6672",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2106)
                },
                {
                    new Guid("94f20bb9-db5e-4d5d-870b-a5c8a957a952"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2068),
                    new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"), new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"),
                    "Medical record 18 for patient aeb8aba4-7483-4001-9d9c-d005e9be32f0 and doctor 8f3aea52-ba1e-462a-8bf7-3c99d509e3d5",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2069)
                },
                {
                    new Guid("9ad502c0-f6ed-4218-bc5a-c312540f8ede"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2034),
                    new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"), new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"),
                    "Medical record 13 for patient cc573f43-b2b2-4f81-bd93-2755b5f9a8f5 and doctor cfb1814f-64b4-4c28-817d-77530d91fc4b",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2034)
                },
                {
                    new Guid("aa65dd8a-868c-40ca-9587-819f774ee3b3"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2110),
                    new Guid("e592809c-495b-4a54-af87-ff2a4dc2c0f1"), new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"),
                    "Medical record 27 for patient b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c and doctor e592809c-495b-4a54-af87-ff2a4dc2c0f1",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2111)
                },
                {
                    new Guid("aaf9fc1a-4568-4d7e-b67b-3bd1c4cc8723"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1992),
                    new Guid("da630793-8f6d-456d-8c9b-6ee2d601e293"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"),
                    "Medical record 5 for patient d0115f46-dda7-4f2c-b2e5-3a7bb37760cd and doctor da630793-8f6d-456d-8c9b-6ee2d601e293",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1992)
                },
                {
                    new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2119),
                    new Guid("da630793-8f6d-456d-8c9b-6ee2d601e293"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"),
                    "Medical record 29 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor da630793-8f6d-456d-8c9b-6ee2d601e293",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2119)
                },
                {
                    new Guid("b19e9788-a9e1-4219-89e9-8b94f2bda161"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2058),
                    new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"),
                    "Medical record 16 for patient d0115f46-dda7-4f2c-b2e5-3a7bb37760cd and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2058)
                },
                {
                    new Guid("b7449f37-34c2-4691-bd25-b2d136ad48bf"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1997),
                    new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"), new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"),
                    "Medical record 6 for patient 27aa99e5-7810-4fec-ab4c-bff7034f1f63 and doctor 49a5c2b0-cc81-4a40-bbfc-d02b5bde249a",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1997)
                },
                {
                    new Guid("bedf1488-76ea-49e5-b68c-b651434e005b"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2101),
                    new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"), new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"),
                    "Medical record 25 for patient 8d8128db-4e79-49a6-b473-8ac2abf64d83 and doctor d584ab75-8bd8-4ab6-bf81-22ffccb7f43c",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2102)
                },
                {
                    new Guid("c0e98bac-aaa0-4292-a6f3-79f32b8b5548"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2097),
                    new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"), new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"),
                    "Medical record 24 for patient cc573f43-b2b2-4f81-bd93-2755b5f9a8f5 and doctor d584ab75-8bd8-4ab6-bf81-22ffccb7f43c",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2098)
                },
                {
                    new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2115),
                    new Guid("d967207e-5cf9-43a0-8dc5-88184da40fbd"), new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"),
                    "Medical record 28 for patient b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c and doctor d967207e-5cf9-43a0-8dc5-88184da40fbd",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2115)
                },
                {
                    new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2093),
                    new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"),
                    "Medical record 23 for patient 8d8128db-4e79-49a6-b473-8ac2abf64d83 and doctor bd0177b8-41cc-44fb-9255-ea455e7c91be",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2093)
                },
                {
                    new Guid("ca25957b-d494-4d9d-bd23-e48b31b01690"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1976),
                    new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"),
                    "Medical record 2 for patient d0115f46-dda7-4f2c-b2e5-3a7bb37760cd and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(1977)
                },
                {
                    new Guid("ce814387-a5fd-493b-b140-ec4909daaabf"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2013),
                    new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"), new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"),
                    "Medical record 9 for patient b9993fbc-df24-4ff8-82d4-d2c71ac9a52e and doctor bd0177b8-41cc-44fb-9255-ea455e7c91be",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2013)
                },
                {
                    new Guid("cf4c8a2c-6641-4cf3-b637-224e01439d1f"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2009),
                    new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"), new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"),
                    "Medical record 8 for patient b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c and doctor 6631aa0a-2474-4777-8c6a-92a439cf6672",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2010)
                },
                {
                    new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2024),
                    new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"), new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"),
                    "Medical record 11 for patient 0b00c1de-5038-4aba-a635-8c8de68c92a2 and doctor 70178d73-1891-4eeb-b1d7-e73b4b55ff63",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2024)
                },
                {
                    new Guid("feadd605-be98-4f27-8513-2e90d9e331f0"),
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2124),
                    new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"), new Guid("7aa0a526-a3ea-4f8a-a7f4-83d129145930"),
                    "Medical record 30 for patient 7aa0a526-a3ea-4f8a-a7f4-83d129145930 and doctor 49a5c2b0-cc81-4a40-bbfc-d02b5bde249a",
                    new DateTime(2024, 6, 9, 15, 9, 50, 448, DateTimeKind.Utc).AddTicks(2124)
                }
            });

        migrationBuilder.InsertData(
            "SubscriptionEntities",
            new[] { "Id", "MedicalRecordId", "PatientId", "SubscriptionType" },
            new object[,]
            {
                {
                    1L, new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"),
                    new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), "Observer"
                },
                {
                    2L, new Guid("53a3cfc2-cb2d-4bb7-859f-b7c2b39fd06c"),
                    new Guid("4941f913-50d9-478c-8023-47ca581018b5"), "Notifier"
                },
                {
                    3L, new Guid("3429bfdb-3329-4c36-8100-92aef6c397af"),
                    new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Notifier"
                },
                {
                    4L, new Guid("9ad502c0-f6ed-4218-bc5a-c312540f8ede"),
                    new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), "Observer"
                },
                {
                    5L, new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"),
                    new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), "Observer"
                },
                {
                    6L, new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"),
                    new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Observer"
                },
                {
                    7L, new Guid("53a3cfc2-cb2d-4bb7-859f-b7c2b39fd06c"),
                    new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), "Notifier"
                },
                {
                    8L, new Guid("0c046b8d-a551-4fd3-aceb-074b82ffb4a8"),
                    new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"), "Observer"
                },
                {
                    9L, new Guid("feadd605-be98-4f27-8513-2e90d9e331f0"),
                    new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"), "Observer"
                },
                {
                    10L, new Guid("ce814387-a5fd-493b-b140-ec4909daaabf"),
                    new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), "Notifier"
                },
                {
                    11L, new Guid("ca25957b-d494-4d9d-bd23-e48b31b01690"),
                    new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), "Notifier"
                },
                {
                    12L, new Guid("b7449f37-34c2-4691-bd25-b2d136ad48bf"),
                    new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"), "Observer"
                },
                {
                    13L, new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"),
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier"
                },
                {
                    14L, new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"),
                    new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"), "Observer"
                },
                {
                    15L, new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"),
                    new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), "Notifier"
                },
                {
                    16L, new Guid("9ad502c0-f6ed-4218-bc5a-c312540f8ede"),
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier"
                },
                {
                    17L, new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"),
                    new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), "Notifier"
                },
                {
                    18L, new Guid("0d2a9c25-3e6e-483d-a5c0-2547d5748934"),
                    new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), "Observer"
                },
                {
                    19L, new Guid("cf4c8a2c-6641-4cf3-b637-224e01439d1f"),
                    new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"), "Observer"
                },
                {
                    20L, new Guid("94f20bb9-db5e-4d5d-870b-a5c8a957a952"),
                    new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"), "Observer"
                },
                {
                    21L, new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"),
                    new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Observer"
                },
                {
                    22L, new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"),
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Observer"
                },
                {
                    23L, new Guid("1dcc8a35-cf12-4415-b663-f70aa65b2c9d"),
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier"
                },
                {
                    24L, new Guid("c0e98bac-aaa0-4292-a6f3-79f32b8b5548"),
                    new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Observer"
                },
                {
                    25L, new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"),
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier"
                },
                {
                    26L, new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"),
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier"
                },
                {
                    27L, new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"),
                    new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"), "Observer"
                },
                {
                    28L, new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"),
                    new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"), "Observer"
                },
                {
                    29L, new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"),
                    new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"), "Observer"
                },
                {
                    30L, new Guid("18a56a17-d8f2-4ca3-8c2c-521b0901c8e2"),
                    new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"), "Observer"
                },
                {
                    31L, new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"),
                    new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Observer"
                },
                {
                    32L, new Guid("b7449f37-34c2-4691-bd25-b2d136ad48bf"),
                    new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"), "Observer"
                },
                {
                    33L, new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"),
                    new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), "Observer"
                },
                {
                    34L, new Guid("605d9a42-dcdb-44b5-abeb-42561d787886"),
                    new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Notifier"
                },
                {
                    35L, new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"),
                    new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Observer"
                },
                {
                    36L, new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"),
                    new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Notifier"
                },
                {
                    37L, new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"),
                    new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"), "Notifier"
                },
                {
                    38L, new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"),
                    new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Observer"
                },
                {
                    39L, new Guid("7d98a5f3-c3b6-4805-92fa-7727100a1d57"),
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier"
                },
                {
                    40L, new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"),
                    new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"), "Observer"
                },
                {
                    41L, new Guid("605d9a42-dcdb-44b5-abeb-42561d787886"),
                    new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Notifier"
                },
                {
                    42L, new Guid("0ecd7d76-e6be-4670-a244-e6aa4a4ba521"),
                    new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"), "Notifier"
                },
                {
                    43L, new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"),
                    new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"), "Notifier"
                },
                {
                    44L, new Guid("0c046b8d-a551-4fd3-aceb-074b82ffb4a8"),
                    new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Notifier"
                },
                {
                    45L, new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"),
                    new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Notifier"
                },
                {
                    46L, new Guid("aaf9fc1a-4568-4d7e-b67b-3bd1c4cc8723"),
                    new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Observer"
                },
                {
                    47L, new Guid("feadd605-be98-4f27-8513-2e90d9e331f0"),
                    new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"), "Notifier"
                },
                {
                    48L, new Guid("0ecd7d76-e6be-4670-a244-e6aa4a4ba521"),
                    new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"), "Observer"
                },
                {
                    49L, new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"),
                    new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"), "Notifier"
                },
                {
                    50L, new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"),
                    new Guid("4941f913-50d9-478c-8023-47ca581018b5"), "Observer"
                }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("40bc2fbd-e28a-4f9c-96e0-4c7e61cecb3b"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("49e28d01-2067-4d9e-a086-556be1e39ed3"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("81968a99-7398-4900-a6e5-9a1412171465"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("c17268dc-5e86-48c6-bf7f-bb0211a34597"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("105d5675-08a4-4c9f-836d-bdb854eb768d"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("aa65dd8a-868c-40ca-9587-819f774ee3b3"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("b19e9788-a9e1-4219-89e9-8b94f2bda161"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("bedf1488-76ea-49e5-b68c-b651434e005b"));

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            1L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            2L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            3L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            4L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            5L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            6L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            7L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            8L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            9L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            10L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            11L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            12L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            13L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            14L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            15L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            16L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            17L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            18L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            19L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            20L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            21L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            22L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            23L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            24L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            25L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            26L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            27L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            28L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            29L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            30L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            31L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            32L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            33L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            34L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            35L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            36L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            37L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            38L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            39L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            40L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            41L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            42L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            43L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            44L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            45L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            46L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            47L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            48L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            49L);

        migrationBuilder.DeleteData(
            "SubscriptionEntities",
            "Id",
            50L);

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("e592809c-495b-4a54-af87-ff2a4dc2c0f1"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("0935d907-18d7-4c61-b8f1-931477040f9e"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("0c046b8d-a551-4fd3-aceb-074b82ffb4a8"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("0d2a9c25-3e6e-483d-a5c0-2547d5748934"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("0ecd7d76-e6be-4670-a244-e6aa4a4ba521"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("108ac2c9-d18d-418b-b7d9-994130446ed0"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("18a56a17-d8f2-4ca3-8c2c-521b0901c8e2"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("1dcc8a35-cf12-4415-b663-f70aa65b2c9d"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("2d034be3-c1ca-46f9-a140-9d0cd7cae1f2"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("31b8864f-a82c-45e7-8cdb-e7f379916b79"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("3429bfdb-3329-4c36-8100-92aef6c397af"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("53a3cfc2-cb2d-4bb7-859f-b7c2b39fd06c"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("605d9a42-dcdb-44b5-abeb-42561d787886"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("7d98a5f3-c3b6-4805-92fa-7727100a1d57"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("94f20bb9-db5e-4d5d-870b-a5c8a957a952"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("9ad502c0-f6ed-4218-bc5a-c312540f8ede"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("aaf9fc1a-4568-4d7e-b67b-3bd1c4cc8723"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("aba2d3e0-5a65-415c-b288-a2379b3e5585"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("b7449f37-34c2-4691-bd25-b2d136ad48bf"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("c0e98bac-aaa0-4292-a6f3-79f32b8b5548"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("c78980c0-9309-4158-af41-d3cc509d5f09"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("c9a86cef-3fcf-42dd-95e5-9f259d34829a"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("ca25957b-d494-4d9d-bd23-e48b31b01690"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("ce814387-a5fd-493b-b140-ec4909daaabf"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("cf4c8a2c-6641-4cf3-b637-224e01439d1f"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("dee1c798-c4e2-4c93-b4eb-f589cb66ba72"));

        migrationBuilder.DeleteData(
            "MedicalRecordEntities",
            "Id",
            new Guid("feadd605-be98-4f27-8513-2e90d9e331f0"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("4941f913-50d9-478c-8023-47ca581018b5"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("49a5c2b0-cc81-4a40-bbfc-d02b5bde249a"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("63ce2675-2880-4359-a842-7d92a3e5d478"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("6631aa0a-2474-4777-8c6a-92a439cf6672"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("70178d73-1891-4eeb-b1d7-e73b4b55ff63"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("8f3aea52-ba1e-462a-8bf7-3c99d509e3d5"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("bd0177b8-41cc-44fb-9255-ea455e7c91be"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("cfb1814f-64b4-4c28-817d-77530d91fc4b"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("d584ab75-8bd8-4ab6-bf81-22ffccb7f43c"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("d967207e-5cf9-43a0-8dc5-88184da40fbd"));

        migrationBuilder.DeleteData(
            "DoctorEntities",
            "Id",
            new Guid("da630793-8f6d-456d-8c9b-6ee2d601e293"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("0b00c1de-5038-4aba-a635-8c8de68c92a2"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("0b7db7b1-31ca-44b2-9113-9b969130b4f3"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("13315216-3e0a-4c15-a6a8-fcdb85f9224c"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("27aa99e5-7810-4fec-ab4c-bff7034f1f63"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("5bf4f189-f9ea-4341-99f7-7df0c5085cca"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("7aa0a526-a3ea-4f8a-a7f4-83d129145930"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("8d8128db-4e79-49a6-b473-8ac2abf64d83"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("a2b616ce-0588-4fb9-8fcb-eca1d8a22570"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("aeb8aba4-7483-4001-9d9c-d005e9be32f0"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("b4749c5a-ebcd-4c16-acef-e2b3bc11adcb"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("b55b9b0a-5e2d-4c7c-b4d1-7bc4724f069c"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("b9993fbc-df24-4ff8-82d4-d2c71ac9a52e"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("cc573f43-b2b2-4f81-bd93-2755b5f9a8f5"));

        migrationBuilder.DeleteData(
            "PatientEntities",
            "Id",
            new Guid("d0115f46-dda7-4f2c-b2e5-3a7bb37760cd"));

        migrationBuilder.AlterColumn<int>(
                "Id",
                "SubscriptionEntities",
                "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
            .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            1L,
            new[] { "City", "Street", "Zip" },
            new object[] { "Los Angeles", "Cedar Ln", "54403" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            2L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "San Antonio", "TX", "Sunset Blvd", "40323" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            3L,
            new[] { "City", "Street", "Zip" },
            new object[] { "San Jose", "Maple Ave", "77157" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            4L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Philadelphia", "TX", "Pine St", "61935" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            5L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Los Angeles", "IL", "Main St", "78857" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            6L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Los Angeles", "AZ", "Pine St", "77779" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            7L,
            new[] { "City", "Street", "Zip" },
            new object[] { "Phoenix", "Pine St", "19771" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            8L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Dallas", "PA", "Pine St", "36207" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            9L,
            new[] { "City", "Street", "Zip" },
            new object[] { "San Antonio", "Pine St", "20326" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            10L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Dallas", "NY", "Highland Ave", "40541" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            11L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Los Angeles", "PA", "Washington Ave", "94620" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            12L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Los Angeles", "CA", "Broadway", "57361" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            13L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Dallas", "IL", "Pine St", "41357" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            14L,
            new[] { "State", "Street", "Zip" },
            new object[] { "PA", "Washington Ave", "45166" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            15L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Dallas", "CA", "Pine St", "12933" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            16L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "San Jose", "PA", "Washington Ave", "97224" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            17L,
            new[] { "City", "Street", "Zip" },
            new object[] { "Chicago", "Broadway", "77988" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            18L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "New York", "TX", "Highland Ave", "59833" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            19L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Phoenix", "TX", "Elm St", "74098" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            20L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Los Angeles", "TX", "Washington Ave", "91171" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            21L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Philadelphia", "CA", "Pine St", "37646" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            22L,
            new[] { "City", "Zip" },
            new object[] { "Phoenix", "85520" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            23L,
            new[] { "City", "Street", "Zip" },
            new object[] { "San Antonio", "Highland Ave", "38145" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            24L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Houston", "PA", "Sunset Blvd", "74299" });

        migrationBuilder.UpdateData(
            "AddressEntities",
            "Id",
            25L,
            new[] { "City", "State", "Street", "Zip" },
            new object[] { "Los Angeles", "TX", "Oak St", "48495" });

        migrationBuilder.InsertData(
            "DoctorEntities",
            new[]
            {
                "Id", "AddressId", "BirthDate", "Education", "Email", "ExperienceInYears", "FullName", "PhoneNumber",
                "RoomNumber", "Specialization"
            },
            new object[,]
            {
                {
                    new Guid("02fc69ec-c9b2-4bc9-aa83-2ab764d17e12"), 19L, new DateOnly(1997, 2, 7), "Medical Degree",
                    "emma.brown4@aol.com", 4L, "Emma Brown", "+1-666-781-2219", "D-429", "Cardiology"
                },
                {
                    new Guid("214683bd-14f0-49cd-a03f-043b1c754fd4"), 15L, new DateOnly(1956, 3, 19), "Medical Degree",
                    "emily.johnson7@yahoo.com", 20L, "Emily Johnson", "+1-555-434-1791", "B-631", "Neurology"
                },
                {
                    new Guid("4c5101df-9fd4-42ef-a2a6-30757fc0c78e"), 9L, new DateOnly(1974, 7, 5), "Medical Degree",
                    "michael.williams1@yahoo.com", 13L, "Michael Williams", "+1-888-208-3170", "A-618", "Pediatrics"
                },
                {
                    new Guid("55c2dd3d-fa52-4f72-b63f-8442105f2b22"), 23L, new DateOnly(1976, 5, 7), "Medical Degree",
                    "john.smith9@aol.com", 22L, "John Smith", "+1-999-159-7363", "E-882", "Pediatrics"
                },
                {
                    new Guid("6a81a708-8a8c-4166-832d-e8b2bbf42579"), 17L, new DateOnly(1962, 3, 16), "Medical Degree",
                    "john.smith7@aol.com", 16L, "John Smith", "+1-999-154-5732", "B-929", "Oncology"
                },
                {
                    new Guid("7a18f5d6-6ed2-47de-9be6-774a85d3f842"), 11L, new DateOnly(1964, 10, 5), "Medical Degree",
                    "emily.johnson0@aol.com", 10L, "Emily Johnson", "+1-666-142-2922", "A-270", "Cardiology"
                },
                {
                    new Guid("7a42e927-9837-40ae-819b-dfca4058a3df"), 2L, new DateOnly(1996, 10, 4), "Medical Degree",
                    "emma.brown1@outlook.com", 25L, "Emma Brown", "+1-555-303-3381", "C-417", "Orthopedics"
                },
                {
                    new Guid("857d323a-6fb7-4751-a8c2-6338a98389bc"), 14L, new DateOnly(1983, 1, 25), "Medical Degree",
                    "michael.williams4@hotmail.com", 13L, "Michael Williams", "+1-555-378-1618", "D-517", "Cardiology"
                },
                {
                    new Guid("a862d15f-7651-4c0a-8a6f-58b39d0c7c35"), 2L, new DateOnly(1984, 10, 5), "Medical Degree",
                    "john.smith3@aol.com", 19L, "John Smith", "+1-777-634-6023", "E-687", "Oncology"
                },
                {
                    new Guid("accf60ef-aa52-4318-9a38-413b26c02acc"), 4L, new DateOnly(1996, 6, 3), "Medical Degree",
                    "emma.brown3@aol.com", 5L, "Emma Brown", "+1-777-848-8767", "D-639", "Neurology"
                },
                {
                    new Guid("adb7f2bf-3f3b-4693-ade2-0367c23238db"), 17L, new DateOnly(1957, 3, 24), "Medical Degree",
                    "michael.williams5@gmail.com", 10L, "Michael Williams", "+1-555-983-7440", "D-506", "Pediatrics"
                },
                {
                    new Guid("f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de"), 2L, new DateOnly(1991, 11, 26), "Medical Degree",
                    "john.smith1@gmail.com", 19L, "John Smith", "+1-999-852-2263", "E-853", "Oncology"
                },
                {
                    new Guid("f8cf402f-174d-4383-8311-9c10e3a5ae29"), 21L, new DateOnly(1970, 5, 2), "Medical Degree",
                    "james.jones5@yahoo.com", 5L, "James Jones", "+1-999-633-4994", "B-870", "Cardiology"
                },
                {
                    new Guid("fa88ccfd-d5a9-41fd-a5f3-975280ea1c9f"), 5L, new DateOnly(1955, 8, 13), "Medical Degree",
                    "emma.brown4@gmail.com", 12L, "Emma Brown", "+1-888-287-8516", "D-273", "Orthopedics"
                },
                {
                    new Guid("fc21f2ff-e569-4fc7-a635-c6069f64e043"), 23L, new DateOnly(1971, 12, 20), "Medical Degree",
                    "james.jones9@yahoo.com", 24L, "James Jones", "+1-555-577-1048", "E-104", "Neurology"
                }
            });

        migrationBuilder.InsertData(
            "PatientEntities",
            new[]
            {
                "Id", "AddressId", "BirthDate", "Email", "FullName", "InsurancePolicyNumber", "InsuranceProvider",
                "PhoneNumber"
            },
            new object[,]
            {
                {
                    new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"), 17L, new DateOnly(1963, 12, 2),
                    "liam.anderson1@hotmail.com", "Liam Anderson", "256045754", "Bright Health", "+1-444-796-8711"
                },
                {
                    new Guid("3606c837-ae0d-46b7-ad9a-6fc2c866715a"), 4L, new DateOnly(1966, 6, 11),
                    "amelia.clark2@yahoo.com", "Amelia Clark", "533830533", "Oxford Health Plans", "+1-444-372-8019"
                },
                {
                    new Guid("4fbc5155-e9f2-47e4-9cd2-b021726cdd80"), 12L, new DateOnly(1961, 10, 11),
                    "mason.harris2@gmail.com", "Mason Harris", "824191038", "Oxford Health Plans", "+1-333-490-1246"
                },
                {
                    new Guid("534bebae-0954-43a8-bb59-064d727e17e7"), 6L, new DateOnly(1952, 2, 3),
                    "mason.harris7@hotmail.com", "Mason Harris", "278016028", "Friday Health Plans", "+1-444-505-6073"
                },
                {
                    new Guid("643e41eb-9b21-4fab-8f59-668ae46395fa"), 9L, new DateOnly(1980, 5, 25),
                    "ethan.jackson9@outlook.com", "Ethan Jackson", "993340709", "Aetna", "+1-444-874-1363"
                },
                {
                    new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"), 24L, new DateOnly(1957, 12, 3),
                    "ava.white4@aol.com", "Ava White", "350814514", "Molina Healthcare", "+1-333-582-3226"
                },
                {
                    new Guid("8042d801-bdc4-4dca-879d-ee57ee45cb9e"), 20L, new DateOnly(1950, 9, 1),
                    "amelia.clark7@gmail.com", "Amelia Clark", "297282585", "Health Net", "+1-444-945-4927"
                },
                {
                    new Guid("9f5cb4d7-1e3c-49a6-a71f-d9605e18ea6d"), 24L, new DateOnly(1974, 8, 8),
                    "isabella.martinez1@outlook.com", "Isabella Martinez", "126471492", "BlueCross", "+1-444-252-7983"
                },
                {
                    new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"), 14L, new DateOnly(1967, 4, 16),
                    "ava.white3@gmail.com", "Ava White", "686503722", "Molina Healthcare", "+1-333-836-9819"
                },
                {
                    new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"), 19L, new DateOnly(1972, 5, 2),
                    "mason.harris6@hotmail.com", "Mason Harris", "938503794", "UnitedHealthcare", "+1-444-622-8295"
                },
                {
                    new Guid("ab413ddc-0b02-48e7-b387-436a832f7d44"), 8L, new DateOnly(1959, 11, 17),
                    "ethan.jackson4@outlook.com", "Ethan Jackson", "656990873", "Oxford Health Plans", "+1-444-663-4951"
                },
                {
                    new Guid("c24f9152-fb5d-4df3-b752-c713506c2b7a"), 11L, new DateOnly(1998, 3, 25),
                    "william.wilson1@gmail.com", "William Wilson", "612878095", "Oxford Health Plans", "+1-222-562-9953"
                },
                {
                    new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"), 18L, new DateOnly(1957, 8, 18),
                    "ava.white5@yahoo.com", "Ava White", "906166069", "Molina Healthcare", "+1-444-652-2205"
                },
                {
                    new Guid("e465c73a-da65-4979-8ca4-c0042cc18c06"), 11L, new DateOnly(1971, 10, 21),
                    "sophia.taylor6@hotmail.com", "Sophia Taylor", "216430902", "Health Net", "+1-333-399-1615"
                },
                {
                    new Guid("ec60232f-032e-4b90-b122-33237264cc02"), 16L, new DateOnly(1952, 5, 12),
                    "olivia.davis4@hotmail.com", "Olivia Davis", "360186698", "Oscar Health", "+1-444-412-6850"
                }
            });

        migrationBuilder.InsertData(
            "MedicalRecordEntities",
            new[] { "Id", "CreatedAt", "DoctorId", "PatientId", "Record", "UpdatedAt" },
            new object[,]
            {
                {
                    new Guid("00f9a2f4-afbf-41e9-87dc-70ea1a3ea8a9"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8033),
                    new Guid("adb7f2bf-3f3b-4693-ade2-0367c23238db"), new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"),
                    "Medical record 9 for patient a2d2fc9b-7666-4041-ac73-b05d8217da67 and doctor adb7f2bf-3f3b-4693-ade2-0367c23238db",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8033)
                },
                {
                    new Guid("11492bff-ce05-4b98-9d9f-d2b754329504"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8158),
                    new Guid("f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de"), new Guid("643e41eb-9b21-4fab-8f59-668ae46395fa"),
                    "Medical record 24 for patient 643e41eb-9b21-4fab-8f59-668ae46395fa and doctor f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8158)
                },
                {
                    new Guid("1eba5bba-673a-4d55-baf4-39a3d711c3d3"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8132),
                    new Guid("accf60ef-aa52-4318-9a38-413b26c02acc"), new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"),
                    "Medical record 21 for patient dd161b06-c857-4691-8c7a-47e83a5c4993 and doctor accf60ef-aa52-4318-9a38-413b26c02acc",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8133)
                },
                {
                    new Guid("2540134b-a81f-4e04-9f9a-761a339ffbc0"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8164),
                    new Guid("fc21f2ff-e569-4fc7-a635-c6069f64e043"), new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"),
                    "Medical record 25 for patient dd161b06-c857-4691-8c7a-47e83a5c4993 and doctor fc21f2ff-e569-4fc7-a635-c6069f64e043",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8165)
                },
                {
                    new Guid("255d4a8a-b657-4e4e-b595-265f56584b11"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8126),
                    new Guid("f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de"), new Guid("c24f9152-fb5d-4df3-b752-c713506c2b7a"),
                    "Medical record 20 for patient c24f9152-fb5d-4df3-b752-c713506c2b7a and doctor f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8126)
                },
                {
                    new Guid("2bb5242b-205c-4626-a5d1-59bddbb74335"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8072),
                    new Guid("214683bd-14f0-49cd-a03f-043b1c754fd4"), new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"),
                    "Medical record 13 for patient a2d2fc9b-7666-4041-ac73-b05d8217da67 and doctor 214683bd-14f0-49cd-a03f-043b1c754fd4",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8072)
                },
                {
                    new Guid("2c3ed2bb-afe0-4430-b07f-e5a8a3806268"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8191),
                    new Guid("accf60ef-aa52-4318-9a38-413b26c02acc"), new Guid("e465c73a-da65-4979-8ca4-c0042cc18c06"),
                    "Medical record 29 for patient e465c73a-da65-4979-8ca4-c0042cc18c06 and doctor accf60ef-aa52-4318-9a38-413b26c02acc",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8192)
                },
                {
                    new Guid("2f644c81-241e-49ea-aec9-043a89caa107"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8095),
                    new Guid("f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de"), new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"),
                    "Medical record 16 for patient a2d2fc9b-7666-4041-ac73-b05d8217da67 and doctor f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8096)
                },
                {
                    new Guid("313f3635-3e70-47c5-b515-e536522ab881"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8056),
                    new Guid("f8cf402f-174d-4383-8311-9c10e3a5ae29"), new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"),
                    "Medical record 12 for patient 7ed2c8b5-4b08-4414-8c76-516f46c5a937 and doctor f8cf402f-174d-4383-8311-9c10e3a5ae29",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8057)
                },
                {
                    new Guid("34b867d1-ed38-4c6d-ace0-33784526f18c"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8119),
                    new Guid("accf60ef-aa52-4318-9a38-413b26c02acc"), new Guid("8042d801-bdc4-4dca-879d-ee57ee45cb9e"),
                    "Medical record 19 for patient 8042d801-bdc4-4dca-879d-ee57ee45cb9e and doctor accf60ef-aa52-4318-9a38-413b26c02acc",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8119)
                },
                {
                    new Guid("40e50140-66d2-4e35-bc6b-164c75ee3329"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7980),
                    new Guid("adb7f2bf-3f3b-4693-ade2-0367c23238db"), new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"),
                    "Medical record 3 for patient 12db27b5-7019-4077-a1c4-03b29e9e71d7 and doctor adb7f2bf-3f3b-4693-ade2-0367c23238db",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7981)
                },
                {
                    new Guid("502905cd-eebb-4cc8-992e-a3633ca2a2fb"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7972),
                    new Guid("accf60ef-aa52-4318-9a38-413b26c02acc"), new Guid("3606c837-ae0d-46b7-ad9a-6fc2c866715a"),
                    "Medical record 2 for patient 3606c837-ae0d-46b7-ad9a-6fc2c866715a and doctor accf60ef-aa52-4318-9a38-413b26c02acc",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7972)
                },
                {
                    new Guid("5fcff655-a07f-4aa6-8f7a-bfc2260743c4"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8178),
                    new Guid("02fc69ec-c9b2-4bc9-aa83-2ab764d17e12"), new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"),
                    "Medical record 27 for patient aa8e7cab-6c7e-446a-98ea-f5c8564099a4 and doctor 02fc69ec-c9b2-4bc9-aa83-2ab764d17e12",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8179)
                },
                {
                    new Guid("6cdec137-1db9-4031-b31c-99d86591b0e5"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8151),
                    new Guid("55c2dd3d-fa52-4f72-b63f-8442105f2b22"), new Guid("9f5cb4d7-1e3c-49a6-a71f-d9605e18ea6d"),
                    "Medical record 23 for patient 9f5cb4d7-1e3c-49a6-a71f-d9605e18ea6d and doctor 55c2dd3d-fa52-4f72-b63f-8442105f2b22",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8151)
                },
                {
                    new Guid("6dc4d648-8ab0-4f62-ba16-a7aed239f9bd"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7989),
                    new Guid("02fc69ec-c9b2-4bc9-aa83-2ab764d17e12"), new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"),
                    "Medical record 4 for patient aa8e7cab-6c7e-446a-98ea-f5c8564099a4 and doctor 02fc69ec-c9b2-4bc9-aa83-2ab764d17e12",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7989)
                },
                {
                    new Guid("6f5bda39-07c0-43fd-bdea-3b1a8144f8de"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8089),
                    new Guid("adb7f2bf-3f3b-4693-ade2-0367c23238db"), new Guid("3606c837-ae0d-46b7-ad9a-6fc2c866715a"),
                    "Medical record 15 for patient 3606c837-ae0d-46b7-ad9a-6fc2c866715a and doctor adb7f2bf-3f3b-4693-ade2-0367c23238db",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8089)
                },
                {
                    new Guid("870f2507-20bc-40aa-a613-407e88e6a1ba"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7960),
                    new Guid("214683bd-14f0-49cd-a03f-043b1c754fd4"), new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"),
                    "Medical record 1 for patient 7ed2c8b5-4b08-4414-8c76-516f46c5a937 and doctor 214683bd-14f0-49cd-a03f-043b1c754fd4",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7961)
                },
                {
                    new Guid("8741d404-bf5f-4768-bd05-1a0e6e562457"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8048),
                    new Guid("7a42e927-9837-40ae-819b-dfca4058a3df"), new Guid("e465c73a-da65-4979-8ca4-c0042cc18c06"),
                    "Medical record 11 for patient e465c73a-da65-4979-8ca4-c0042cc18c06 and doctor 7a42e927-9837-40ae-819b-dfca4058a3df",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8049)
                },
                {
                    new Guid("8a6b4292-e653-436e-81c9-eedec4f78f41"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8185),
                    new Guid("4c5101df-9fd4-42ef-a2a6-30757fc0c78e"), new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"),
                    "Medical record 28 for patient a2d2fc9b-7666-4041-ac73-b05d8217da67 and doctor 4c5101df-9fd4-42ef-a2a6-30757fc0c78e",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8186)
                },
                {
                    new Guid("8b80619b-eff1-4dd9-83ae-cfdacf1e142d"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8042),
                    new Guid("7a42e927-9837-40ae-819b-dfca4058a3df"), new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"),
                    "Medical record 10 for patient a2d2fc9b-7666-4041-ac73-b05d8217da67 and doctor 7a42e927-9837-40ae-819b-dfca4058a3df",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8042)
                },
                {
                    new Guid("9446f4a3-93b7-4b3f-976b-2b8b9e657da5"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8019),
                    new Guid("02fc69ec-c9b2-4bc9-aa83-2ab764d17e12"), new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"),
                    "Medical record 7 for patient a2d2fc9b-7666-4041-ac73-b05d8217da67 and doctor 02fc69ec-c9b2-4bc9-aa83-2ab764d17e12",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8019)
                },
                {
                    new Guid("96ca3060-29a9-4f74-ad35-f624d940fe1a"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8102),
                    new Guid("214683bd-14f0-49cd-a03f-043b1c754fd4"), new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"),
                    "Medical record 17 for patient 12db27b5-7019-4077-a1c4-03b29e9e71d7 and doctor 214683bd-14f0-49cd-a03f-043b1c754fd4",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8103)
                },
                {
                    new Guid("97a2391b-48d5-42c6-871a-8d9e680aa2ac"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8171),
                    new Guid("f8cf402f-174d-4383-8311-9c10e3a5ae29"), new Guid("534bebae-0954-43a8-bb59-064d727e17e7"),
                    "Medical record 26 for patient 534bebae-0954-43a8-bb59-064d727e17e7 and doctor f8cf402f-174d-4383-8311-9c10e3a5ae29",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8172)
                },
                {
                    new Guid("b50fc554-4110-4887-b2d9-90e9b242da75"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8011),
                    new Guid("fa88ccfd-d5a9-41fd-a5f3-975280ea1c9f"), new Guid("e465c73a-da65-4979-8ca4-c0042cc18c06"),
                    "Medical record 6 for patient e465c73a-da65-4979-8ca4-c0042cc18c06 and doctor fa88ccfd-d5a9-41fd-a5f3-975280ea1c9f",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8012)
                },
                {
                    new Guid("be4d2840-5126-498b-8390-cfef9e4bcdc3"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8200),
                    new Guid("f8cf402f-174d-4383-8311-9c10e3a5ae29"), new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"),
                    "Medical record 30 for patient a2d2fc9b-7666-4041-ac73-b05d8217da67 and doctor f8cf402f-174d-4383-8311-9c10e3a5ae29",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8201)
                },
                {
                    new Guid("ce0f1789-fa24-4e66-a935-00f0ed7d724b"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7997),
                    new Guid("6a81a708-8a8c-4166-832d-e8b2bbf42579"), new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"),
                    "Medical record 5 for patient dd161b06-c857-4691-8c7a-47e83a5c4993 and doctor 6a81a708-8a8c-4166-832d-e8b2bbf42579",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(7998)
                },
                {
                    new Guid("e7be8d0a-4c55-43f2-977d-f847808c231c"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8142),
                    new Guid("4c5101df-9fd4-42ef-a2a6-30757fc0c78e"), new Guid("8042d801-bdc4-4dca-879d-ee57ee45cb9e"),
                    "Medical record 22 for patient 8042d801-bdc4-4dca-879d-ee57ee45cb9e and doctor 4c5101df-9fd4-42ef-a2a6-30757fc0c78e",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8143)
                },
                {
                    new Guid("ec5ed62f-12dd-48de-a548-76c8b55f8f92"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8111),
                    new Guid("fc21f2ff-e569-4fc7-a635-c6069f64e043"), new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"),
                    "Medical record 18 for patient dd161b06-c857-4691-8c7a-47e83a5c4993 and doctor fc21f2ff-e569-4fc7-a635-c6069f64e043",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8112)
                },
                {
                    new Guid("f4573ca4-d36f-4d21-beeb-629b01628d39"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8026),
                    new Guid("f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de"), new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"),
                    "Medical record 8 for patient 12db27b5-7019-4077-a1c4-03b29e9e71d7 and doctor f2be1eab-3d9f-4ecb-9d3d-eed1a67df0de",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8027)
                },
                {
                    new Guid("f785ae7d-488a-4544-8066-775ea77f187b"),
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8081),
                    new Guid("f8cf402f-174d-4383-8311-9c10e3a5ae29"), new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"),
                    "Medical record 14 for patient 7ed2c8b5-4b08-4414-8c76-516f46c5a937 and doctor f8cf402f-174d-4383-8311-9c10e3a5ae29",
                    new DateTime(2024, 6, 8, 12, 44, 29, 382, DateTimeKind.Utc).AddTicks(8082)
                }
            });

        migrationBuilder.InsertData(
            "SubscriptionEntities",
            new[] { "Id", "MedicalRecordId", "PatientId", "SubscriptionType" },
            new object[,]
            {
                {
                    1, new Guid("11492bff-ce05-4b98-9d9f-d2b754329504"),
                    new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"), "Observer"
                },
                {
                    2, new Guid("ec5ed62f-12dd-48de-a548-76c8b55f8f92"),
                    new Guid("ab413ddc-0b02-48e7-b387-436a832f7d44"), "Observer"
                },
                {
                    3, new Guid("ec5ed62f-12dd-48de-a548-76c8b55f8f92"),
                    new Guid("534bebae-0954-43a8-bb59-064d727e17e7"), "Notifier"
                },
                {
                    4, new Guid("6cdec137-1db9-4031-b31c-99d86591b0e5"),
                    new Guid("c24f9152-fb5d-4df3-b752-c713506c2b7a"), "Observer"
                },
                {
                    5, new Guid("6cdec137-1db9-4031-b31c-99d86591b0e5"),
                    new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"), "Observer"
                },
                {
                    6, new Guid("2540134b-a81f-4e04-9f9a-761a339ffbc0"),
                    new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"), "Observer"
                },
                {
                    7, new Guid("40e50140-66d2-4e35-bc6b-164c75ee3329"),
                    new Guid("643e41eb-9b21-4fab-8f59-668ae46395fa"), "Notifier"
                },
                {
                    8, new Guid("502905cd-eebb-4cc8-992e-a3633ca2a2fb"),
                    new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"), "Observer"
                },
                {
                    9, new Guid("34b867d1-ed38-4c6d-ace0-33784526f18c"),
                    new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"), "Notifier"
                },
                {
                    10, new Guid("96ca3060-29a9-4f74-ad35-f624d940fe1a"),
                    new Guid("ab413ddc-0b02-48e7-b387-436a832f7d44"), "Notifier"
                },
                {
                    11, new Guid("255d4a8a-b657-4e4e-b595-265f56584b11"),
                    new Guid("8042d801-bdc4-4dca-879d-ee57ee45cb9e"), "Observer"
                },
                {
                    12, new Guid("2f644c81-241e-49ea-aec9-043a89caa107"),
                    new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"), "Notifier"
                },
                {
                    13, new Guid("96ca3060-29a9-4f74-ad35-f624d940fe1a"),
                    new Guid("c24f9152-fb5d-4df3-b752-c713506c2b7a"), "Observer"
                },
                {
                    14, new Guid("2f644c81-241e-49ea-aec9-043a89caa107"),
                    new Guid("643e41eb-9b21-4fab-8f59-668ae46395fa"), "Notifier"
                },
                {
                    15, new Guid("9446f4a3-93b7-4b3f-976b-2b8b9e657da5"),
                    new Guid("e465c73a-da65-4979-8ca4-c0042cc18c06"), "Observer"
                },
                {
                    16, new Guid("6cdec137-1db9-4031-b31c-99d86591b0e5"),
                    new Guid("534bebae-0954-43a8-bb59-064d727e17e7"), "Notifier"
                },
                {
                    17, new Guid("b50fc554-4110-4887-b2d9-90e9b242da75"),
                    new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"), "Observer"
                },
                {
                    18, new Guid("ec5ed62f-12dd-48de-a548-76c8b55f8f92"),
                    new Guid("4fbc5155-e9f2-47e4-9cd2-b021726cdd80"), "Observer"
                },
                {
                    19, new Guid("34b867d1-ed38-4c6d-ace0-33784526f18c"),
                    new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"), "Observer"
                },
                {
                    20, new Guid("2540134b-a81f-4e04-9f9a-761a339ffbc0"),
                    new Guid("9f5cb4d7-1e3c-49a6-a71f-d9605e18ea6d"), "Observer"
                },
                {
                    21, new Guid("be4d2840-5126-498b-8390-cfef9e4bcdc3"),
                    new Guid("9f5cb4d7-1e3c-49a6-a71f-d9605e18ea6d"), "Observer"
                },
                {
                    22, new Guid("f4573ca4-d36f-4d21-beeb-629b01628d39"),
                    new Guid("8042d801-bdc4-4dca-879d-ee57ee45cb9e"), "Notifier"
                },
                {
                    23, new Guid("9446f4a3-93b7-4b3f-976b-2b8b9e657da5"),
                    new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"), "Notifier"
                },
                {
                    24, new Guid("ce0f1789-fa24-4e66-a935-00f0ed7d724b"),
                    new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"), "Notifier"
                },
                {
                    25, new Guid("313f3635-3e70-47c5-b515-e536522ab881"),
                    new Guid("ec60232f-032e-4b90-b122-33237264cc02"), "Notifier"
                },
                {
                    26, new Guid("5fcff655-a07f-4aa6-8f7a-bfc2260743c4"),
                    new Guid("643e41eb-9b21-4fab-8f59-668ae46395fa"), "Observer"
                },
                {
                    27, new Guid("f785ae7d-488a-4544-8066-775ea77f187b"),
                    new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"), "Notifier"
                },
                {
                    28, new Guid("5fcff655-a07f-4aa6-8f7a-bfc2260743c4"),
                    new Guid("643e41eb-9b21-4fab-8f59-668ae46395fa"), "Observer"
                },
                {
                    29, new Guid("2540134b-a81f-4e04-9f9a-761a339ffbc0"),
                    new Guid("643e41eb-9b21-4fab-8f59-668ae46395fa"), "Observer"
                },
                {
                    30, new Guid("ce0f1789-fa24-4e66-a935-00f0ed7d724b"),
                    new Guid("ec60232f-032e-4b90-b122-33237264cc02"), "Observer"
                },
                {
                    31, new Guid("f785ae7d-488a-4544-8066-775ea77f187b"),
                    new Guid("4fbc5155-e9f2-47e4-9cd2-b021726cdd80"), "Notifier"
                },
                {
                    32, new Guid("11492bff-ce05-4b98-9d9f-d2b754329504"),
                    new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"), "Observer"
                },
                {
                    33, new Guid("ec5ed62f-12dd-48de-a548-76c8b55f8f92"),
                    new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"), "Notifier"
                },
                {
                    34, new Guid("6dc4d648-8ab0-4f62-ba16-a7aed239f9bd"),
                    new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"), "Notifier"
                },
                {
                    35, new Guid("2f644c81-241e-49ea-aec9-043a89caa107"),
                    new Guid("534bebae-0954-43a8-bb59-064d727e17e7"), "Observer"
                },
                {
                    36, new Guid("2540134b-a81f-4e04-9f9a-761a339ffbc0"),
                    new Guid("c24f9152-fb5d-4df3-b752-c713506c2b7a"), "Notifier"
                },
                {
                    37, new Guid("870f2507-20bc-40aa-a613-407e88e6a1ba"),
                    new Guid("a2d2fc9b-7666-4041-ac73-b05d8217da67"), "Notifier"
                },
                {
                    38, new Guid("1eba5bba-673a-4d55-baf4-39a3d711c3d3"),
                    new Guid("ec60232f-032e-4b90-b122-33237264cc02"), "Notifier"
                },
                {
                    39, new Guid("ce0f1789-fa24-4e66-a935-00f0ed7d724b"),
                    new Guid("e465c73a-da65-4979-8ca4-c0042cc18c06"), "Observer"
                },
                {
                    40, new Guid("9446f4a3-93b7-4b3f-976b-2b8b9e657da5"),
                    new Guid("7ed2c8b5-4b08-4414-8c76-516f46c5a937"), "Notifier"
                },
                {
                    41, new Guid("00f9a2f4-afbf-41e9-87dc-70ea1a3ea8a9"),
                    new Guid("c24f9152-fb5d-4df3-b752-c713506c2b7a"), "Observer"
                },
                {
                    42, new Guid("502905cd-eebb-4cc8-992e-a3633ca2a2fb"),
                    new Guid("3606c837-ae0d-46b7-ad9a-6fc2c866715a"), "Observer"
                },
                {
                    43, new Guid("2540134b-a81f-4e04-9f9a-761a339ffbc0"),
                    new Guid("12db27b5-7019-4077-a1c4-03b29e9e71d7"), "Observer"
                },
                {
                    44, new Guid("97a2391b-48d5-42c6-871a-8d9e680aa2ac"),
                    new Guid("dd161b06-c857-4691-8c7a-47e83a5c4993"), "Notifier"
                },
                {
                    45, new Guid("96ca3060-29a9-4f74-ad35-f624d940fe1a"),
                    new Guid("ab413ddc-0b02-48e7-b387-436a832f7d44"), "Observer"
                },
                {
                    46, new Guid("f4573ca4-d36f-4d21-beeb-629b01628d39"),
                    new Guid("e465c73a-da65-4979-8ca4-c0042cc18c06"), "Notifier"
                },
                {
                    47, new Guid("2f644c81-241e-49ea-aec9-043a89caa107"),
                    new Guid("ec60232f-032e-4b90-b122-33237264cc02"), "Notifier"
                },
                {
                    48, new Guid("96ca3060-29a9-4f74-ad35-f624d940fe1a"),
                    new Guid("3606c837-ae0d-46b7-ad9a-6fc2c866715a"), "Notifier"
                },
                {
                    49, new Guid("6dc4d648-8ab0-4f62-ba16-a7aed239f9bd"),
                    new Guid("aa8e7cab-6c7e-446a-98ea-f5c8564099a4"), "Notifier"
                },
                {
                    50, new Guid("96ca3060-29a9-4f74-ad35-f624d940fe1a"),
                    new Guid("ab413ddc-0b02-48e7-b387-436a832f7d44"), "Observer"
                }
            });
    }
}