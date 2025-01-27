using MediatR;

namespace EComCore.Application.AddressOperations.Commands;

public class DeleteAddressCommand : IRequest
{
    public int Id { get; set; }
}