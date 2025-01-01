namespace EComCore.Domain.DTOs.OrderDTO;

public class OrderDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public decimal TotalAmount { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
    public string PaymentStatus { get; set; }
    public List<OrderItemDTO> Items { get; set; }
}

public class OrderItemDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
}