using OnlineShop.BLL.DTO.RequestDTO.UsersRequestDTO;
using OnlineShop.BLL.DTO.ResponseDTO;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(UserRegisterDTO model);
        Task<AuthResult> LoginAsync(UserLoginDTO model);
    }
}
