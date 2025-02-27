using EComCore.Domain.DTOs;
using EComCore.Domain.Entities;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.RoleOperations.Queries
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly IRoleQueryService _roleQueryService;

        public GetRoleByIdQueryHandler(IRoleQueryService roleQueryService)
        {
            _roleQueryService = roleQueryService;
        }

        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _roleQueryService.GetByIdAsync(request.Id);
        }
    }
}