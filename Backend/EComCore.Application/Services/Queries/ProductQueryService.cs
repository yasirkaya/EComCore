using AutoMapper;
using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;
using EComCore.Domain.Shared.RequestFeatures;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class ProductQueryService : IProductQueryService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductQueryService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<bool> CheckProductStockAsync(int productId, int quantity)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        await product.EnsureNotNullAsync(id: productId);

        if (product.StockQuantity >= quantity)
        {
            return true;
        }
        return false;

    }

    public async Task<bool> CheckProductPriceAsync(int productId, decimal requestedPrice)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        await product.EnsureNotNullAsync(id: productId);

        if (product.Price == requestedPrice)
        {
            return true;
        }
        return false;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync(ProductParameters productParameters)
    {
        var products = await _productRepository.GetAllAsync(productParameters);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        await product.EnsureNotNullAsync(id: id);

        return _mapper.Map<ProductDto>(product);
    }
}