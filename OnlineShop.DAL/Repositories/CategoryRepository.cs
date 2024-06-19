using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(OnlineShopDbContext context) : base(context)
    {
    }
}
