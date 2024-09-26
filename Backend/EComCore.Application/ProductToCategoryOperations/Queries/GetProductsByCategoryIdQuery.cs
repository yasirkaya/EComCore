using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Shared.RequestFeatures;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Queries;

public class GetProductsByCategoryIdQuery : IRequest<IEnumerable<ProductToCategoryDto>>
{
    public GetProductsByCategoryIdQuery(ProductToCategoryParameters productToCategoryParameters)
    {
        ProductToCategoryParameters = productToCategoryParameters;
    }
    public ProductToCategoryParameters ProductToCategoryParameters { get; set; }
    public int CategoryId { get; set; }
}