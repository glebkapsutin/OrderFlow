using MassTransit;
using Contracts;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public Task Consume(ConsumeContext<OrderCreated> context)
    {
        var order = context.Message;
        Console.WriteLine($"Получено событие OrderCreated: {order.OrderId}, Total: {order.Total}");
        return Task.CompletedTask;
    }
}
