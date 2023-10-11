namespace SmartGenealogy.Domain.Events;

public class CustomerUpdatedEvent(Customer item) : DomainEvent
{
    public Customer Item { get; } = item;
}