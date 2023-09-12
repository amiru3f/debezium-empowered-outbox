namespace Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table(name: "outbox-table")]
public class OutboxMessage
{
    [Key]
    public Guid Id { set; get; }
    public required string Payload { set; get; }

    [Column("Type")]
    public required string EventType { set; get; }
}