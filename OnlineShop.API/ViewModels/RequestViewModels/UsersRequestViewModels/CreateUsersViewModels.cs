using System.ComponentModel.DataAnnotations;
namespace OnlineShop.API.ViewModels.RequestViewModels.UsersRequestViewModels
{
    public class CreateUsersViewModels
    {
        [Required(ErrorMessage = "Имя пользователя обязательно для заполнения.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя пользователя должно быть от 3 до 100 символов.")]
        public string Name { get; set; }
    }
}
