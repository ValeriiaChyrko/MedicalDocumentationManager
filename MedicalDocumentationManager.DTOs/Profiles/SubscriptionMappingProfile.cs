using AutoMapper;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.DTOs.Profiles;

public class SubscriptionMappingProfile : Profile
{
    public SubscriptionMappingProfile()
    {
        CreateMap<RequestSubscriptionDto, SubscriptionEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.PatientEntity, opt => opt.Ignore())
            .ForMember(dest => dest.MedicalRecordEntity, opt => opt.Ignore());

        CreateMap<SubscriptionEntity, RespondSubscriptionDto>();
    }
}