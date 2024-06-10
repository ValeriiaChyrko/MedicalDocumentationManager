using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Abstractions.Errors;

public static class PatientErrors
{
    public static Result<PatientEntity> NotFound(Guid patientId)
    {
        return Result.Failure<PatientEntity>(new Error("PatientId.NotFound",
            $"The patient with the id = '{patientId}' was not found"));
    }
}