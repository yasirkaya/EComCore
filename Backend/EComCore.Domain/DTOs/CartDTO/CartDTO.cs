namespace EComCore.Domain.DTOs.CartDTO;

public class CartDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<CartItemDTO> Items { get; set; }
    public decimal TotalAmount { get; set; }
}

public class CartItemDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
}