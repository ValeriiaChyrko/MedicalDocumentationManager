﻿using MedicalDocumentationManager.Application.Abstractions.Contracts;

namespace MedicalDocumentationManager.Application.Features.MedicalRecords.Handlers;

public sealed record UpdateMedicalRecordCommand(Guid Id, Guid PatientId, Guid DoctorId,
    string Record, DateTime CreatedAt, DateTime UpdatedAt) : ICommand;