using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Back.PagLigeiro.Util.Validation.Attribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var erros = context.ModelState.Where(x => x.Value.Errors.Any())
                                .SelectMany(x => x.Value.Errors.Select(e => $"{x.Key}: {e.ErrorMessage}"))
                                .ToList();

                string message = $"Objeto inválido ({string.Join(",", erros)})";

                throw new Exception(message);
            }
        }
    }
}