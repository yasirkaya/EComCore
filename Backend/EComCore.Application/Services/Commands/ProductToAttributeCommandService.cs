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
        var pta = _mapper.Map<ProductToAttribute>(dto);
        await _productToAttributeRepository.AddAsync(pta);
        return pta.Id;
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
        var pta = await _productToAttributeRepository.GetByIdAsync(dto.Id);
        if (pta == null)
        {
            throw new Exception($"Product with Id {dto.Id} not found.");
        }
        await _productToAttributeRepository.DeleteAsync(pta);
    }

    public async Task DeleteAttributesFromProductAsync(DeleteProductToAttributeDto dto)
    {
        var prodAttrs = await _productToAttributeRepository.GetAttributesByProductIdAsync(dto.Id);
        if (prodAttrs.IsNullOrEmpty())
        {
            throw new Exception($"Product with Id {dto.Id} not found.");
        }
        await _productToAttributeRepository.DeleteRangeAsync(prodAttrs);
    }

    public async Task UpdateAsync(UpdateProductToAttributeDto dto)
    {
        var pta = await _productToAttributeRepository.GetByIdAsync(dto.Id);
        if (pta == null)
        {
            throw new Exception($"Product with Id {dto.Id} not found.");
        }
        await _productToAttributeRepository.UpdateAsync(pta);
    }
}