﻿using MedicalDocumentationManager.DTOs.RequestsDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Address;

public sealed record CreateAddressCommand(RequestAddressDto RequestAddressDto);