using FluentValidation;
using OnlineShop.BLL.DTO.RequestDTO.CategoryRequestDTO;
using OnlineShop.BLL.Interfaces;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Validations
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            RuleFor(category => category.Name)
                .MustAsync(BeUniqueName).WithMessage("Имя категории должно быть уникальным.")
                .Must(NotStartWithDigitOrSymbol).WithMessage("Имя категории не должно начинаться с цифры или символа.")
                .Must(NotContainDigitsOrSymbols).WithMessage("Имя категории не должно содержать цифр или символов.");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return !categories.Any(c => c.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
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

    public class CreateCategoryValidationException : Exception
    {
        public CreateCategoryValidationException(string message) : base(message) { }

        public CreateCategoryValidationException() : base() { }
    }
}

