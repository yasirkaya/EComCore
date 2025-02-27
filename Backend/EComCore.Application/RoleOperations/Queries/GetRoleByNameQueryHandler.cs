using EComCore.Domain.DTOs;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.RoleOperations.Queries
{
    public class GetRoleByNameQueryHandler : IRequestHandler<GetRoleByNameQuery, RoleDto>
    {
        private readonly IRoleQueryService _roleQueryService;

        public GetRoleByNameQueryHandler(IRoleQueryService roleQueryService)
        {
            _roleQueryService = roleQueryService;
        }

        public async Task<RoleDto> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            return await _roleQueryService.GetByNameAsync(request.Name);
        }
    }
}