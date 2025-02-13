﻿using AutoMapper;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.DTOs.Profiles;

public class AddressMappingProfile : Profile
{
    public AddressMappingProfile()
    {
        CreateMap<AddressDto, AddressEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Patients, opt => opt.Ignore())
            .ForMember(dest => dest.Doctors, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<Address, AddressDto>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
    }
}