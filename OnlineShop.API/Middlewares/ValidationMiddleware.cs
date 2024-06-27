using FluentValidation;
using FluentValidation.Results;

namespace OnlineShop.Middlewares
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint != null)
            {
                var routeValues = context.Request.RouteValues.Values.ToList();
                foreach (var value in routeValues)
                {
                    var validatorType = typeof(IValidator<>).MakeGenericType(value.GetType());
                    var validator = serviceProvider.GetService(validatorType);

                    if (validator != null)
                    {
                        var method = validatorType.GetMethod("Validate", new[] { value.GetType() });
                        var result = (ValidationResult)method.Invoke(validator, new[] { value });

                        if (!result.IsValid)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsync(string.Join(", ", result.Errors.Select(e => e.ErrorMessage)));
                            return;
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}
