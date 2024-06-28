using AutoMapper;
using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using OnlineShop.BLL.Interfaces;

namespace OnlineShop.BLL.Services
{
    public class MappingService : IMappingService
    {
        private readonly IMapper _mapper;

        public MappingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ReadOrdersDTO MapOrderToReadOrderDTO(Order order)
        {
            return _mapper.Map<ReadOrdersDTO>(order);
        }

        public Order MapCreateOrdersDTOToOrder(CreateOrdersDTO createOrderDto)
        {
            return _mapper.Map<Order>(createOrderDto);
        }

        public Order MapUpdateOrdersDTOToOrder(UpdateOrdersDTO updateOrderDto)
        {
            return _mapper.Map<Order>(updateOrderDto);
        }
    }
}
