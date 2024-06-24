using FluentValidation;
using OnlineShop.BLL.DTO.RequestDTO.UsersRequestDTO;
using OnlineShop.BLL.Interfaces;
using System.Text.RegularExpressions;

namespace OnlineShop.BLL.Validations
{
    public class UpdateUsersValidator : AbstractValidator<UpdateUsersDTO>
    {
        private readonly IUsersService _usersService;

        public UpdateUsersValidator(IUsersService usersService)
        {
            _usersService = usersService;

            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Имя пользователя не должно быть пустым.")
                .MustAsync(BeUniqueUsername).WithMessage("Имя пользователя должно быть уникальным.")
                .Must(NotStartWithDigitOrSymbol).WithMessage("Имя пользователя не должно начинаться с цифры или символа.")
                .Must(NotContainDigitsOrSymbols).WithMessage("Имя пользователя не должно содержать цифр или символов.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email не должен быть пустым.")
                .EmailAddress().WithMessage("Некорректный формат Email.")
                .MustAsync(BeUniqueEmail).WithMessage("Email должен быть уникальным.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Пароль не должен быть пустым.")
                .MinimumLength(6).WithMessage("Пароль должен содержать минимум 6 символов.")
                .Matches(@"[A-Z]").WithMessage("Пароль должен содержать хотя бы одну заглавную букву.")
                .Matches(@"[a-z]").WithMessage("Пароль должен содержать хотя бы одну строчную букву.")
                .Matches(@"[0-9]").WithMessage("Пароль должен содержать хотя бы одну цифру.")
                .Matches(@"[\W]").WithMessage("Пароль должен содержать хотя бы один специальный символ.");
        }

        private async Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            var users = await _usersService.GetAllUsersAsync();
            return !users.Any(u => u.Username.Equals(username, System.StringComparison.OrdinalIgnoreCase));
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var users = await _usersService.GetAllUsersAsync();
            return !users.Any(u => u.Email.Equals(email, System.StringComparison.OrdinalIgnoreCase));
        }

        private bool NotStartWithDigitOrSymbol(string username)
        {
            return !Regex.IsMatch(username, @"^[\d\W]");
        }

        private bool NotContainDigitsOrSymbols(string username)
        {
            return !Regex.IsMatch(username, @"[\d\W]");
        }
    }

    public class UpdateUsersValidationException : Exception
    {
        public UpdateUsersValidationException(string message) : base(message) { }

        public UpdateUsersValidationException() : base() { }
    }
}
