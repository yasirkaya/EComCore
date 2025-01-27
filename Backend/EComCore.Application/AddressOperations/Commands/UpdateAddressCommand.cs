using MediatR;

namespace EComCore.Application.AddressOperations.Commands;

public class UpdateAddressCommand : IRequest
{
    public string Name { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
}