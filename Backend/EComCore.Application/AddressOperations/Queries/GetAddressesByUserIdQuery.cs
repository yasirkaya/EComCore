using EComCore.Domain.DTOs.AddressDTO;
using MediatR;

namespace EComCore.Application.AddressOperations.Queries;

public class GetAddressesByUserIdQuery : IRequest<IEnumerable<AddressDto>>
{
    public int UserId { get; set; }
}