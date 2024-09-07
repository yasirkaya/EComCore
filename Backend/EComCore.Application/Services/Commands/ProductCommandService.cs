using AutoMapper;
using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class ProductCommandService : IProductCommandService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductCommandService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(CreateProductDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        await _productRepository.AddAsync(product);
        return product.Id;
    }

    public async Task DeleteAsync(DeleteProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.Id);
        if (product == null)
        {
            throw new Exception($"Product with Id {dto.Id} not found.");
        }
        await _productRepository.DeleteAsync(product);
    }

    public async Task SoftDelete(DeleteProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.Id);
        if (product == null)
        {
            throw new Exception($"Product with Id {dto.Id} not found.");
        }
        product.IsDeleted = true;

        await _productRepository.UpdateAsync(product);

    }

    public async Task UpdateAsync(UpdateProductDto dto)
    {
        var product = await _productRepository.GetByIdAsync(dto.Id);
        if (product == null)
        {
            throw new Exception($"Product with Id {dto.Id} not found.");
        }
        _mapper.Map(dto, product);
        await _productRepository.UpdateAsync(product);
    }
}