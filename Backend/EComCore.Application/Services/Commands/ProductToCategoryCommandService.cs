using AutoMapper;
using EComCore.Domain.DTOs.ProductToCategoryDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;
using Microsoft.IdentityModel.Tokens;

namespace EComCore.Application.Services.Commands;

public class ProductToCategoryCommandService : IProductToCategoryCommandService
{
    private readonly IProductToCategoryRepository _productToCategoryRepository;
    private readonly IMapper _mapper;
    public ProductToCategoryCommandService(IProductToCategoryRepository productToCategoryRepository, IMapper mapper)
    {
        _productToCategoryRepository = productToCategoryRepository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(CreateProductToCategoryDto dto)
    {
        var prodCat = _mapper.Map<ProductToCategory>(dto);
        await _productToCategoryRepository.AddAsync(prodCat);
        return prodCat.Id;
    }

    public async Task DeleteAsync(DeleteProductToCategoryDto dto)
    {
        var prodCat = await _productToCategoryRepository.GetByIdAsync(dto.Id);
        if (prodCat == null)
        {
            throw new Exception($"ProductToCategory with Id {dto.Id} not found.");
        }
        await _productToCategoryRepository.DeleteAsync(prodCat); ;
    }

    public async Task DeleteProductFromCategoriesAsync(int productId)
    {
        var prodCats = await _productToCategoryRepository.GetByProductIdAsync(productId);
        if (prodCats.IsNullOrEmpty())
        {
            throw new ArgumentException("Product list cannot be null or empty.");
        }
        await _productToCategoryRepository.DeleteByProductIdAsync(prodCats);
    }

    public async Task UpdateAsync(UpdateProductToCategoryDto dto)
    {
        var prodCat = await _productToCategoryRepository.GetByIdAsync(dto.Id);
        if (prodCat == null)
        {
            throw new Exception($"ProductToCategory with Id {dto.Id} not found.");
        }
        _mapper.Map(dto, prodCat);
        await _productToCategoryRepository.UpdateAsync(prodCat);
    }
}