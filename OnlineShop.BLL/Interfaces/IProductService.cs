using OnlineShop.BLL.DTO.ProductDTO;

namespace OnlineShop.BLL.Interfaces
{
    public interface IProductService
    {
        ReadProductDTO GetProductById(int productId);
        IEnumerable<ReadProductDTO> GetAllProducts();
        void CreateProduct(CreateProductDTO product);
        void UpdateProduct(UpdateProductDTO product);
        void DeleteProduct(int productId);

        IEnumerable<ReadProductDTO> GetProductsByCategoryId(int categoryId);
    }
}