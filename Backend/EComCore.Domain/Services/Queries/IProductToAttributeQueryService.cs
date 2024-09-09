using EComCore.Domain.DTOs.ProductToAttributeDTO;

namespace EComCore.Domain.Services.Queries;

public interface IProductToAttributeQueryService
{
    Task<IEnumerable<ProductToAttributeDto>> GetAllAsync();
    Task<ProductToAttributeDto> GetByIdAsync(int id);
}