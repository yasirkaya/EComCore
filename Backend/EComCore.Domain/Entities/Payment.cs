namespace EComCore.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public string TransactionId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public string PaymentMethod { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public string? FailureReason { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}