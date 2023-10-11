﻿using MediatR;

namespace SmartGenealogy.Domain.Common;

public abstract class DomainEvent : INotification
{
    protected DomainEvent()
    {
        DateOccurred = DateTimeOffset.UtcNow;
    }

    public bool IsPublished { get; set; }

    public DateTimeOffset DateOccurred { get; protected set; }
}