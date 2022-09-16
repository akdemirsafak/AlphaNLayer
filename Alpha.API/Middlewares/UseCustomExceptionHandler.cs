using Alpha.Core.BaseDtos;
using Alpha.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Alpha.API.Middlewares;

public static class UseCustomExceptionHandler
{
    public static void UseCustomException(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(cfg =>
        {
            cfg.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                var statusCode = exceptionFeature.Error switch
                {
                    ClientSideException => 400,
                    NotFoundException => 404,
                    _ => 500
                };
                context.Response.StatusCode = statusCode;
                var response = ApiResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                await context.Response.WriteAsJsonAsync(response);
            });
        });
    }
}