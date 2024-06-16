using MedicalDocumentationManager.Application.Abstractions.Contracts;
using MedicalDocumentationManager.Application.Implementations;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Contexts.Implementations;
using MedicalDocumentationManager.Domain.Abstraction.Contracts;
using MedicalDocumentationManager.Domain.Implementation;
using MedicalDocumentationManager.DTOs.Profiles;
using MedicalDocumentationManager.DTOs.RequestsDTOs;
using MedicalDocumentationManager.DTOs.RespondDTOs;
using MedicalDocumentationManager.DTOs.SharedDTOs;
using MedicalDocumentationManager.Persistence.Commands.Address;
using MedicalDocumentationManager.Persistence.Commands.Doctor;
using MedicalDocumentationManager.Persistence.Commands.MedicalRecord;
using MedicalDocumentationManager.Persistence.Commands.Patient;
using MedicalDocumentationManager.Persistence.Commands.Subscription;
using MedicalDocumentationManager.Persistence.Queries.Address;
using MedicalDocumentationManager.Persistence.Queries.Doctor;
using MedicalDocumentationManager.Persistence.Queries.Patient;
using MedicalDocumentationManager.Persistence.Queries.Subscription;
using Microsoft.EntityFrameworkCore.Storage;

namespace MedicalDocumentationManager.Application.Tests;

[TestFixture]
public class MedicalRecordServiceObserverTests
{
    private MedicalRecordService _medicalRecordService = null!;
    private SubscriptionService _subscriptionService = null!;
    private PatientService _patientService = null!;
    private IMedicalDocumentationManagerDbContextFactory _factory = null!;
    private IMedicalDocumentationManagerDbContext _context = null!;
    private ServiceProvider _serviceProvider = null!;
    private IMediator _mediator = null!;
    private IMapper _mapper = null!;
    private IDatabaseTransactionManager _transactionManager = null!;

