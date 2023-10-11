namespace SmartGenealogy.Domain.Events;

public class DeletedEvent<T>(T entity) : DomainEvent where T : IEntity
{
    public T Entity { get; } = entity;
}