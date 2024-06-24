namespace OnlineShop.BLL.DTO.ResponseDTO
{
    public class CategoryResponseDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductResponseDTO> Products { get; set; }
    }
}
