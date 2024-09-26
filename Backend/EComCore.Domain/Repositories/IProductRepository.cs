using EComCore.Domain.Entities;
using EComCore.Domain.Shared.RequestFeatures;

namespace EComCore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAllAsync(ProductParameters productParameters);
    Task<IEnumerable<Product>> GetAllwithDeletedAsync(ProductParameters productParameters);
}