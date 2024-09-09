using EComCore.Domain.DTOs.ProductToAttributeDTO;

namespace EComCore.Domain.Services.Commands;

public interface IProductToAttributeCommandService
{
    Task<int> AddAsync(CreateProductToAttributeDto dto);
    Task UpdateAsync(UpdateProductToAttributeDto dto);
    Task DeleteAsync(DeleteProductToAttributeDto dto);
}