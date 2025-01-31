using EComCore.Domain.Enums;

namespace EComCore.Domain.DTOs.PaymentDTO;

public class CreatePaymentDto
{
    public int Id { get; set; }
    public string? TransactionId { get; set; }
    public int OrderId { get; set; }
    public PaymentMethodType PaymentMethod { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    public string? FailureReason { get; set; }
}