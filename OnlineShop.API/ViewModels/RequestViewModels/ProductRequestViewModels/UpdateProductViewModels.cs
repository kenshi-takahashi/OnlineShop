using System.ComponentModel.DataAnnotations;

namespace OnlineShop.API.Models.RequestModels.ProductRequest
{
    public class UpdateProductViewModels
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя продукта должно быть от 3 до 100 символов.")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Описание продукта не должно превышать 1000 символов.")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Цена продукта должна быть больше 0.")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Необходимо указать категорию продукта.")]
        public int CategoryId { get; set; }
    }
}
