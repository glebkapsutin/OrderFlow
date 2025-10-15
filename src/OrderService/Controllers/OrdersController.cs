using Microsoft.AspNetCore.Mvc;
using OrderService.Application.Services;
[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderAppService _orderService;

    public OrdersController(OrderAppService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromQuery] Guid userId)
    {
        var orderCreated = await _orderService.CreateOrderAsync(userId);
        return Ok(orderCreated);
    }
}
