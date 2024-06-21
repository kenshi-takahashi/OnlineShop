namespace MyOnlineShop.DAL.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
