using AutoMapper;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.DTOs.Profiles;

public class AddressMappingProfile : Profile
{
    public AddressMappingProfile()
    {
        CreateMap<RequestAddressDto, AddressEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Patients, opt => opt.Ignore())
            .ForMember(dest => dest.Doctors, opt => opt.Ignore());

        CreateMap<AddressEntity, RespondAddressDto>();
    }
}