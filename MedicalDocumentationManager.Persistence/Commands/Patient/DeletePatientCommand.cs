﻿using MediatR;

namespace MedicalDocumentationManager.Persistence.Commands.Patient;

public sealed record DeletePatientCommand(Guid Id) : IRequest;