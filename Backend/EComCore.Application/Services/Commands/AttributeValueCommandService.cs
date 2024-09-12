using System.Data.Common;
using AutoMapper;
using EComCore.Domain.DTOs.AttributeValueDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Extensions;
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
        await attribute.EnsureNotNullAsync(id: dto.AttributeId);

        var attributeValue = _mapper.Map<AttributeValue>(dto);
        await _attributeValueRepository.AddAsync(attributeValue);
        return attributeValue.Id;
    }

    public async Task DeleteAsync(DeleteAttributeValueDto dto)
    {
        var attributeValue = await _attributeValueRepository.GetByIdAsync(dto.Id);
        await attributeValue.EnsureNotNullAsync(id: dto.Id);

        await _attributeValueRepository.DeleteAsync(attributeValue);
    }

    public async Task DeleteByAttributeIdAsync(int attributeId)
    {
        var attibuteValues = await _attributeValueRepository.GetValuesByAttributeIdAsync(attributeId);
        await attibuteValues.EnsureNotNullOrEmptyAsync(message: "No attribute values found for the given attribute ID.");

        await _attributeValueRepository.RemoveRangeAsync(attibuteValues);
    }

    public async Task UpdateAsync(UpdateAttributeValueDto dto)
    {
        var attibuteValue = await _attributeValueRepository.GetByIdAsync(dto.Id);
        await attibuteValue.EnsureNotNullAsync(id: dto.Id);

        _mapper.Map(dto, attibuteValue);
        await _attributeValueRepository.UpdateAsync(attibuteValue);
    }
}