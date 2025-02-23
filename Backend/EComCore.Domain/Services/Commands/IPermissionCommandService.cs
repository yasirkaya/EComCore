using EComCore.Domain.Entities;

namespace EComCore.Domain.Services.Commands
{
    public interface IPermissionCommandService
    {
        Task CreateAsync(Permission permission);
        Task UpdateAsync(Permission permission);
        Task DeleteAsync(int id);
    }
}