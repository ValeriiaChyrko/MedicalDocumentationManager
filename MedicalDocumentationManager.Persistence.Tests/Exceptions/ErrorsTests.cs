using MedicalDocumentationManager.Persistence.Abstractions.Errors;

namespace MedicalDocumentationManager.Persistence.Tests.Exceptions;

[TestFixture]
public class ErrorsTests
{
    [Test]
    public void DataBaseError_Initialization_SetsPropertiesCorrectly()
    {
        // Arrange
        var tableName = "Patients";
        var errorMessage = "Database connection failed.";

        // Act
        var error = new DataBaseError
        {
            Table = tableName,
            Message = errorMessage
        };

        // Assert
        error.Table.Should().Be(tableName);
        error.Message.Should().Be(errorMessage);
    }

    [Test]
    public void ValidationError_Initialization_SetsPropertiesCorrectly()
    {
        // Arrange
        var entityName = "Patient";
        var fieldName = "Name";
        var validationMessage = "Name is required.";

        // Act
        var error = new ValidationError
        {
            Entity = entityName,
            Field = fieldName,
            Message = validationMessage
        };

        // Assert
        error.Entity.Should().Be(entityName);
        error.Field.Should().Be(fieldName);
        error.Message.Should().Be(validationMessage);
    }
}