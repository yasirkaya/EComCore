using EComCore.Domain.DTOs.UserDTO;
using EComCore.Domain.Services.Queries;
using MediatR;

namespace EComCore.Application.UserOperations.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserQueryService _userQueryService;

    public GetUserByIdQueryHandler(IUserQueryService userQueryService)
    {
        _userQueryService = userQueryService;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userQueryService.GetUserById(request.Id);
    }
}