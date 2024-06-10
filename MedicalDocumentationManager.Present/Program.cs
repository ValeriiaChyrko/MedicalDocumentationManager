using MedicalDocumentationManager.Application.Features.Addresses.Queries;
using MedicalDocumentationManager.Database.Contexts;
using MedicalDocumentationManager.Domain.Implementation;
using Microsoft.Extensions.Configuration;

namespace MedicalDocumentationManager.Presentation;

public static class Program
{
    private static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);
        IConfiguration configuration = builder.Build();

        var factoryProvider = new LoggerFactoryProvider(configuration);
        var loggerFactory = factoryProvider.GetFactory();
        var logger = loggerFactory.CreateLogger();

        logger.Log("This is a log message.");

        var contextFactory = new MedicalDocumentationManagerDbContextFactory();
        var dbContext = contextFactory.CreateDbContext(args);


        var queryHandler = new GetAddressByIdQueryHandler(dbContext);
        var query = new GetAddressByIdQuery(5);

        var resultQ = await queryHandler.Handle(query, CancellationToken.None);

        if (resultQ.IsSuccess)
        {
            var address = resultQ.Value;
            logger.Log($"Address: {address.Id}, {address.Street}, {address.City}, {address.State}, {address.Zip}");
        }
        else
        {
            logger.Log($"Failed to retrieve addresses: {resultQ.Error.Code} -> {resultQ.Error.Description}");
        }
    }
}