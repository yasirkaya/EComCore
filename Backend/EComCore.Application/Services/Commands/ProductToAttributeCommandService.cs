using System.Data.SqlTypes;
using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;
using Microsoft.IdentityModel.Tokens;

namespace EComCore.Application.Services.Commands;

public class ProductToAttributeCommandService : IProductToAttributeCommandService
{
    private readonly IProductToAttributeRepository _productToAttributeRepository;
    private readonly IMapper _mapper;
    public ProductToAttributeCommandService(IProductToAttributeRepository productToAttributeRepository, IMapper mapper)
    {
        _productToAttributeRepository = productToAttributeRepository;
        _mapper = mapper;
    }

    public async Task<int> AddAsync(CreateProductToAttributeDto dto)
    {
        var prodAttr = _mapper.Map<ProductToAttribute>(dto);
        await _productToAttributeRepository.AddAsync(prodAttr);
        return prodAttr.Id;
    }

    public async Task AddAttributesToProductAsync(IEnumerable<CreateProductToAttributeDto> dtos)
    {
        if (dtos.IsNullOrEmpty())
        {
            throw new ArgumentException("Attribute list cannot be null or empty.");
        }
        var prodAttrs = _mapper.Map<IEnumerable<ProductToAttribute>>(dtos);

        // transaction eklenecek
        await _productToAttributeRepository.AddRangeAsync(prodAttrs);
    }

    public async Task DeleteAsync(DeleteProductToAttributeDto dto)
    {
        var prodAttr = await _productToAttributeRepository.GetByIdAsync(dto.Id);
        if (prodAttr == null)
        {
            throw new Exception($"Product with Id {dto.Id} not found.");
        }
        await _productToAttributeRepository.DeleteAsync(prodAttr);
    }

    public async Task DeleteAttributesFromProductAsync(int productId)
    {
        var prodAttrs = await _productToAttributeRepository.GetAttributesByProductIdAsync(productId);
        if (prodAttrs.IsNullOrEmpty())
        {
            throw new Exception($"Product with Id {productId} not found.");
        }
        await _productToAttributeRepository.DeleteRangeAsync(prodAttrs);
    }

    public async Task UpdateAsync(UpdateProductToAttributeDto dto)
    {
        var prodAttr = await _productToAttributeRepository.GetByIdAsync(dto.Id);
        if (prodAttr == null)
        {
            throw new Exception($"Product with Id {dto.Id} not found.");
        }
        _mapper.Map(dto, prodAttr);
        await _productToAttributeRepository.UpdateAsync(prodAttr);
    }
}