using EComCore.Domain.DTOs.ProductDTO;

namespace EComCore.Domain.Services.Commands;

public interface IProductCommandService
{
    Task<int> AddAsync(CreateProductDto dto);
    Task UpdateAsync(UpdateProductDto dto);
    Task DeleteAsync(DeleteProductDto dto);
}