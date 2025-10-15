public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public decimal Total {  get; set; }

    public IEnumerable<OrderItem> Items { get; set; } = new List<OrderItem>();
}
