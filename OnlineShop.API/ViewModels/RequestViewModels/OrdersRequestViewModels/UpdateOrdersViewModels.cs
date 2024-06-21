using System.ComponentModel.DataAnnotations;
namespace OnlineShop.API.ViewModels.RequestViewModels.OrdersRequestViewModels
{
    public class UpdateOrdersViewModels
    {
        [Required(ErrorMessage = "Имя заказа обязательно для заполнения.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя заказа должно быть от 3 до 100 символов.")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Описание заказа не должно превышать 1000 символов.")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Цена заказа должна быть больше 0.")]
        public decimal Price { get; set; }

       
    }
}
