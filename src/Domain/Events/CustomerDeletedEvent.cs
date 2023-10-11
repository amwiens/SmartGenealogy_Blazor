namespace SmartGenealogy.Domain.Events;

public class CustomerDeletedEvent(Customer item) : DomainEvent
{
    public Customer Item { get; } = item;
}