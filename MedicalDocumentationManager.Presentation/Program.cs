using MedicalDocumentationManager.Application;
using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Database;
using MedicalDocumentationManager.Domain;
using MedicalDocumentationManager.DTOs;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.Presentation;

public static class Program
{
    public static async Task Main()
    {
        var serviceProvider = ConfigureServices();
        
        var medicalRecordService = serviceProvider.GetRequiredService<IMedicalRecordService>();
        
        var medicalRecordId = Guid.Parse("6eb8aa5b-33b8-4c99-9e04-0af0be9cda0c");
        var medicalRecord = await medicalRecordService.GetMedicalRecordByIdAsync(medicalRecordId);
        
        var medicalRecordDto = new RequestMedicalRecordDto
        {
            PatientId = medicalRecord!.PatientId,
            DoctorId = medicalRecord.DoctorId,
            Record = $"Updated information at {DateTime.Now}"
        };
        
        var medicalRecordId2 = Guid.Parse("cc832aa3-44ae-4310-ae9b-3b08ec8fdcf9");
        var medicalRecord2 = await medicalRecordService.GetMedicalRecordByIdAsync(medicalRecordId2);
        
        var medicalRecordDto2 = new RequestMedicalRecordDto
        {
            PatientId = medicalRecord2!.PatientId,
            DoctorId = medicalRecord2.DoctorId,
            Record = $"Updated record at {DateTime.Now}"
        };

        medicalRecord = await medicalRecordService.UpdateMedicalRecordAsync(medicalRecord.Id, medicalRecordDto);
        Console.WriteLine($"Updated medical record: {medicalRecord.Id}. Observer patient: {medicalRecord.PatientId}");
        
        medicalRecord2 = await medicalRecordService.UpdateMedicalRecordAsync(medicalRecord2.Id, medicalRecordDto2);
        Console.WriteLine($"Updated medical record: {medicalRecord2.Id} Observer patient: {medicalRecord2.PatientId}");
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        services.AddSingleton<IConfiguration>(configuration);

        services.AddDatabaseServices();
        services.AddPersistenceServices();
        services.AddDomainServices();
        services.AddDtosServices();
        services.AddApplicationServices();

        return services.BuildServiceProvider();
    }
}