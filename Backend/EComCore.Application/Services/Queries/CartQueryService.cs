using AutoMapper;
using EComCore.Domain.DTOs.CartDTO;
using EComCore.Domain.Extensions;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Queries;

namespace EComCore.Application.Services.Queries;

public class CartQueryService : ICartQueryService
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public CartQueryService(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<CartDto> GetByUserIdAsync(int userId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);
        if (cart == null)
            return null;

        return _mapper.Map<CartDto>(cart);
    }
}