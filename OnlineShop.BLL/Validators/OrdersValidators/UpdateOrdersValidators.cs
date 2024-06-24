using FluentValidation;
using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using System.Text.RegularExpressions;

namespace OnlineShop.BLL.Validations
{
    public class UpdateOrdersValidator : AbstractValidator<UpdateOrdersDTO>
    {
        public UpdateOrdersValidator()
        {
            RuleFor(Orders => Orders.Name)
                .Must(NotStartWithDigitOrSymbol).WithMessage("Имя заказа не должно начинаться с цифры или символа.")
                .Must(NotContainDigitsOrSymbols).WithMessage("Имя заказа не должно содержать цифр или символов.");

         
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

 
    public class UpdateOrdersValidationException : Exception
    {
        public UpdateOrdersValidationException(string message) : base(message) { }

        public UpdateOrdersValidationException() : base() { }
    }
}
