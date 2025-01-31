using EComCore.Domain.DTOs.PaymentDTO;

namespace EComCore.Domain.Services.Commands
{
    public interface IPaymentCommandService
    {
        Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto dto);
    }
}