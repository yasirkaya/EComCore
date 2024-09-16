namespace EComCore.Domain.Entities;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int? BillingAddressId { get; set; }
    public Address? BillingAddress { get; set; }
    public int? ShippingAddressId { get; set; }
    public Address? ShippingAddress { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public ShoppingCart? ShoppingCart { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}