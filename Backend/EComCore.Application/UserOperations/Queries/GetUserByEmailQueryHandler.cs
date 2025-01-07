using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    private readonly IUserQueryService _userQueryService;

    public GetUserByEmailQueryHandler(IUserQueryService userQueryService)
    {
        _userQueryService = userQueryService;
    }

    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _userQueryService.GetUserByEmail(request.Email);
    }
}