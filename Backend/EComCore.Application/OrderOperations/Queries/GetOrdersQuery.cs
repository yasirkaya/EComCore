using MediatR;
using EComCore.Domain.DTOs.OrderDTO;

namespace EComCore.Application.OrderOperations.Queries;

public class GetOrdersQuery : IRequest<List<OrderDTO>>
{
    public int UserId { get; set; }
}