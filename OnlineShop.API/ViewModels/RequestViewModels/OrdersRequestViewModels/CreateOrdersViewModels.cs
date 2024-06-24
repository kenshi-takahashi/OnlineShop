using System.ComponentModel.DataAnnotations;
namespace OnlineShop.API.ViewModels.RequestViewModels.OrdersRequestViewModels
{
    public class CreateOrdersViewModels
    {
        [Required(ErrorMessage = "Имя заказа обязательно для заполнения.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя заказа должно быть от 3 до 100 символов.")]
        public string Name { get; set; }
    }
}
