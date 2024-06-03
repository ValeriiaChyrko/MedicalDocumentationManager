using MedicalDocumentationManager.Domain.Abstraction;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Domain.Implementation;

public class LoggerFactoryProvider
{
    private readonly IConfiguration _config;

    public LoggerFactoryProvider(IConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public ILoggerFactory GetFactory()
    {
        var loggerType = _config["Logger:Type"];
        var filePath = _config["Logger:FilePath"];

        return loggerType switch
        {
            "ConsoleLogger" => new ConsoleLoggerFactory(),
            "FileLogger" => new FileLoggerFactory(filePath),
            _ => throw new ArgumentException("Invalid logger type", nameof(loggerType))
        };
    }
}