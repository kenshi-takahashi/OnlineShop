namespace OnlineShop.API.Models.ResponseModels
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductResponse> Products { get; set; }
    }
}
