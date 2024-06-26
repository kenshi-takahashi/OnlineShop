using MyOnlineShop.DAL.Interfaces;

namespace OnlineShop.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
