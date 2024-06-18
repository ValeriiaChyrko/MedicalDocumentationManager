using AutoMapper;
using FluentAssertions;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using NSubstitute;

namespace MedicalDocumentationManager.DTOs.Tests;

[TestFixture]
public class DomainModelsMappingProfileTests
{
    private IMapper _mapper = null!;

    [SetUp]
    public void SetUp()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AddressMappingProfile>();
            cfg.AddProfile<DomainModelsMappingProfile>();
        });
        _mapper = config.CreateMapper();
    }

    [Test]
    public void RespondPatientDto_To_Patient_Map_ShouldBeValid()
    {
        // Arrange
        var medicalRecordObserver = Substitute.For<IMedicalRecordObserver>();
        var medicalRecordNotifier = Substitute.For<IMedicalRecordNotifier>();

        var respondPatientDto = new RespondPatientDto
        {
            Id = Guid.NewGuid(),
            FullName = "John Doe",
            BirthDate = DateOnly.FromDateTime(DateTime.Now),
            Address = new AddressDto
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                Zip = "12345"
            },
            PhoneNumber = "123-456-7890",
            Email = "johndoe@example.com",
            InsuranceProvider = "Insurance Co.",
            InsurancePolicyNumber = "1234567890"
        };

        // Act
        var patient = _mapper.Map<Patient>(respondPatientDto, opts => 
        {
            opts.Items["medicalRecordObserver"] = medicalRecordObserver;
            opts.Items["medicalRecordNotifier"] = medicalRecordNotifier;
        });

        // Assert
        patient.Should().NotBeNull();
        patient.Id.Should().Be(respondPatientDto.Id);
        patient.FullName.Should().Be(respondPatientDto.FullName);
        patient.BirthDate.Should().Be(respondPatientDto.BirthDate);
        patient.Address.Should().NotBeNull();
        patient.PhoneNumber.Should().Be(respondPatientDto.PhoneNumber);
        patient.Email.Should().Be(respondPatientDto.Email);
        patient.InsuranceProvider.Should().Be(respondPatientDto.InsuranceProvider);
        patient.InsurancePolicyNumber.Should().Be(respondPatientDto.InsurancePolicyNumber);
    }

    [Test]
    public void RespondMedicalRecordDto_To_MedicalRecord_Map_ShouldBeValid()
    {
        // Arrange
        var respondMedicalRecordDto = new RespondMedicalRecordDto
        {
            Id = Guid.NewGuid(),
            PatientId = Guid.NewGuid(),
            DoctorId = Guid.NewGuid(),
            Record = "Medical record details",
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        // Act
        var medicalRecord = _mapper.Map<MedicalRecord>(respondMedicalRecordDto);

        // Assert
        medicalRecord.Should().NotBeNull();
        medicalRecord.Id.Should().Be(respondMedicalRecordDto.Id);
        medicalRecord.PatientId.Should().Be(respondMedicalRecordDto.PatientId);
        medicalRecord.DoctorId.Should().Be(respondMedicalRecordDto.DoctorId);
        medicalRecord.Record.Should().Be(respondMedicalRecordDto.Record);
        medicalRecord.CreatedAt.Should().Be(respondMedicalRecordDto.CreatedAt);
        medicalRecord.UpdatedAt.Should().Be(respondMedicalRecordDto.UpdatedAt);
    }
}