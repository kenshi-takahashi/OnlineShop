using System.ComponentModel.DataAnnotations;

namespace OnlineShop.API.Models.RequestModels.CategoryRequest
{
    public class UpdateCategoryRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя категории обязательно для заполнения.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя категории должно быть от 3 до 100 символов.")]
        public string Name { get; set; }
    }
}
