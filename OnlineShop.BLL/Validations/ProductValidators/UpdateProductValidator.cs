using System.Text.RegularExpressions;
using OnlineShop.BLL.DTO;
using OnlineShop.BLL.DTO.ProductDTO;
using OnlineShop.BLL.Interfaces;

namespace OnlineShop.BLL.Validations
{
    public class UpdateProductValidator
    {
        public void ValidateUpdateProduct(UpdateProductDTO productDTO)
        {
            if (StartsWithDigitOrSymbol(productDTO.Name))
            {
                throw new UpdateProductValidationException("Имя продукта не должно начинаться с цифры или символа.");
            }

            if (ContainsDigitsOrSymbols(productDTO.Name))
            {
                throw new UpdateProductValidationException("Имя продукта не должно содержать цифр или символов.");
            }

            if (!IsValidDescription(productDTO.Description))
            {
                throw new UpdateProductValidationException("Описание продукта должно содержать хотя бы 10 символов и не превышать 1000 символов.");
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
    public class UpdateProductValidationException : Exception
    {
        public UpdateProductValidationException(string message) : base(message) { }

        // Добавим конструктор по умолчанию, если это нужно
        public UpdateProductValidationException() : base() { }
    }
}
