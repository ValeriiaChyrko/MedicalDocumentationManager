﻿namespace MedicalDocumentationManager.Persistence.Queries.Subscription;

public record GetAllSubscriptionsByMedicalRecordIdQuery(Guid MedicalRecordId);