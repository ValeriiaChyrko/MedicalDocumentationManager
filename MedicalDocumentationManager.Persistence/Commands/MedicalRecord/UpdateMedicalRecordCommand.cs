﻿using MedicalDocumentationManager.DTOs.RequestsDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

public sealed record UpdateMedicalRecordCommand(Guid Id, RequestMedicalRecordDto RequestMedicalRecordDto);