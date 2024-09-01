using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetSubcategoriesAsync(int parentId);
}