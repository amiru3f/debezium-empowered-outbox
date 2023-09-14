using Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<ProducerDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString(nameof(ProducerDbContext));
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.MapGet("/create-order", async (ProducerDbContext context) =>
{
    Order order = new();
    order.ChangeStatusToPaid();

    context.Order.Add(order);
    await context.SaveChangesAsync();

    return "Order Created, Please visit localhost:8080 to check the event";
});



await app.RunAsync();