namespace EComCore.Domain.DTOs.PaymentDTO;

public class PaymentRequest
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public string Cvc { get; set; }
    public string CardHolderName { get; set; }
}