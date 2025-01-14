using AutoMapper;
using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class ProductCommandService : IProductCommandService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductToCategoryRepository _productToCategoryRepository;
    private readonly IMapper _mapper;
    public ProductCommandService(
        IProductRepository productRepository,
        IProductToCategoryRepository productToCategoryRepository,
        IMapper mapper
        )
    {
        _productRepository = productRepository;
        _productToCategoryRepository = productToCategoryRepository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        await _productRepository.AddAsync(product);
        var productToCategories = dto.CategoryIds.Select(x => new ProductToCategory
        {
            ProductId = product.Id,
            CategoryId = x,
            CreatedAt = DateTime.UtcNow
        });

        await _productToCategoryRepository.AddByProductIdAsync(productToCategories);
        return product.Id;
    }

    public async Task DeleteAsync(DeleteProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.Id);
        await product.EnsureNotNullAsync(id: dto.Id);

        await _productRepository.DeleteAsync(product);
    }

    public async Task SoftDelete(DeleteProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.Id);
        await product.EnsureNotNullAsync(id: dto.Id);

        product.IsDeleted = true;

        await _productRepository.UpdateAsync(product);

    }

    public async Task UpdateAsync(UpdateProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.Id);
        await product.EnsureNotNullAsync(id: dto.Id);

        var categories = await _productToCategoryRepository.GetByProductIdAsync(dto.Id);

        var categoryIds = categories.Select(x => x.CategoryId).ToList();

        if (!HaveSameElements(categoryIds, dto.CategoryIds))
        {
            var newProductToCategories = dto.CategoryIds.Select(x => new ProductToCategory
            {
                ProductId = dto.Id,
                CategoryId = x,
                CreatedAt = DateTime.UtcNow
            });

            await _productToCategoryRepository.DeleteByProductIdAsync(categories);
            await _productToCategoryRepository.AddByProductIdAsync(newProductToCategories);

        }

        _mapper.Map(dto, product);
        await _productRepository.UpdateAsync(product);
    }

    private static bool HaveSameElements<T>(List<T> list1, List<T> list2)
    {
        if (list1 == null || list2 == null)
            return false;

        return new HashSet<T>(list1).SetEquals(list2);
    }
}