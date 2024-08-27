namespace EComCore.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int? ProductId { get; set; }
    public Product Product { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductSku { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}