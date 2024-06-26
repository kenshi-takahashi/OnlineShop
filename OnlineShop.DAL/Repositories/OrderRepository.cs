using Microsoft.EntityFrameworkCore;
using MyOnlineShop.DAL.Interfaces;

namespace MyOnlineShop.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly OnlineShopDbContext _context;
        public OrderRepository(OnlineShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> GetOrderWithDetailsByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
