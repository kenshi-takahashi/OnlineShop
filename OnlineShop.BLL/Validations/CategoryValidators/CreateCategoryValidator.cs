using System.Text.RegularExpressions;
using OnlineShop.BLL.DTO;
using OnlineShop.BLL.DTO.CategoryDTO;
using OnlineShop.BLL.Interfaces;

namespace OnlineShop.BLL.Validations
{
    public class CreateCategoryValidator
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void ValidateCreateCategory(CreateCategoryDTO categoryDTO)
        {
            if (!IsNameUnique(categoryDTO.Name))
            {
                throw new CreateCategoryValidationException("Имя категории должно быть уникальным.");
            }

            if (StartsWithDigitOrSymbol(categoryDTO.Name))
            {
                throw new CreateCategoryValidationException("Имя категории не должно начинаться с цифры или символа.");
            }

            if (ContainsDigitsOrSymbols(categoryDTO.Name))
            {
                throw new CreateCategoryValidationException("Имя категории не должно содержать цифр или символов.");
            }
        }

        private bool IsNameUnique(string name)
        {
            var categories = _categoryService.GetAllCategories();
            return !categories.Any(c => c.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }

        private bool StartsWithDigitOrSymbol(string name)
        {
            return Regex.IsMatch(name, @"^[\d\W]");
        }

        private bool ContainsDigitsOrSymbols(string name)
        {
            return Regex.IsMatch(name, @"[\d\W]");
        }
    }

    // Кастомное исключение для валидации
    public class CreateCategoryValidationException : Exception
    {
        public CreateCategoryValidationException(string message) : base(message) { }

        // Добавим конструктор по умолчанию, если это нужно
        public CreateCategoryValidationException() : base() { }
    }
}
