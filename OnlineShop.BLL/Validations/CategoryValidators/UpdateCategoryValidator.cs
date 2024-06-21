using FluentValidation;
using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;
using System.Text.RegularExpressions;

namespace OnlineShop.BLL.Validations
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(category => category.Name)
                .Must(NotStartWithDigitOrSymbol).WithMessage("Имя категории не должно начинаться с цифры или символа.")
                .Must(NotContainDigitsOrSymbols).WithMessage("Имя категории не должно содержать цифр или символов.");
        }

        private bool NotStartWithDigitOrSymbol(string name)
        {
            return !Regex.IsMatch(name, @"^[\d\W]");
        }

        private bool NotContainDigitsOrSymbols(string name)
        {
            return !Regex.IsMatch(name, @"[\d\W]");
        }
    }

    // Кастомное исключение для валидации
    public class UpdateCategoryValidationException : Exception
    {
        public UpdateCategoryValidationException(string message) : base(message) { }
    }
}
