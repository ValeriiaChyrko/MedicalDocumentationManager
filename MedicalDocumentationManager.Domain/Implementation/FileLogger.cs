using MedicalDocumentationManager.Domain.Abstraction;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;

namespace MedicalDocumentationManager.Domain.Implementation;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(string message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message), "The message cannot be null.");

        File.AppendAllText(_filePath, message + Environment.NewLine);
    }
}