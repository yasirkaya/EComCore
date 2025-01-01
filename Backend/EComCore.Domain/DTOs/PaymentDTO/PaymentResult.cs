namespace EComCore.Domain.DTOs.PaymentDTO;

public class PaymentResult
{
    public bool Success { get; set; }
    public string TransactionId { get; set; }
    public string ErrorMessage { get; set; }
}