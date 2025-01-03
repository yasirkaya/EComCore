using EComCore.Domain.DTOs.CartDTO;
using MediatR;

namespace EComCore.Application.CartOperations.Queries;

public class GetCartQuery : IRequest<CartDto>
{
    public int UserId { get; set; }
}