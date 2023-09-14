using Domain;
using Microsoft.EntityFrameworkCore;
#nullable disable

public class ProducerDbContext : DbContext
{
    public ProducerDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Order> Order { set; get; }
    public DbSet<OutboxMessage> OutBox { set; get; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entityEntries = ChangeTracker.Entries<BaseEntity>();
        var events = new List<OutboxMessage>();

        foreach (var entityEntry in entityEntries)
        {
            events.AddRange(entityEntry.Entity.DomainEvents.Select(de => new OutboxMessage()
            {
                EventType = de.GetType().ToString(),
                Payload = System.Text.Json.JsonSerializer.Serialize(de),
                Id = Guid.NewGuid()
            }));
        }

        OutBox.AddRange(events);
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OutboxMessage>();

        modelBuilder.Entity<Order>()
            .Property(o => o.Id)
            .ValueGeneratedOnAdd();
    }
}