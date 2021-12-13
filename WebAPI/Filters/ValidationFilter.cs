using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI.Dtos;

namespace WebAPI.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorDto = new ErrorDto { Status = 400 };

                var modelErrors = context.ModelState.Values.SelectMany(x => x.Errors).ToList();
                modelErrors.ForEach(x => { errorDto.Errors?.Add(x.ErrorMessage); });

                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}
