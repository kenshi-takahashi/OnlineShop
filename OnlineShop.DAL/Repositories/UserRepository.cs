using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyOnlineShop.DAL.Interfaces;

namespace MyOnlineShop.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(OnlineShopDbContext context) : base(context)
        {
        }

       
    }
}
