using EComCore.Domain.DTOs.ProductToAttributeDTO;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands.Queries;

public class GetProductToAttributesQuery : IRequest<IEnumerable<ProductToAttributeDto>>
{

}