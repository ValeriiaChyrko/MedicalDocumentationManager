﻿using MedicalDocumentationManager.DTOs.RequestsDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Patient;

public sealed record CreatePatientCommand(RequestPatientDto RequestPatientDto);