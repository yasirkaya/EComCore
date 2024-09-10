using EComCore.Domain.DTOs.ProductToAttributeDTO;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands.Queries;

public class GetProductToAttributeByIdQuery : IRequest<ProductToAttributeDto>
{
    public int Id { get; set; }
}