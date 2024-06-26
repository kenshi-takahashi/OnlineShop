using AutoMapper;
using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using OnlineShop.BLL.Interfaces;

using MyOnlineShop.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrdersService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ReadOrdersDTO> GetOrdersByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderWithDetailsByIdAsync(orderId);
            return _mapper.Map<ReadOrdersDTO>(order);
        }

        public async Task<IEnumerable<ReadOrdersDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadOrdersDTO>>(orders);
        }

        public async Task<ReadOrdersDTO> CreateOrdersAsync(CreateOrdersDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.AddAsync(order);
            return _mapper.Map<ReadOrdersDTO>(order);
        }

        public async Task UpdateOrdersAsync(UpdateOrdersDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrdersAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order != null)
            {
                await _orderRepository.DeleteAsync(order);
            }
        }
    }
}
