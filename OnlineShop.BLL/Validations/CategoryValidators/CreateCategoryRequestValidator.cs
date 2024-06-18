using FluentValidation;
using OnlineShop.

namespace OnlineShop.BLL.Validators
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название продукта обязательно.")
                .MaximumLength(100).WithMessage("Название продукта не должно превышать 100 символов.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Описание продукта не должно превышать 500 символов.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Цена продукта должна быть больше нуля.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Идентификатор категории должен быть больше нуля.");
        }
    }
}
