using EComCore.Domain.DTOs.AddressDTO;
using MediatR;

namespace EComCore.Application.AddressOperations.Queries;

public class GetAddressesQuery : IRequest<IEnumerable<AddressDto>>
{
}