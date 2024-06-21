using OnlineShop.BLL.DTO.RequestDTO.UsersRequestDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Interfaces
{
    public interface IUsersService
    {
        Task<ReadUsersDTO> GetUsersByIdAsync(int userId);
        Task<IEnumerable<ReadUsersDTO>> GetAllUsersAsync();
        Task CreateCategoryAsync(CreateUsersDTO user);
        Task UpdateUsersAsync(UpdateUsersDTO user);
        Task DeleteUsersAsync(int userId);
    }
}
