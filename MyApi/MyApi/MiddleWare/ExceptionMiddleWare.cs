using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyApi.Errors;
using SQLitePCL;

namespace MyApi.MiddleWare
{
    public class ExceptionMiddleWare(IHostEnvironment env) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = env.IsDevelopment()
                  ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace)
                  : new ApiException(context.Response.StatusCode, ex.Message, "Server Error");


                var json = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}