using MedicalDocumentationManager.Persistence.Abstractions.Errors;

namespace MedicalDocumentationManager.Persistence.Abstractions.Exceptions;

public class DatabaseErrorException : Exception
{
    public List<DataBaseError> Errors { get; }

    public DatabaseErrorException(string message, List<DataBaseError> errors, Exception? innerException) : base(message,
        innerException)
    {
        Errors = errors;
    }
}