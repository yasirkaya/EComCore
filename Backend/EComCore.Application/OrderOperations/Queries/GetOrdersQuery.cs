using System.Collections.Generic;
using MediatR;
using EComCore.Domain.DTOs.OrderDTO;

namespace EComCore.Application.OrderOperations.Queries;

public class GetOrdersQuery : IRequest<List<OrderDto>>
{
    public int UserId { get; set; }
}