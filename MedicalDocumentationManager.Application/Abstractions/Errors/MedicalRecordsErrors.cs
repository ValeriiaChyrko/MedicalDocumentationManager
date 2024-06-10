using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Abstractions.Errors;

public static class MedicalRecordsErrors
{
    public static Result<MedicalRecordEntity> NotFound(Guid recordId)
    {
        return Result.Failure<MedicalRecordEntity>(new Error("RecordId.NotFound",
            $"The record with the id = '{recordId}' was not found"));
    }
}