using System;
using System.Threading.Tasks;
using AutoMapper;
using EComCore.Domain.DTOs.OrderDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;

namespace EComCore.Application.Services.Commands
{
    public class OrderCommandService : IOrderCommandService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderCommandService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = _mapper.Map<Order>(createOrderDto);
            order.OrderStatus = "Pending";
            order.CreatedAt = DateTime.UtcNow;

            await _orderRepository.AddAsync(order);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> UpdateOrderStatusAsync(UpdateOrderStatusDto updateOrderStatusDto)
        {
            var order = await _orderRepository.GetByIdAsync(updateOrderStatusDto.OrderId);
            if (order == null)
                return null;

            order.OrderStatus = updateOrderStatusDto.OrderStatus;
            order.UpdatedAt = DateTime.UtcNow;

            await _orderRepository.UpdateAsync(order);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<bool> CancelOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                return false;

            order.OrderStatus = "Cancelled";
            order.UpdatedAt = DateTime.UtcNow;

            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}