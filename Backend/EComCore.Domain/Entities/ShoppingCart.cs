namespace EComCore.Domain.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public string SessionId { get; set; }
    public int? MemberId { get; set; }
    public User? User { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
}