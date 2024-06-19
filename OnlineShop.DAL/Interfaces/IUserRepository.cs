using System.Collections.Generic;
using System.Threading.Tasks;


namespace MyOnlineShop.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
