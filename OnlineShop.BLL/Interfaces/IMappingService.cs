using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;

namespace OnlineShop.BLL.Interfaces
{
    public interface IMappingService
    {
        ReadOrdersDTO MapOrderToReadOrderDTO(Order order);
        Order MapCreateOrdersDTOToOrder(CreateOrdersDTO createOrderDto);
        Order MapUpdateOrdersDTOToOrder(UpdateOrdersDTO updateOrderDto);
    }
}
