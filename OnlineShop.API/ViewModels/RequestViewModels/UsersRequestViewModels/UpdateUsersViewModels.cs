using System.ComponentModel.DataAnnotations;
namespace OnlineShop.API.ViewModels.RequestViewModels.UsersRequestViewModels
{
    public class UpdateUsersViewModels
    {

        

        public string Username { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя пользователя должно быть от 3 до 100 символов.")]
        public string Email { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email пользователя должно быть от 3 до 100 символов.")]
        public string Password { get; set; }
        [StringLength(100, MinimumLength = 8, ErrorMessage = "пароль пользователя должен быть от 8 до 100 символов.")]
        public int Id { get; set; }
    }
}
