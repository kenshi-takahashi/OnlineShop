using FluentValidation;
using OnlineShop.BLL.DTO.RequestDTO.ProductRequestDTO;
using System.Text.RegularExpressions;

namespace OnlineShop.BLL.Validations
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductValidator()
        {
            RuleFor(product => product.Name)
                .Must(NotStartWithDigitOrSymbol).WithMessage("Имя продукта не должно начинаться с цифры или символа.")
                .Must(NotContainDigitsOrSymbols).WithMessage("Имя продукта не должно содержать цифр или символов.");

            RuleFor(product => product.Description)
                .Must(IsValidDescription).WithMessage("Описание продукта должно содержать хотя бы 10 символов и не превышать 1000 символов.");
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

            return true;
        }
    }

    public class UpdateProductValidationException : Exception
    {
        public UpdateProductValidationException(string message) : base(message) { }

        public UpdateProductValidationException() : base() { }
    }
}
