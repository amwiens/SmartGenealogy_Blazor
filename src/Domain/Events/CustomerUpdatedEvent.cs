namespace SmartGenealogy.Domain.Events;

public class CustomerUpdatedEvent : DomainEvent
{
    public CustomerUpdatedEvent(Customer item)
    {
        Item = item;
    }

    public Customer Item { get; }
}