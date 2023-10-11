namespace SmartGenealogy.Domain.Events;

public class UpdatedEvent<T>(T entity) : DomainEvent where T : IEntity
{
    public T Entity { get; } = entity;
}