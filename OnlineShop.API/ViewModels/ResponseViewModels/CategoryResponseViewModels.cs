namespace OnlineShop.API.Models.ResponseModels
{
    public class CategoryResponseViewModels
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductResponseViewModels> Products { get; set; }
    }
}
