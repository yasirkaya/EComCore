using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Queries
{
    public interface IPermissionQueryService
    {
        Task<Permission> GetByIdAsync(int id);
        Task<IEnumerable<Permission>> GetAllAsync();
    }
}