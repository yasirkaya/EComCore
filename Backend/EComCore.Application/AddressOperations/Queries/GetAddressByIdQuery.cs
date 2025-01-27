using EComCore.Domain.DTOs.AddressDTO;
using MediatR;

namespace EComCore.Application.AddressOperations.Queries;

public class GetAddressByIdQuery : IRequest<AddressDto>
{
    public int Id { get; set; }
}