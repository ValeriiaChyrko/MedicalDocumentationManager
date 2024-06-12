using AutoMapper;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.DTOs.Profiles;

public class DoctorMappingProfile : Profile
{
    public DoctorMappingProfile()
    {
        CreateMap<RequestDoctorDto, DoctorEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.AddressEntity, opt => opt.Ignore())
            .ForMember(dest => dest.MedicalRecords, opt => opt.Ignore());

        CreateMap<DoctorEntity, RespondDoctorDto>();
    }
}