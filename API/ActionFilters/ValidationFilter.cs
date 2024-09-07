using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Net;

public class ValidationFilter<T> : IActionFilter where T : class
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

        if (validator != null && context.ActionArguments.Values.FirstOrDefault(arg => arg is T) is T argument)
        {
            var validationResult = validator.Validate(argument);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                Log.Warning("Validation failed: {Errors}", string.Join(", ", errors));

                throw new ValidationException(string.Join(", ", errors));
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
