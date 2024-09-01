using AutoMapper;
using EComCore.Application.CategoryOperations.Commands;
using EComCore.Domain.DTOs.CategoryDto;
using EComCore.Domain.Entities;

namespace EComCore.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryCommand, CreateCategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryCommand, UpdateCategoryDto>();
        CreateMap<UpdateCategoryDto, Category>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<DeleteCategoryCommand, DeleteCategoryDto>();
        CreateMap<Category, CategoryDto>();
    }
}
