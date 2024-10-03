using AutoMapper;
using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;
using EComCore.Domain.Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;

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

        var products = _productRepository.GetQueryable();

        if (productParameters.MinPrice.HasValue)
        {
            products = products.Where(p => p.Price >= productParameters.MinPrice.Value);
        }

        if (productParameters.MaxPrice.HasValue)
        {
            products = products.Where(p => p.Price <= productParameters.MaxPrice.Value);
        }

        if (productParameters.MinRating.HasValue)
        {
            products = products.Where(p => p.Rating >= productParameters.MinRating.Value);
        }

        if (productParameters.GroupId.HasValue)
        {
            products = products.Where(p => p.GroupId == productParameters.GroupId.Value);
        }

        if (productParameters.CreatedFrom.HasValue)
        {
            products = products.Where(p => p.CreatedAt >= productParameters.CreatedFrom.Value);
        }

        if (productParameters.CreatedTo.HasValue)
        {
            products = products.Where(p => p.CreatedAt <= productParameters.CreatedTo.Value);
        }

        if (productParameters.IncludeDeleted.HasValue && !productParameters.IncludeDeleted.Value)
        {
            products = products.Where(p => !p.IsDeleted);
        }

        var pagedProducts = await products
            .OrderBy(p => p.Id)
            .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
            .Take(productParameters.PageSize)
            .ToListAsync();

        return _mapper.Map<IEnumerable<ProductDto>>(pagedProducts);
    }

    public async Task<ProductDto> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        await product.EnsureNotNullAsync(id: id);

        return _mapper.Map<ProductDto>(product);
    }
}