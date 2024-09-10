using AutoMapper;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class ProductToAttributeQueryService : IProductToAttributeQueryService
{
    private readonly IProductToAttributeRepository _productToAttributeRepository;
    private readonly IMapper _mapper;
    public ProductToAttributeQueryService(IProductToAttributeRepository productToAttributeRepository, IMapper mapper)
    {
        _productToAttributeRepository = productToAttributeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductToAttributeDto>> GetAllAsync()
    {
        var prodAttrs = await _productToAttributeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductToAttributeDto>>(prodAttrs);

    }

    public async Task<ProductToAttributeDto> GetByIdAsync(int id)
    {
        var prodAttr = await _productToAttributeRepository.GetByIdAsync(id);
        if (prodAttr == null)
        {
            throw new Exception($"ProductToAttribute with Id {id} not found.");
        }
        return _mapper.Map<ProductToAttributeDto>(prodAttr);
    }
}