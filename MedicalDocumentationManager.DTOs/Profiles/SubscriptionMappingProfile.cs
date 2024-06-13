using AutoMapper;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.Profiles;

public class SubscriptionMappingProfile : Profile
{
    public SubscriptionMappingProfile()
    {
        CreateMap<SubscriptionDto, SubscriptionEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.PatientEntity, opt => opt.Ignore())
            .ForMember(dest => dest.MedicalRecordEntity, opt => opt.Ignore())
            .ReverseMap();
    }
}