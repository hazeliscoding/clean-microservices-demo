namespace EventBus.Messages.Events;

public class BaseIntegrationEvent
{
    // Correlation ID
    public Guid Id { get; private set; }
    public DateTime CreationDate { get; private set; }

    public BaseIntegrationEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }

    public BaseIntegrationEvent(Guid id, DateTime creationDate)
    {
        Id = id;
        CreationDate = creationDate;
    }
}