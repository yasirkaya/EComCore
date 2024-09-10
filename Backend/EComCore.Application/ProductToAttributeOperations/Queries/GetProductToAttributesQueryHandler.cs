using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.ProductToAttributeOperations.Commands.Queries;

public class GetProductToAttributesQueryHandler : IRequestHandler<GetProductToAttributesQuery, IEnumerable<ProductToAttributeDto>>
{
    private readonly IProductToAttributeQueryService _productToAttributeQueryService;
    public GetProductToAttributesQueryHandler(IProductToAttributeQueryService productToAttributeQueryService)
    {
        _productToAttributeQueryService = productToAttributeQueryService;
    }

    public async Task<IEnumerable<ProductToAttributeDto>> Handle(GetProductToAttributesQuery request, CancellationToken cancellationToken)
    {
        return await _productToAttributeQueryService.GetAllAsync();
    }
}