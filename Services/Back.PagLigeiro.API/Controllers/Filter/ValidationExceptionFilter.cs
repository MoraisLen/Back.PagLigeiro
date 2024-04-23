using Back.PagLigeiro.Api.Controllers.Error.Model;
using Back.PagLigeiro.Util.Validation.Error;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Back.PagLigeiro.Api.Controllers.Filter
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string iderro = Activity.Current?.Id ?? context.HttpContext.TraceIdentifier;

            //if (context.Exception is ErrorValidation validationException)
            //{
            //    context.Result = new BadRequestObjectResult(new ErrorResponse(validationException, iderro));
            //    context.ExceptionHandled = true;
            //}
            //else
            //{
            //    context.Result = new BadRequestObjectResult(new ErrorResponse(null, null, 500, iderro));
            //    context.ExceptionHandled = true;
            //}
        }
    }
}