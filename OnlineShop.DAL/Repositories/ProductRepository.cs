using Microsoft.EntityFrameworkCore;
using MyOnlineShop.DAL.Interfaces;

namespace MyOnlineShop.DAL.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(OnlineShopDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
		{
			return await _context.Products
				.Where(p => p.CategoryId == categoryId)
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<Product> GetProductWithDetailsByIdAsync(int productId)
		{
			return await _context.Products
				.Include(p => p.Category)
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.ProductId == productId);
		}
	}
}