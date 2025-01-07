using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly IUserQueryService _userQueryService;

    public GetAllUsersQueryHandler(IUserQueryService userQueryService)
    {
        _userQueryService = userQueryService;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userQueryService.GetAllUsers();
    }
}