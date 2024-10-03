using AutoMapper;
using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;
using EComCore.Domain.Shared.RequestFeatures;
using Microsoft.IdentityModel.Tokens;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class ProductToCategoryQueryService : IProductToCategoryQueryService
{
    private readonly IProductToCategoryRepository _productToCategoryRepository;
    private readonly IMapper _mapper;
    public ProductToCategoryQueryService(IProductToCategoryRepository productToCategoryRepository, IMapper mapper)
    {
        _productToCategoryRepository = productToCategoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductToCategoryDto>> GetAllAsync()
    {
        var prodCats = await _productToCategoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductToCategoryDto>>(prodCats);
    }

    public async Task<IEnumerable<ProductToCategoryDto>> GetCategoriesByProductIdAsync(int productId)
    {
        var prodCats = await _productToCategoryRepository.GetByProductIdAsync(productId);
        await prodCats.EnsureNotNullOrEmptyAsync($"Product with Id {productId} does not have any associated categories.");

        return _mapper.Map<IEnumerable<ProductToCategoryDto>>(prodCats);
    }

    public async Task<IEnumerable<ProductToCategoryDto>> GetProductsByCategoryIdAsync(int categoryId, ProductToCategoryParameters productToCategoryParameters)
    {
        var prodCats = await _productToCategoryRepository.GetByCategoryIdAsync(categoryId, productToCategoryParameters);
        await prodCats.EnsureNotNullOrEmptyAsync($"Category with Id {categoryId} does not have any associated products.");

        return _mapper.Map<IEnumerable<ProductToCategoryDto>>(prodCats);
    }
}