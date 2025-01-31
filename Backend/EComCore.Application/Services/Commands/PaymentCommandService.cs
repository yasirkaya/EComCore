using EComCore.Domain.DTOs.PaymentDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class PaymentCommandService : IPaymentCommandService
{
    private readonly IPaymentRepository _paymentRepository;
    public PaymentCommandService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<PaymentDto> CreatePaymentAsync(CreatePaymentDto paymentDto)
    {

        var payment = new Payment
        {
            TransactionId = paymentDto.TransactionId,
            OrderId = paymentDto.OrderId,
            PaymentMethod = paymentDto.PaymentMethod,
            Amount = paymentDto.Amount,
            Status = paymentDto.Status,
            FailureReason = paymentDto.FailureReason,
            CreatedAt = DateTime.UtcNow
        };

        await _paymentRepository.AddAsync(payment);

        return await Task.FromResult(new PaymentDto
        {
            Id = paymentDto.Id,
            TransactionId = paymentDto.TransactionId,
            OrderId = paymentDto.OrderId,
            PaymentMethod = paymentDto.PaymentMethod,
            Amount = paymentDto.Amount,
            Status = paymentDto.Status,
            FailureReason = paymentDto.FailureReason
        });
    }
}