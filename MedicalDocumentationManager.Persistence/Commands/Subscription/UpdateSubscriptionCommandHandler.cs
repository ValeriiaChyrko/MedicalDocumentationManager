using AutoMapper;
using MediatR;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.SharedDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, SubscriptionDto>
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public UpdateSubscriptionCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<SubscriptionDto> Handle(UpdateSubscriptionCommand command,
        CancellationToken cancellationToken = default)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var subscriptionEntity = _mapper.Map<SubscriptionEntity>(command.SubscriptionDto);
        subscriptionEntity.Id = command.Id;

        _context.SubscriptionEntities.Update(subscriptionEntity);

        return Task.FromResult(_mapper.Map<SubscriptionDto>(subscriptionEntity));
    }
}