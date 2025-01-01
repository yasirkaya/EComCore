namespace EComCore.Domain.DTOs.PaymentDTO;

public class RefundRequest
{
    public string TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; }
}