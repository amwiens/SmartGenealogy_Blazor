namespace SmartGenealogy.Domain.Events;

public class CustomerCreatedEvent(Customer item) : DomainEvent
{
    public Customer Item { get; } = item;
}