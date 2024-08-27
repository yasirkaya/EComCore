namespace EComCore.Domain.Entities;

public class Shipment
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public string TrackingNumber { get; set; }
    public string Carrier { get; set; }
    public string Status { get; set; }
    public DateTime? EstimatedDeliveryDate { get; set; }
    public DateTime? ShippedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}