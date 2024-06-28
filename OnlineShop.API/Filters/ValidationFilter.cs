using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var validators = GetValidators(context);

            if (validators.Any())
            {
                foreach (var validator in validators)
                {
                    foreach (var argument in context.ActionArguments.Values)
                    {
                        var validationContext = new ValidationContext<object>(argument);
                        var result = await validator.ValidateAsync(validationContext);

                        if (!result.IsValid)
                        {
                            context.Result = new BadRequestObjectResult(result.Errors.Select(e => e.ErrorMessage));
                            return;
                        }
                    }
                }
            }

            await next();
        }

        private IEnumerable<IValidator> GetValidators(ActionExecutingContext context)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument != null)
                {
                    var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
                    var validator = _serviceProvider.GetService(validatorType) as IValidator;

                    if (validator != null)
                    {
                        yield return validator;
                    }
                }
            }
        }
    }
}
