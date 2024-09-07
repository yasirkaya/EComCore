using AutoMapper;
using EComCore.Application.AttributeValueOperations.Commands;
using EComCore.Application.CategoryOperations.Commands;
using EComCore.Application.CustomAttributeOperations.Commands;
using EComCore.Domain.DTOs.AttributeDTO;
using EComCore.Domain.DTOs.AttributeValueDTO;
using EComCore.Domain.DTOs.CategoryDTO;
using EComCore.Domain.Entities;

namespace EComCore.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Category
        CreateMap<CreateCategoryCommand, CreateCategoryDto>();
        CreateMap<CreateCategoryDto, Category>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<UpdateCategoryCommand, UpdateCategoryDto>();
        CreateMap<UpdateCategoryDto, Category>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<DeleteCategoryCommand, DeleteCategoryDto>();
        CreateMap<Category, CategoryDto>();

        // CustomAttribute
        CreateMap<CreateCustomAttributeCommand, CreateAttributeDto>();
        CreateMap<CreateAttributeDto, CustomAttribute>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<UpdateAttributeDto, CustomAttribute>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateCustomAttributeCommand, UpdateAttributeDto>();
        CreateMap<DeleteCustomAttributeCommand, DeleteAttributeDto>();
        CreateMap<CustomAttribute, CustomAttributeDto>();

        // AttributeValue
        CreateMap<CreateAttributeValueCommand, CreateAttributeValueDto>();
        CreateMap<CreateAttributeValueDto, AttributeValue>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<UpdateAttributeValueDto, AttributeValue>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateAttributeValueCommand, UpdateAttributeValueDto>();
        CreateMap<DeleteAttributeValueCommand, DeleteAttributeValueDto>();
        CreateMap<AttributeValue, AttributeValueDto>()
            .ForMember(dest => dest.AttributeName, opt => opt.MapFrom(src => src.Attribute.Name));
    }
}
