using AutoMapper;
using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;


namespace OnlineShop.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, ReadOrdersDTO>().ReverseMap();
            CreateMap<Order, CreateOrdersDTO>().ReverseMap();
            CreateMap<Order, UpdateOrdersDTO>().ReverseMap();
        }
    }
}
