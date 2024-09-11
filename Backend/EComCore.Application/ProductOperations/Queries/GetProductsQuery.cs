using EComCore.Domain.DTOs.ProductDTO;
using MediatR;

namespace EComCore.Application.ProductOperations.Queries;

public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
{

}