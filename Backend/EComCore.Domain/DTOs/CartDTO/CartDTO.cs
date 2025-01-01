namespace EComCore.Domain.DTOs.CartDTO;

public class CartDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<CartItemDTO> Items { get; set; }
    public decimal TotalAmount { get; set; }
}

