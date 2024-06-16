using AutoMapper;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.DTOs.Profiles;

public class DomainModelsMappingProfile : Profile
{
    public DomainModelsMappingProfile()
    {
        CreateMap<RespondPatientDto, Patient>()
            .ConstructUsing((src, ctx) => Patient.Create(
                src.Id, 
                src.FullName, 
                src.BirthDate, 
                ctx.Mapper.Map<Address>(src.Address), 
                src.PhoneNumber, 
                src.Email, 
                src.InsuranceProvider, 
                src.InsurancePolicyNumber, 
                (IMedicalRecordObserver)ctx.Items["medicalRecordObserver"], 
                (IMedicalRecordNotifier)ctx.Items["medicalRecordNotifier"]));

        CreateMap<RespondMedicalRecordDto, MedicalRecord>()
            .ConstructUsing((src) => MedicalRecord.Create(
                src.Id,
                src.PatientId,
                src.DoctorId,
                src.Record,
                src.CreatedAt,
                src.UpdatedAt));
    }
}