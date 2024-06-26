using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Interfaces
{
    public interface IOrdersService
    {
        Task<ReadOrdersDTO> GetOrdersByIdAsync(int orderId);
        Task<IEnumerable<ReadOrdersDTO>> GetAllOrdersAsync();
        Task<ReadOrdersDTO> CreateOrdersAsync(CreateOrdersDTO order);
        Task UpdateOrdersAsync(UpdateOrdersDTO order);
        Task DeleteOrdersAsync(int orderId);
    }
}
