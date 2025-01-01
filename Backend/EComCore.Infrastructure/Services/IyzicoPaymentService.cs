using System.Threading.Tasks;
using EComCore.Domain.DTOs.PaymentDTO;

namespace EComCore.Infrastructure.Services;

public interface IPaymentService
{
    Task<PaymentResult> ProcessPayment(PaymentRequest request);
    Task<PaymentResult> RefundPayment(RefundRequest request);
}

public class IyzicoPaymentService : IPaymentService
{
    public async Task<PaymentResult> ProcessPayment(PaymentRequest request)
    {
        // Iyzico implementasyonu gelecek
        throw new NotImplementedException();
    }

    public async Task<PaymentResult> RefundPayment(RefundRequest request)
    {
        // Iyzico implementasyonu gelecek
        throw new NotImplementedException();
    }
}