namespace Contracts;

public record OrderItemDto(Guid ProductId, int Quantity, decimal Price);
public record OrderCreated
{
    public Guid OrderId { get; init; }
    public Guid UserId { get; init; }
    public decimal Total { get; init; }
    public IEnumerable<OrderItemDto> Items { get; init; } = Array.Empty<OrderItemDto>();
    public Guid CorrelationId { get; init; } = Guid.NewGuid();
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}
 