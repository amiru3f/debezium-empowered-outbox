namespace Domain.Events;

[Serializable]
public record OrderPaidEvent(Guid EventId, Guid OrderId) : Event(EventId);