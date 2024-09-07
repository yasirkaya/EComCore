using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAllActiveAsync();
}