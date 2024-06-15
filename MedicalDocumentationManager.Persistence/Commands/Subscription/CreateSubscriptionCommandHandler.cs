using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, SubscriptionDto>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public CreateSubscriptionCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<SubscriptionDto> Handle(CreateSubscriptionCommand command,
        CancellationToken cancellationToken)
    {
        if (command is null) throw new ArgumentNullException(nameof(command));

        var subscriptionEntity = _mapper.Map<SubscriptionEntity>(command.SubscriptionDto);
        var addedEntity = await _context.SubscriptionEntities.AddAsync(subscriptionEntity, cancellationToken);

        return _mapper.Map<SubscriptionDto>(addedEntity.Entity);
    }
}