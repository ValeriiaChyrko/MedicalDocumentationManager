﻿using MediatR;

namespace MedicalDocumentationManager.Persistence.Commands.MedicalRecord;

public sealed record DeleteMedicalRecordCommand(Guid Id) : IRequest;