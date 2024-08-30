using EComCore.Domain.Entities;

namespace EComCore.Domain.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category> GetCategoryByNameAsync(string name);
    Task<IEnumerable<Category>> GetSubcategoriesAsync(int parentId);
}