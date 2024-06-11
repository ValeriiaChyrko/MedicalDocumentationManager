﻿using MedicalDocumentationManager.DTOs.RequestsDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed record UpdateSubscriptionCommand(long Id, RequestSubscriptionDto RequestSubscriptionDto);