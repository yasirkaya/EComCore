using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.ProductOperations.Queries;

public class GetActiveProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductQueryService _productQueryService;
    public GetActiveProductsQueryHandler(IProductQueryService productQueryService)
    {
        _productQueryService = productQueryService;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productQueryService.GetAllAsync(request.ProductParameters);
    }
}