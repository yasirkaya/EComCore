using EComCore.Domain.DTOs;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.RoleOperations.Queries
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IEnumerable<RoleDto>>
    {
        private readonly IRoleQueryService _roleQueryService;

        public GetRolesQueryHandler(IRoleQueryService roleQueryService)
        {
            _roleQueryService = roleQueryService;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return await _roleQueryService.GetAllAsync();
        }
    }
}