using System.Text.RegularExpressions;
using OnlineShop.BLL.DTO;
using OnlineShop.BLL.DTO.CategoryDTO;

namespace OnlineShop.BLL.Validations
{
    public class UpdateCategoryValidator
    {
        public void ValidateUpdateCategory(UpdateCategoryDTO categoryDTO)
        {
            if (StartsWithDigitOrSymbol(categoryDTO.Name))
            {
                throw new UpdateCategoryValidationException("Имя категории не должно начинаться с цифры или символа.");
            }

            if (ContainsDigitsOrSymbols(categoryDTO.Name))
            {
                throw new UpdateCategoryValidationException("Имя категории не должно содержать цифр или символов.");
            }
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
    public class UpdateCategoryValidationException : Exception
    {
        public UpdateCategoryValidationException(string message) : base(message) { }
    }
}
