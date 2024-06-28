using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using OnlineShop.BLL.Interfaces;
using OnlineShop.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly OnlineShopDbContext _context;
        private readonly IMapper _mapper;

        public OrdersService(OnlineShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadOrdersDTO> GetOrdersByIdAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            return _mapper.Map<ReadOrdersDTO>(order);
        }

        public async Task<IEnumerable<ReadOrdersDTO>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ReadOrdersDTO>>(orders);
        }

        public async Task<int> CreateOrdersAsync(CreateOrdersDTO orderDto)
        {
            var orderEntity = _mapper.Map<Order>(orderDto);

            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();

            return orderEntity.Id; // Возвращаем идентификатор созданного заказа
        }

        public async Task UpdateOrdersAsync(UpdateOrdersDTO orderDto)
        {
            var orderEntity = _mapper.Map<Order>(orderDto);

            _context.Orders.Update(orderEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrdersAsync(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
