using AutoMapper;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.DTOs.Profiles;

public class MedicalRecordMappingProfile : Profile
{
    public MedicalRecordMappingProfile()
    {
        CreateMap<RequestMedicalRecordDto, MedicalRecordEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.PatientEntity, opt => opt.Ignore())
            .ForMember(dest => dest.DoctorEntity, opt => opt.Ignore())
            .ForMember(dest => dest.Subscriptions, opt => opt.Ignore());

        CreateMap<MedicalRecordEntity, RespondMedicalRecordDto>();
    }
}