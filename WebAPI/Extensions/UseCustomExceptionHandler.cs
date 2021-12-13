using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using WebAPI.Dtos;

namespace WebAPI.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomExceptionHandlerExtension(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();

                    if (error != null)
                    {
                        var exception = error.Error;
                        var errorDto = new ErrorDto { Status = 500, Errors = { exception.Message } };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDto));
                    }
                });
            });
        }
    }
}
