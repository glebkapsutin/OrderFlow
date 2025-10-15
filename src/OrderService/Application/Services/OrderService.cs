using MassTransit;
using Contracts;

namespace OrderService.Application.Services
{
    public class OrderAppService
    {
        private readonly IOrderRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderAppService(IOrderRepository repository, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
        }
        public async Task<OrderCreated> CreateOrderAsync(Guid userId)
        {
            var order = new Order()
            {
                UserId = userId,
                Total = 100,
                Items = new List<OrderItem>
           {
               new OrderItem{ ProductId = Guid.NewGuid(),Quantity = 2, Price = 50}
           }
            };

            await _repository.AddOrderAsync(order);

            var orderCreated = new OrderCreated
            {
                OrderId = order.Id,
                UserId = order.UserId,
                Total = order.Total,
                Items = order.Items.Select(i => new OrderItemDto(i.ProductId, i.Quantity, i.Price)).ToList()
            };

            await _publishEndpoint.Publish(orderCreated);

            return orderCreated;
        }
    }
}