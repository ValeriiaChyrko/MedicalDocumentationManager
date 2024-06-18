using AutoMapper;
using FluentAssertions;
using FluentValidation;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalDocumentationManager.DTOs.Tests;

[TestFixture]
public class DependencyInjectionTests
{
    [Test]
    public void AddDTOsServices_RegistersValidators()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddDtosServices();

        // Assert
        services.Should().Contain(sd => sd.ServiceType == typeof(IValidator<AddressDto>));
        services.Should().Contain(sd => sd.ServiceType == typeof(IValidator<RequestDoctorDto>));
        services.Should().Contain(sd => sd.ServiceType == typeof(IValidator<RequestMedicalRecordDto>));
        services.Should().Contain(sd => sd.ServiceType == typeof(IValidator<RequestPatientDto>));
        services.Should().Contain(sd => sd.ServiceType == typeof(IValidator<SubscriptionDto>));
    }

    [Test]
    public void AddDTOsServices_Registers_AutoMapper_Configurations()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddDtosServices();

        // Assert
        services.Should().Contain(sd => sd.ServiceType == typeof(IMapper));
    }
    
    [Test]
    public void AddDtosServices_ShouldRegisterAutoMapperProfiles()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddDtosServices();
        var serviceProvider = services.BuildServiceProvider();
        var mapper = serviceProvider.GetRequiredService<IMapper>();

        // Assert
       TestMappingProfile<AddressDto, Address>(mapper);
       TestMappingProfile<RequestDoctorDto, DoctorEntity>(mapper);
       TestMappingProfile<RequestPatientDto, PatientEntity>(mapper);
       TestMappingProfile<RequestMedicalRecordDto, MedicalRecordEntity>(mapper);
       TestMappingProfile<SubscriptionDto, SubscriptionEntity>(mapper);
    }

    private void TestMappingProfile<TSource, TDestination>(IMapper mapper)
    {
        var source = Activator.CreateInstance<TSource>();
        var destination = mapper.Map<TDestination>(source);
        destination.Should().NotBeNull();
    }

    [Test]
    public void AddressMappingProfile_AutoMapper_Configuration_IsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AddressMappingProfile>());

        // Act
        config.AssertConfigurationIsValid();
    }
    
    [Test]
    public void DoctorMappingProfile_AutoMapper_Configuration_IsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AddressMappingProfile>();
            cfg.AddProfile<DoctorMappingProfile>();
        });

        // Act
        config.AssertConfigurationIsValid();
    }
    
    [Test]
    public void DomainModelsMappingProfile_AutoMapper_Configuration_IsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<DomainModelsMappingProfile>());

        // Act
        config.AssertConfigurationIsValid();
    }
    
    [Test]
    public void MedicalRecordMappingProfile_AutoMapper_Configuration_IsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MedicalRecordMappingProfile>());

        // Act
        config.AssertConfigurationIsValid();
    }
    
    [Test]
    public void PatientMappingProfile_AutoMapper_Configuration_IsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AddressMappingProfile>();
            cfg.AddProfile<PatientMappingProfile>();
        });

        // Act
        config.AssertConfigurationIsValid();
    }
    
    [Test]
    public void SubscriptionMappingProfile_AutoMapper_Configuration_IsValid()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<SubscriptionMappingProfile>());

        // Act
        config.AssertConfigurationIsValid();
    }
}