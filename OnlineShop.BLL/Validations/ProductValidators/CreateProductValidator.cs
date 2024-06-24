using FluentValidation;
using OnlineShop.BLL.DTO.RequestDTO.ProductRequestDTO;
using OnlineShop.BLL.Interfaces;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Validations
{
    public class CreateProductValidator : AbstractValidator<CreateProductDTO>
    {
        private readonly IProductService _productService;

        public CreateProductValidator(IProductService productService)
        {
            _productService = productService;

            RuleFor(product => product.Name)
                .MustAsync(BeUniqueName).WithMessage("Имя продукта должно быть уникальным.")
                .Must(NotStartWithDigitOrSymbol).WithMessage("Имя продукта не должно начинаться с цифры или символа.")
                .Must(NotContainDigitsOrSymbols).WithMessage("Имя продукта не должно содержать цифр или символов.");

            RuleFor(product => product.Description)
                .Must(IsValidDescription).WithMessage("Описание продукта должно содержать хотя бы 10 символов и не превышать 1000 символов.");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProductsAsync();
            return !products.Any(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }

        private bool NotStartWithDigitOrSymbol(string name)
        {
            return !Regex.IsMatch(name, @"^[\d\W]");
        }

        private bool NotContainDigitsOrSymbols(string name)
        {
            return !Regex.IsMatch(name, @"[\d\W]");
        }

        private bool IsValidDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return false;

            if (description.Length < 10 || description.Length > 1000)
                return false;

            // Можно добавить другие проверки для описания по необходимости

            return true;
        }
    }

    // Кастомное исключение для валидации
    public class CreateProductValidationException : Exception
    {
        public CreateProductValidationException(string message) : base(message) { }

        // Добавим конструктор по умолчанию, если это нужно
        public CreateProductValidationException() : base() { }
    }
}
