namespace SmartGenealogy.Domain.Events;

public class CreatedEvent<T>(T entity) : DomainEvent where T : IEntity
{
    public T Entity { get; } = entity;
}