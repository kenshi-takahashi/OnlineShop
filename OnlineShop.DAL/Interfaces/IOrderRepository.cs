﻿namespace MyOnlineShop.DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order> GetOrderWithDetailsByIdAsync(int orderId);
    }
}
