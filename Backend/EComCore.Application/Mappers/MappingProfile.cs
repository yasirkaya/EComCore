using AutoMapper;
using EComCore.Application.CategoryOperations.Commands;
using EComCore.Application.CustomAttributeOperations.Commands;
using EComCore.Domain.DTOs.AttributeDto;
using EComCore.Domain.DTOs.CategoryDto;
using EComCore.Domain.Entities;

namespace EComCore.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryCommand, CreateCategoryDto>();
        CreateMap<CreateCategoryDto, Category>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<UpdateCategoryCommand, UpdateCategoryDto>();
        CreateMap<UpdateCategoryDto, Category>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<DeleteCategoryCommand, DeleteCategoryDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCustomAttributeCommand, CreateAttribureDto>();
        CreateMap<CreateAttribureDto, CustomAttribute>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<UpdateAttribureDto, CustomAttribute>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateCustomAttributeCommand, UpdateAttribureDto>();
        CreateMap<DeleteCustomAttributeCommand, DeleteAttribureDto>();
        CreateMap<CustomAttribute, CustomAttributeDto>();
    }
}
