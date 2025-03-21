using System;
using System.Threading.Tasks;
using AutoMapper;
using EComCore.Domain.DTOs.OrderDTO;
using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Domain.Services.Commands;
using EComCore.Domain.Enums;
using EComCore.Domain.DTOs.PaymentDTO;
using EComCore.Domain.Extensions;


namespace EComCore.Application.Services.Commands
{
    public class OrderCommandService : IOrderCommandService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IPaymentCommandService _paymentCommandService;

        public OrderCommandService(IOrderRepository orderRepository, IMapper mapper, IPaymentCommandService paymentCommandService, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _paymentCommandService = paymentCommandService;
            _productRepository = productRepository;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            // var order = _mapper.Map<Order>(createOrderDto);
            // order.OrderStatus = OrderStatus.Pending;
            // order.CreatedAt = DateTime.UtcNow;
            // order.OrderItems = new List<OrderItem>();

            // foreach (var item in createOrderDto.Items)
            // {
            //     var product = await _productRepository.GetByIdAsync(item.ProductId);
            //     await product.EnsureNotNullAsync(message: $"Product not found with id {item.ProductId}");

            //     if (product.StockQuantity < item.Quantity)
            //     {
            //         throw new InvalidOperationException($"Product {product.Name} is out of stock.");
            //     }

            //     product.StockQuantity -= item.Quantity;
            //     await _productRepository.UpdateAsync(product);

            //     var orderItem = new OrderItem
            //     {
            //         ProductId = item.ProductId,
            //         Quantity = item.Quantity,
            //         UnitPrice = product.Price,
            //         TotalPrice = item.Quantity * product.Price,
            //         CreatedAt = DateTime.UtcNow
            //     };
            //     order.OrderItems.Add(orderItem);
            // }

            // await _orderRepository.AddAsync(order);

            // var payment = await _paymentCommandService.CreatePaymentAsync(new CreatePaymentDto
            // {
            //     Id = new Random().Next(),
            //     TransactionId = "TRX" + Guid.NewGuid().ToString(),
            //     OrderId = order.Id,
            //     PaymentMethod = PaymentMethodType.CreditCard,
            //     Amount = order.TotalAmount,
            //     Status = PaymentStatus.Completed,
            //     FailureReason = null
            // });

            // if (payment.Status == PaymentStatus.Completed)
            // {
            //     order.OrderStatus = OrderStatus.Processing;
            // }
            // else
            // {
            //     order.OrderStatus = OrderStatus.Cancelled;
            // }

            // await _orderRepository.UpdateAsync(order);

            // return _mapper.Map<OrderDto>(order);
            return new OrderDto();
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

            order.OrderStatus = OrderStatus.Cancelled;
            order.UpdatedAt = DateTime.UtcNow;

            await _orderRepository.UpdateAsync(order);
            return true;
        }
    }
}