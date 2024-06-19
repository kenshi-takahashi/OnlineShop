using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.BLL.DTO.CategoryDTO;

namespace OnlineShop.BLL.DTO.ProductDTO
{
    public class ReadProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ReadCategoryDTO Category { get; set; }
    }
}
