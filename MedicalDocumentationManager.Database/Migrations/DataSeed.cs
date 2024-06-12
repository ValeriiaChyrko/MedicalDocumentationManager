#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalDocumentationManager.Database.Migrations;

/// <inheritdoc />
public partial class DataSeed : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            "AddressEntities",
            new[] { "Id", "City", "State", "Street", "Zip" },
            new object[,]
            {
                { 1L, "Los Angeles", "IL", "Cedar Ln", "54403" },
                { 2L, "San Antonio", "TX", "Sunset Blvd", "40323" },
                { 3L, "San Jose", "CA", "Maple Ave", "77157" },
                { 4L, "Philadelphia", "TX", "Pine St", "61935" },
                { 5L, "Los Angeles", "IL", "Main St", "78857" },
                { 6L, "Los Angeles", "AZ", "Pine St", "77779" },
                { 7L, "Phoenix", "CA", "Pine St", "19771" },
                { 8L, "Dallas", "PA", "Pine St", "36207" },
                { 9L, "San Antonio", "TX", "Pine St", "20326" },
                { 10L, "Dallas", "NY", "Highland Ave", "40541" },
                { 11L, "Los Angeles", "PA", "Washington Ave", "94620" },
                { 12L, "Los Angeles", "CA", "Broadway", "57361" },
                { 13L, "Dallas", "IL", "Pine St", "41357" },
                { 14L, "Phoenix", "PA", "Washington Ave", "45166" },
                { 15L, "Dallas", "CA", "Pine St", "12933" },
                { 16L, "San Jose", "PA", "Washington Ave", "97224" },
                { 17L, "Chicago", "TX", "Broadway", "77988" },
                { 18L, "New York", "TX", "Highland Ave", "59833" },
                { 19L, "Phoenix", "TX", "Elm St", "74098" },
                { 20L, "Los Angeles", "TX", "Washington Ave", "91171" },
                { 21L, "Philadelphia", "CA", "Pine St", "37646" },
                { 22L, "Phoenix", "CA", "Elm St", "85520" },
                { 23L, "San Antonio", "AZ", "Highland Ave", "38145" },
                { 24L, "Houston", "PA", "Sunset Blvd", "74299" },
                { 25L, "Los Angeles", "TX", "Oak St", "48495" }
            });

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

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            1L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            3L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            7L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            10L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            13L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            22L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            25L);

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
            "AddressEntities",
            "Id",
            8L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            12L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            16L);

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

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            2L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            4L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            5L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            6L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            9L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            11L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            14L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            15L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            17L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            18L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            19L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            20L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            21L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            23L);

        migrationBuilder.DeleteData(
            "AddressEntities",
            "Id",
            24L);
    }
}