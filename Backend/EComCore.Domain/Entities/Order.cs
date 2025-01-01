using EComCore.Domain.Enums;

namespace EComCore.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
    public int ShippingAddressId { get; set; }
    public int BillingAddressId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public List<OrderItem> Items { get; set; }
    public User User { get; set; }
    public Address ShippingAddress { get; set; }
    public Address BillingAddress { get; set; }
}