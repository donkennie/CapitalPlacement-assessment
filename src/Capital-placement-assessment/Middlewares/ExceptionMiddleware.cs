using Capital_placement_assessment.DTOs;
using System;
using System.Net;
using System.Text.Json;

namespace Capital_placement_assessment.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException avEx)
            {
                _logger.LogError($"A new violation exception has been thrown: {avEx}");
                await HandleExceptionAsync(httpContext, avEx);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex} \n Inner Exception => {ex.InnerException} \n Stack Trace => {ex.StackTrace}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = exception switch
            {
                AccessViolationException => "Access violation error from the custom middleware",
                Microsoft.Azure.Cosmos.CosmosException => "Resource not found",
                _ => "Internal Server Error from the Custom middleware."
            };

            /* if (exception is FluentValidation.ValidationException)
             {
                 context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
             }*/

            if (exception is Microsoft.Azure.Cosmos.CosmosException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            await context.Response.WriteAsync(new AppException()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"{message} \n {exception.Message}"
            }.ToString());
        }
    }
}