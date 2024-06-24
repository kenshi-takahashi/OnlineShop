using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;

namespace OnlineShop.BLL.Interfaces
{
    public interface IOrdersService
    {
        Task<ReadOrdersDTO> GetOrdersByIdAsync(int orderId);
        Task<IEnumerable<ReadOrdersDTO>> GetAllOrdersAsync();
        Task CreateOrdersAsync(CreateOrdersDTO order);
        Task UpdateOrdersAsync(UpdateOrdersDTO order);
        Task DeleteOrdersAsync(int orderId); 
    }
}
 