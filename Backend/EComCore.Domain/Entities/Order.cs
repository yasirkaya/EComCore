namespace EComCore.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public string SessionId { get; set; }
    public string Email { get; set; }
    public decimal TotalAmount { get; set; }
    public int ShippingAddressId { get; set; }
    public Address ShippingAddress { get; set; }
    public int BillingAddressId { get; set; }
    public Address BillingAddress { get; set; }
    public string Status { get; set; }
    public string PaymentStatus { get; set; }
    public string? FailureReason { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Shipment Shipment { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}