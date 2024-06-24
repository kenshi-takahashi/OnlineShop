using FluentValidation;
using OnlineShop.BLL.DTO.RequestDTO.OrdersRequestDTO;
using OnlineShop.BLL.Interfaces;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Validations
{
    public class CreateOrdersValidator : AbstractValidator<CreateOrdersDTO>
    {
        private readonly IOrdersService _OrdersService;

        public CreateOrdersValidator(IOrdersService OrdersService)
        { 
            _OrdersService = OrdersService;

            RuleFor(Orders => Orders.Name)
                .MustAsync(BeUniqueName).WithMessage("Имя заказа должно быть уникальным.")
                .Must(NotStartWithDigitOrSymbol).WithMessage("Имя заказа не должно начинаться с цифры или символа.")
                .Must(NotContainDigitsOrSymbols).WithMessage("Имя заказа не должно содержать цифр или символов.");

           
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            var Orderss = await _OrdersService.GetAllOrdersAsync();
            return !Orderss.Any(p => p.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
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
    public class CreateOrdersValidationException : Exception
    {
        public CreateOrdersValidationException(string message) : base(message) { }

        public CreateOrdersValidationException() : base() { }
    }
}
