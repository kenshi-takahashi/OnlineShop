namespace MyOnlineShop.DAL.Interfaces
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
		Task<Product> GetProductWithDetailsByIdAsync(int productId);
	}
}