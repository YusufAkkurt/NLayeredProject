using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPI.Dtos;

namespace WebAPI.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetById(id);
            if (product != null) await next();
            else
            {
                var errorDto = new ErrorDto { Status = 404 };
                errorDto.Errors.Add($"{id} numaralı id'ye sahip ürün bulunamadı.");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
