using MedicalDocumentationManager.Persistence.Abstractions.Errors;

namespace MedicalDocumentationManager.Persistence.Abstractions.Exceptions;

public class RequestValidationException : Exception
{
    public List<ValidationError> Errors { get; }

    public RequestValidationException(string message, List<ValidationError> errors, Exception innerException) : base(
        message, innerException)
    {
        Errors = errors;
    }
}