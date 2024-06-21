using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyOnlineShop.DAL.Interfaces
{
	public interface IProductRepository : IGenericRepository<Product>
	{
		Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
		Task<Product> GetProductWithDetailsByIdAsync(int productId);
	}
}