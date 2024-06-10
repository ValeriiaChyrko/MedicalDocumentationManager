using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Abstractions.Errors;

public static class DoctorErrors
{
    public static Result<DoctorEntity> NotFound(Guid doctorId)
    {
        return Result.Failure<DoctorEntity>(new Error("DoctorId.NotFound",
            $"The doctor with the id = '{doctorId}' was not found"));
    }
}