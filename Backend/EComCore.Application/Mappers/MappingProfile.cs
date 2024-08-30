using AutoMapper;
using EComCore.Application.Services.CategoryOperations.Commands;
using EComCore.Domain.Entities;

namespace EComCore.Application.Mappers;

public class MappingProfile : Profile
{
    protected MappingProfile()
    {
        CreateMap<CreateCategoryCommand, Category>();
    }
}
