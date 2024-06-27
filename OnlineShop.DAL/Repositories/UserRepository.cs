using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Interfaces;

namespace OnlineShop.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(OnlineShopDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
            {
                return await _context.Users
                    .Include(u => u.Role) // Ensure role is loaded
                    .SingleOrDefaultAsync(u => u.Email == email);
            }
    }
}
