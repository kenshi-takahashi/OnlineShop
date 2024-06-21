using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.DTO.ResponseDTO
{
    public class ProductResponseDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryResponseDTO Category { get; set; }
        //public ICollection<OrderItemResponse> OrderItems { get; set; }
    }
}
