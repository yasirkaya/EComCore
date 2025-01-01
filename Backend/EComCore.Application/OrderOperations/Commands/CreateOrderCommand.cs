using MediatR;
using EComCore.Domain.DTOs.PaymentDTO;

namespace EComCore.Application.OrderOperations.Commands;

public class CreateOrderCommand : IRequest<int>
{
    public int UserId { get; set; }
    public int ShippingAddressId { get; set; }
    public int BillingAddressId { get; set; }
    public PaymentRequest Payment { get; set; }
}