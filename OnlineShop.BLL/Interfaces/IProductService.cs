using OnlineShop.BLL.DTO.RequestDTO.ProductRequestDTO;

namespace OnlineShop.BLL.Interfaces
{
    public interface IProductService
    {
        Task<ReadProductDTO> GetProductByIdAsync(int productId);
        Task<IEnumerable<ReadProductDTO>> GetAllProductsAsync();
        Task CreateProductAsync(CreateProductDTO product);
        Task UpdateProductAsync(UpdateProductDTO product);
        Task DeleteProductAsync(int productId);
        Task<IEnumerable<ReadProductDTO>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
