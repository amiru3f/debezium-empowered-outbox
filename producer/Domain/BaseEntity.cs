namespace Domain;

using System.ComponentModel.DataAnnotations.Schema;
using Domain.Events;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        DomainEvents = new();
    }
    
    [NotMapped]
    public List<Event> DomainEvents { set; get; }
}