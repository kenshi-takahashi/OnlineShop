using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


using MyOnlineShop.DAL.Interfaces;

namespace MyOnlineShop.DAL.Repositories
{
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(OnlineShopDbContext context) : base(context)
		{
		}
	}
}