    [SetUp]
public void SetUp()
{
    _factory = new MedicalDocumentationManagerInMemoryDbContextFactory();
    _context = _factory.CreateDbContext(Array.Empty<string>());

    var services = new ServiceCollection();

    services.AddMediatR(config => { config.RegisterServicesFromAssembly(typeof(MedicalRecordService).Assembly); });
    services.AddTransient<IRequestHandler<CreateAddressCommand, AddressDto>, CreateAddressCommandHandler>();
    services.AddTransient<IRequestHandler<CreateDoctorCommand, RespondDoctorDto>, CreateDoctorCommandHandler>();
    services.AddTransient<IRequestHandler<UpdateDoctorCommand, RespondDoctorDto>, UpdateDoctorCommandHandler>();
    services.AddTransient<IRequestHandler<DeleteDoctorCommand>, DeleteDoctorCommandHandler>();
    services.AddTransient<IRequestHandler<CreateMedicalRecordCommand, RespondMedicalRecordDto>, CreateMedicalRecordCommandHandler>();
    services.AddTransient<IRequestHandler<UpdateMedicalRecordCommand, RespondMedicalRecordDto>, UpdateMedicalRecordCommandHandler>();
    services.AddTransient<IRequestHandler<DeleteMedicalRecordCommand>, DeleteMedicalRecordCommandHandler>();
    services.AddTransient<IRequestHandler<CreatePatientCommand, RespondPatientDto>, CreatePatientCommandHandler>();
    services.AddTransient<IRequestHandler<CreateSubscriptionCommand, SubscriptionDto>, CreateSubscriptionCommandHandler>();

    services.AddTransient<IRequestHandler<GetAllDoctorsQuery, IEnumerable<RespondDoctorDto>>, GetAllDoctorsQueryHandler>();
    services.AddTransient<IRequestHandler<GetDoctorByIdQuery, RespondDoctorDto?>, GetDoctorByIdQueryHandler>();
    services.AddTransient<IRequestHandler<GetAddressIfExistsQuery, AddressDto?>, GetAddressIfExistsQueryHandler>();
    services.AddTransient<IRequestHandler<GetAddressByDoctorIdQuery, AddressDto?>, GetAddressByDoctorIdQueryHandler>();
    services.AddTransient<IRequestHandler<GetAllPatientsQuery, IEnumerable<RespondPatientDto>>, GetAllPatientsQueryHandler>();
    services.AddTransient<IRequestHandler<GetPatientByIdQuery, RespondPatientDto?>, GetPatientByIdQueryHandler>();
    services.AddTransient<IRequestHandler<GetAllSubscriptionsByMedicalRecordIdQuery, IEnumerable<SubscriptionDto>>, GetAllSubscriptionsByMedicalRecordIdQueryHandler>();

    services.AddScoped<IMessageHandler, ConsoleMessageHandler>();
    services.AddScoped<IMedicalRecordNotifier, MedicalRecordNotifier>();
    services.AddScoped<IMedicalRecordObserver, MedicalRecordObserver>();
    services.AddScoped<IDatabaseTransactionManager, DatabaseTransactionManager>();
    services.AddScoped<IMedicalDocumentationManagerDbContext, MedicalDocumentationManagerDbContext>();
    services.AddDbContext<MedicalDocumentationManagerDbContext>(
        options => { options.UseInMemoryDatabase("MedicalDocumentationManagerDb"); });

    services.AddSingleton<ILogger, ConsoleLogger>();
    services.AddSingleton<MedicalRecordService>();
    services.AddSingleton<PatientService>();
    services.AddSingleton<SubscriptionService>();

    _serviceProvider = services.BuildServiceProvider();

    var mapperConfig = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new MedicalRecordMappingProfile());
        cfg.AddProfile(new PatientMappingProfile());
        cfg.AddProfile(new DoctorMappingProfile());
        cfg.AddProfile(new AddressMappingProfile());
        cfg.AddProfile(new SubscriptionMappingProfile());
    });

    services.AddSingleton(mapperConfig.CreateMapper());

    _mapper = mapperConfig.CreateMapper();
    _serviceProvider = services.BuildServiceProvider();
    _context = _serviceProvider.GetService<IMedicalDocumentationManagerDbContext>()!;
    _patientService = _serviceProvider.GetService<PatientService>()!;
    _medicalRecordService = _serviceProvider.GetService<MedicalRecordService>()!;
    _subscriptionService = _serviceProvider.GetService<SubscriptionService>()!;
    _mediator = _serviceProvider.GetService<IMediator>()!;
    _transactionManager = _serviceProvider.GetService<IDatabaseTransactionManager>()!;
}

    [Test]
    public async Task UpdateMedicalRecordAsync_ReturnsRespondMedicalRecordDto_WhenCalled()
    {
        // Arrange
        var requestPatientDto = new RequestPatientDto
        {
            FullName = "Test Patient",
            PhoneNumber = "123-456-7890",
            Email = "test@example.com",
            InsurancePolicyNumber = "222785605",
            InsuranceProvider = "Health Net",
            Address = new AddressDto
            {
                Street = "123 Main St",
                City = "Anytown",
                State = "CA",
                Zip = "12345"
            }
        };
        var respondPatientDto =  await _patientService.CreatePatientAsync(requestPatientDto, CancellationToken.None);
        
        var requestMedicalRecordDto = new RequestMedicalRecordDto
        {
            PatientId = respondPatientDto.Id,
            DoctorId = Guid.NewGuid(),
            Record = "Test Record",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        var respondMedicalRecordDto =  await _medicalRecordService.CreateMedicalRecordAsync(requestMedicalRecordDto, CancellationToken.None);
        
        var createCommand = new CreateSubscriptionCommand(new SubscriptionDto
        {
            SubscriptionType = "Observer",
            PatientId = respondPatientDto.Id,
            MedicalRecordId = respondMedicalRecordDto.Id
        });
        
        var createdSubscription = await new CreateSubscriptionCommandHandler(_context, _mapper).Handle(createCommand, CancellationToken.None);
        await _context.SaveChangesAsync();
        _context.DetachEntitiesInChangeTracker();
        
        // Act
        var result = await _medicalRecordService.UpdateMedicalRecordAsync(respondMedicalRecordDto.Id, requestMedicalRecordDto);

        // Assert
        await _transactionManager
            .Received(1)
            .CommitAsync(Arg.Any<IDbContextTransaction>(), Arg.Any<CancellationToken>());
    }
}