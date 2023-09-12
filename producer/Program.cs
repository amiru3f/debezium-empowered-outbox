using Domain;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDbContext<ProducerDbContext>();

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