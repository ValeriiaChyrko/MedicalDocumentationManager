using AutoMapper;
using MedicalDocumentationManager.Database.Contexts.Abstractions;
using MedicalDocumentationManager.Database.Entities;
using MedicalDocumentationManager.DTOs.RespondDTOs;

namespace MedicalDocumentationManager.Persistence.Commands.Subscription;

public sealed class UpdateSubscriptionCommandHandler
{
    private readonly IMedicalDocumentationManagerDbContext _context;
    private readonly IMapper _mapper;

    public UpdateSubscriptionCommandHandler(IMedicalDocumentationManagerDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<RespondSubscriptionDto> Handle(UpdateSubscriptionCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        
        var subscriptionEntity = _mapper.Map<SubscriptionEntity>(command.RequestSubscriptionDto);
        subscriptionEntity.Id = command.Id;

        _context.SubscriptionEntities.Update(subscriptionEntity);

        return Task.FromResult(_mapper.Map<RespondSubscriptionDto>(subscriptionEntity));
    }
}