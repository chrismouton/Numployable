namespace Numployable.API.Middleware;

using System.Net;

using Newtonsoft.Json;

using Application.Exceptions;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        string result = JsonConvert.SerializeObject(new ErrorDetails
        {
            ErrorMessage = exception.Message,
            ErrorType = "Failure"
        });

        switch (exception)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                break;
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.Errors);
                break;
            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                break;
            default:
                break;
        }

        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }
}

public class ErrorDetails
{
    public required string ErrorType { get; set; }
    public required string ErrorMessage { get; set; }
}