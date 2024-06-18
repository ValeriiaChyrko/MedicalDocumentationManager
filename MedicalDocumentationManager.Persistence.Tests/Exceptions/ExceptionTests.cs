using MedicalDocumentationManager.Persistence.Abstractions.Errors;
using MedicalDocumentationManager.Persistence.Abstractions.Exceptions;

namespace MedicalDocumentationManager.Persistence.Tests.Exceptions
{
    [TestFixture]
    public class ExceptionTests
    {
        [Test]
        public void DatabaseErrorException_Constructor_SetsMessageAndInnerExceptionAndErrors()
        {
            // Arrange
            var errorMessage = "Database error occurred.";
            var innerException = new Exception("Inner exception message");
            var errors = new List<DataBaseError>
            {
                new DataBaseError { Table = "DB001", Message = "Database connection failed." }
            };

            // Act
            var exception = new DatabaseErrorException(errorMessage, errors, innerException);

            // Assert
            exception.Message.Should().Be(errorMessage);
            exception.InnerException.Should().Be(innerException);
            exception.Errors.Should().BeEquivalentTo(errors);
        }

        [Test]
        public void DatabaseException_Constructor_SetsMessageAndInnerException()
        {
            // Arrange
            var errorMessage = "General database exception occurred.";
            var innerException = new Exception("Inner exception message");

            // Act
            var exception = new DatabaseException(errorMessage, innerException);

            // Assert
            exception.Message.Should().Be(errorMessage);
            exception.InnerException.Should().Be(innerException);
        }

        [Test]
        public void RequestValidationException_Constructor_SetsMessageAndInnerExceptionAndErrors()
        {
            // Arrange
            var errorMessage = "Request validation failed.";
            var innerException = new Exception("Inner exception message");
            var errors = new List<ValidationError>
            {
                new ValidationError { Field = "Name", Message = "Name is required." }
            };

            // Act
            var exception = new RequestValidationException(errorMessage, errors, innerException);

            // Assert
            exception.Message.Should().Be(errorMessage);
            exception.InnerException.Should().Be(innerException);
            exception.Errors.Should().BeEquivalentTo(errors);
        }
    }
}