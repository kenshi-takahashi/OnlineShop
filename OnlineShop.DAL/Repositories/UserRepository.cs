using MyOnlineShop.DAL.Interfaces;

namespace MyOnlineShop.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(OnlineShopDbContext context) : base(context)
        {
        }
    }
}
