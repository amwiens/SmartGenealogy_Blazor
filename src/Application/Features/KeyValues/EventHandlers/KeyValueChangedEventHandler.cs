﻿namespace SmartGenealogy.Application.Features.KeyValues.EventHandlers;

public class KeyValueChangedEventHandler : INotificationHandler<UpdatedEvent<KeyValue>>
{
    private readonly ILogger<KeyValueChangedEventHandler> _logger;
    private readonly IPicklistService _picklistService;

    public KeyValueChangedEventHandler(
        IPicklistService picklistService,
        ILogger<KeyValueChangedEventHandler> logger)
    {
        _picklistService = picklistService;
        _logger = logger;
    }

    public async Task Handle(UpdatedEvent<KeyValue> notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("KeyValue Changed {DomainEvent},{@Entity}", nameof(notification), notification.Entity);
        await _picklistService.Refresh();
    }
}