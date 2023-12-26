using BMEcatSharp.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BMEcatSharp.Samples.AspNetCore
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            if (ex is ValidationException v)
            {
                var validationResult = new ValidationResult()
                {
                    Errors = v.Errors
                };

                var jsonResult = new JsonResult(validationResult)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };

                context.Result = jsonResult;
                context.ExceptionHandled = true;
            }
        }
    }
}
