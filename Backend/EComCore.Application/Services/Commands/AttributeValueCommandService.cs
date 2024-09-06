using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDto;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands;

public class AttributeValueCommandService : IAttributeValueCommandService
{
    private readonly IAttributeValueRepository _attributeValueRepository;
    private readonly IAttributeRepository _attributeRepository;
    private readonly IMapper _mapper;
    public AttributeValueCommandService(IAttributeValueRepository attributeValueRepository, IMapper mapper, IAttributeRepository attributeRepository)
    {
        _attributeValueRepository = attributeValueRepository;
        _mapper = mapper;
        _attributeRepository = attributeRepository;
    }

    public async Task<int> AddAsync(CreateAttributeValueDto dto)
    {
        var attribute = await _attributeRepository.GetByIdAsync(dto.AttributeId);
        if (attribute == null)
        {
            throw new Exception("Attribute not found for the given AttributeId.");
        }
        var attributeValue = _mapper.Map<AttributeValue>(dto);
        await _attributeValueRepository.AddAsync(attributeValue);
        return attributeValue.Id;
    }

    public async Task DeleteAsync(DeleteAttributeValueDto dto)
    {
        var attributeValue = await _attributeValueRepository.GetByIdAsync(dto.Id);
        if (attributeValue == null)
        {
            throw new Exception($"AttributeValue with Id {dto.Id} not found.");
        }
        await _attributeValueRepository.DeleteAsync(attributeValue);
    }

    public async Task DeleteByAttributeIdAsync(int attributeId)
    {
        var attibuteValues = await _attributeValueRepository.GetValuesByAttributeIdAsync(attributeId);
        if (!attibuteValues.Any())
        {
            throw new Exception("No attribute values found for the given attribute ID.");
        }
        await _attributeValueRepository.RemoveRangeAsync(attibuteValues);
    }

    public async Task UpdateAsync(UpdateAttributeValueDto dto)
    {
        var attibuteValue = await _attributeValueRepository.GetByIdAsync(dto.Id);

        if (attibuteValue == null)
        {
            throw new Exception($"AttributeValue with Id {dto.Id} not found.");
        }

        _mapper.Map(dto, attibuteValue);
        await _attributeValueRepository.UpdateAsync(attibuteValue);
    }
}