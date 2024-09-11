using AutoMapper;
using EComCore.Application.AttributeValueOperations.Commands;
using EComCore.Application.CategoryOperations.Commands;
using EComCore.Application.CustomAttributeOperations.Commands;
using EComCore.Application.ProductOperations.Commands;
using EComCore.Application.ProductToAttributeOperations.Commands;
using EComCore.Application.ProductToCategoryOperations.Commands;
using EComCore.Domain.DTOs.AttributeDTO;
using EComCore.Domain.DTOs.AttributeValueDTO;
using EComCore.Domain.DTOs.CategoryDTO;
using EComCore.Domain.DTOs.ProductDTO;
using EComCore.Domain.DTOs.ProductToAttributeDTO;
using EComCore.Domain.DTOs.ProductToCategoryDTO;
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

        //Product
        CreateMap<CreateProductCommand, CreateProductDto>();
        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        CreateMap<UpdateProductCommand, UpdateProductDto>();
        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<DeleteProductCommand, DeleteProductDto>();
        CreateMap<Product, ProductDto>();

        //ProdusctToAttribute
        CreateMap<CreateProductToAttributeCommand, CreateProductToAttributeDto>();
        CreateMap<CreateProductToAttributeDto, ProductToAttribute>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<UpdateProductToAttributeCommand, UpdateProductToAttributeDto>();
        CreateMap<UpdateProductToAttributeDto, ProductToAttribute>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<DeleteProductToAttributeCommand, DeleteProductToAttributeDto>();
        CreateMap<ProductToAttribute, ProductToAttributeDto>()
            .ForMember(dest => dest.AttributeName, opt => opt.MapFrom(src => src.Attribute.Name))
            .ForMember(dest => dest.AttributeValue, opt => opt.MapFrom(src => src.AttributeValue.Value));

        //ProductToCategory
        CreateMap<CreateProductToCategoryCommand, CreateProductToCategoryDto>();
        CreateMap<CreateProductToCategoryDto, ProductToCategory>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<UpdateProductToCategoryCommand, UpdateProductToCategoryDto>();
        CreateMap<UpdateProductToCategoryDto, ProductToCategory>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<DeleteProductToCategoryCommand, DeleteProductToCategoryDto>();
        CreateMap<ProductToCategory, ProductToCategoryDto>();

    }
}
