using EComCore.Domain.DTOs.CartDTO;
using MediatR;

namespace EComCore.Application.CartOperations.Queries;

public class GetCartQuery : IRequest<CartDTO>
{
    public int UserId { get; set; }
}