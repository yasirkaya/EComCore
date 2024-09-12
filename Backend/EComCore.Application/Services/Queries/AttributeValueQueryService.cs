using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.CategoryOperations.Queries;

public class AttributeValueQueryService : IAttributeValueQueryService
{
    private readonly IAttributeValueRepository _attributeValueRepository;
    private readonly IMapper _mapper;
    public AttributeValueQueryService(IAttributeValueRepository attributeValueRepository, IMapper mapper)
    {
        _attributeValueRepository = attributeValueRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AttributeValueDto>> GetAllAsync()
    {
        var attributeValues = await _attributeValueRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AttributeValueDto>>(attributeValues);
    }

    public async Task<AttributeValueDto> GetAttributeValueByIdAsync(int id)
    {
        var attributeValue = await _attributeValueRepository.GetByIdAsync(id);
        await attributeValue.EnsureNotNullAsync(id: id);

        return _mapper.Map<AttributeValueDto>(attributeValue);
    }

    public async Task<IEnumerable<AttributeValueDto>> GetValuesByAttributeIdAsync(int attributeId)
    {
        var values = await _attributeValueRepository.GetValuesByAttributeIdAsync(attributeId);
        await values.EnsureNotNullOrEmptyAsync(message: "No attribute values found for the given attribute ID.");

        return _mapper.Map<IEnumerable<AttributeValueDto>>(values);
    }
}