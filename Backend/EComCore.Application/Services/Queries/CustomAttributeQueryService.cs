using AutoMapper;
using EComCore.Domain.DTOs.AttributeDTO;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.CustomAttributeOperations.Queries;

public class CustomAttributeQueryService : ICustomAttributeQueryService
{
    private readonly IAttributeRepository _attributeRepository;
    private readonly IMapper _mapper;
    public CustomAttributeQueryService(IAttributeRepository attributeRepository, IMapper mapper)
    {
        _attributeRepository = attributeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomAttributeDto>> GetAllAsync()
    {
        var attributes = await _attributeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomAttributeDto>>(attributes);
    }

    public async Task<CustomAttributeDto> GetByIdAsync(int id)
    {
        var attribute = await _attributeRepository.GetByIdAsync(id);
        if (attribute == null)
        {
            throw new Exception($"Attribute with Id {id} not found.");
        }
        return _mapper.Map<CustomAttributeDto>(attribute);
    }
}