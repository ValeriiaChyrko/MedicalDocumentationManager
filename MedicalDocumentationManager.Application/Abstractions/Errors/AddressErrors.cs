using MedicalDocumentationManager.Database.Entities;

namespace MedicalDocumentationManager.Application.Abstractions.Errors;

public static class AddressErrors
{
    public static Result<AddressEntity> NotFound(long addressId)
    {
        return Result.Failure<AddressEntity>(new Error("AddressId.NotFound",
            $"The address with the id = '{addressId}' was not found"));
    }
}