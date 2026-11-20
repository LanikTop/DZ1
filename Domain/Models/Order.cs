namespace Domain.Models;

public record Order
{
    public long ClientId { get; set; }
    public long Id { get; set; }
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
