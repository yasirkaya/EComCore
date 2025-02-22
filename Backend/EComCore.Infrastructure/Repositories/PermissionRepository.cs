using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;
using EComCore.Infrastructure.Repositories;

namespace EComCore.ınfrastructure.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(EComCoreDbContext context) : base(context)
        {
        }
    }
}