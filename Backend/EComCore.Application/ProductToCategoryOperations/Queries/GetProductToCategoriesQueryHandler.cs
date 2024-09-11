using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.ProductToCategoryOperations.Queries;

public class GetProductToCategoriesQueryHandler : IRequestHandler<GetProductToCategoriesQuery, IEnumerable<ProductToCategoryDto>>
{
    private readonly IProductToCategoryQueryService _productToCategoryQueryService;
    public GetProductToCategoriesQueryHandler(IProductToCategoryQueryService productToCategoryQueryService)
    {
        _productToCategoryQueryService = productToCategoryQueryService;
    }

    public async Task<IEnumerable<ProductToCategoryDto>> Handle(GetProductToCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _productToCategoryQueryService.GetAllAsync();
    }
}