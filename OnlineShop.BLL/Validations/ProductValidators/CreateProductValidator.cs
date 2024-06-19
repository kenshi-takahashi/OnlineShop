using System.Text.RegularExpressions;
using OnlineShop.BLL.DTO;
using OnlineShop.BLL.DTO.ProductDTO;
using OnlineShop.BLL.Interfaces;

namespace OnlineShop.BLL.Validations
{
    public class CreateProductValidator
    {
        private readonly IProductService _productService;

        public CreateProductValidator(IProductService productService)
        {
            _productService = productService;
        }

        public void ValidateCreateProduct(CreateProductDTO productDTO)
        {
            if (!IsNameUnique(productDTO.Name))
            {
                throw new CreateProductValidationException("Имя продукта должно быть уникальным.");
            }

            if (StartsWithDigitOrSymbol(productDTO.Name))
            {
                throw new CreateProductValidationException("Имя продукта не должно начинаться с цифры или символа.");
            }

            if (ContainsDigitsOrSymbols(productDTO.Name))
            {
                throw new CreateProductValidationException("Имя продукта не должно содержать цифр или символов.");
            }

            if (!IsValidDescription(productDTO.Description))
            {
                throw new CreateProductValidationException("Описание продукта должно содержать хотя бы 10 символов и не превышать 1000 символов.");
            }
        }

        private bool IsNameUnique(string name)
        {
            var products = _productService.GetAllProducts();
            return !products.Any(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }

        private bool StartsWithDigitOrSymbol(string name)
        {
            return Regex.IsMatch(name, @"^[\d\W]");
        }

        private bool ContainsDigitsOrSymbols(string name)
        {
            return Regex.IsMatch(name, @"[\d\W]");
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
