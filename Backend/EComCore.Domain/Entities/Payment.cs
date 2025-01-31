using EComCore.Domain.Enums;

namespace EComCore.Domain.Entities;

public class Payment
{
    public int Id { get; set; }
    public string? TransactionId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    public string? FailureReason { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public void UpdateStatus(PaymentStatus newStatus, string? failureReason = null)
    {
        Status = newStatus;
        FailureReason = failureReason;
        UpdatedAt = DateTime.UtcNow;
    }
}