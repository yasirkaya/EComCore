using EComCore.Domain.DTOs.ProductToAttributeDTO;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands;

public class AddAttributesToProductCommand : IRequest
{
    public IEnumerable<CreateProductToAttributeDto> ProductAttributes { get; set; }
}