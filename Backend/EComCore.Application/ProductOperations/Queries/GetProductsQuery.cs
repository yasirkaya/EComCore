using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Shared.RequestFeatures;
using MediatR;

namespace EComCore.Application.ProductOperations.Queries;

public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
{
    public ProductParameters ProductParameters { get; }
    public GetProductsQuery(ProductParameters productParameters)
    {
        ProductParameters = productParameters;
    }
}