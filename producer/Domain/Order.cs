using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Events;

namespace Domain;

public class Order : BaseEntity
{
    public Order()
    {
        Id = Guid.NewGuid();
    }
    
    [Key]
    public Guid Id { set; get; }

    public OrderStatus Status { set; get; }
    public void ChangeStatusToPaid()
    {
        Status = OrderStatus.Paid;
        DomainEvents.Add(new OrderPaidEvent(Guid.NewGuid(), Id));
    }
}

public enum OrderStatus
{
    New,
    Paid,
    Delivered
}

