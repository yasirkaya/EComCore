using EComCore.Domain.DTOs;
using MediatR;

namespace EComCore.Application.RoleOperations.Queries
{
    public class GetRoleByNameQuery : IRequest<RoleDto>
    {
        public string Name { get; set; }
    }
}