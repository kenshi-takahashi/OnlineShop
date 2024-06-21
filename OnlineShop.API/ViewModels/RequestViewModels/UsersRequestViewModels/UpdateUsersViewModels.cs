using System.ComponentModel.DataAnnotations;
namespace OnlineShop.API.ViewModels.RequestViewModels.UsersRequestViewModels
{
    public class UpdateUsersViewModels
    {

        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя пользователя должно быть от 3 до 100 символов.")]

        public string Name { get; set; }
    }
}
