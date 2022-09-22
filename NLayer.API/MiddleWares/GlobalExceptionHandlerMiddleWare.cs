using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.MiddleWares
{
    public static class GlobalExceptionHandlerMiddleWare
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context => 
                {
                    context.Response.ContentType = "application/json";

                    var errFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = errFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;
                    var errorMessage = errFeature.Error.Message;
                    var response = CustomResponseDto<NoContentDto>.Fail(errorMessage, statusCode);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                 
                });
            });
               
           
        }

    }
}
