using MedicalDocumentationManager.Domain.Implementation;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Presentation;

public static class Program
{
    static void Main()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        IConfiguration configuration = builder.Build();

        var factoryProvider = new LoggerFactoryProvider(configuration);
        var loggerFactory = factoryProvider.GetFactory();
        var logger = loggerFactory.CreateLogger();
        
        logger.Log("This is a log message.");
    }
}
