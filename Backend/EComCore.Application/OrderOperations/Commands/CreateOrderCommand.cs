using MediatR;
using EComCore.Domain.DTOs.PaymentDTO;

namespace EComCore.Application.OrderOperations.Commands;

public class CreateOrderCommand : IRequest<int>
{
    public int UserId { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
    public PaymentRequest Payment { get; set; }
}