using MedicalDocumentationManager.DTOs.RequestsDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Patient;

public sealed record UpdatePatientCommand(Guid Id, RequestPatientDto RequestPatientDto);