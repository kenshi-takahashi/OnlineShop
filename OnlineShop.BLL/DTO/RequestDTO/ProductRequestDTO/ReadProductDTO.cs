using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;

namespace OnlineShop.BLL.DTO.RequestDTO.ProductRequestDTO
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
