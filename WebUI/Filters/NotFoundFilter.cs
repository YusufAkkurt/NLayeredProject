using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebUI.ApiServices;
using WebUI.Dtos;

namespace WebUI.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly CategoryApiService _categoryApiService;

        public NotFoundFilter(CategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var category = await _categoryApiService.GetByIdAsync(id);
            if (category != null) await next();
            else
            {
                var errorDto = new ErrorDto { Errors = { $"{id} numaralı id'ye sahip kategori bulunamadı." } };

                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }
        }
    }
}
