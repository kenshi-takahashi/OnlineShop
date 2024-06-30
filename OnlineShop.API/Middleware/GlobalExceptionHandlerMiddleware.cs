using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            LogException(ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private void LogException(Exception exception)
    {
        _logger.LogError(exception, "An unhandled exception has occurred.");
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var message = "An unexpected error occurred. Please try again later.";

        switch (exception)
        {
            case ArgumentNullException:
                statusCode = HttpStatusCode.BadRequest;
                message = "A required parameter is missing. Please check your input and try again.";
                break;
            case ArgumentException:
                statusCode = HttpStatusCode.BadRequest;
                message = "An argument provided to the method is not valid. Please review the input and try again.";
                break;
            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                message = "The requested resource could not be found. Please check the request and try again.";
                break;
            case InvalidOperationException:
                statusCode = HttpStatusCode.Conflict;
                message = "The requested operation is not valid in the current state. Please try again later.";
                break;
            case TimeoutException:
                statusCode = HttpStatusCode.RequestTimeout;
                message = "The request timed out. Please try again later.";
                break;
            case NotImplementedException:
                statusCode = HttpStatusCode.NotImplemented;
                message = "This feature is not implemented yet. Please try again later.";
                break;
            case FormatException:
                statusCode = HttpStatusCode.BadRequest;
                message = "The format of the input is invalid. Please correct the input and try again.";
                break;
            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Forbidden;
                message = "You do not have permission to access this resource. Please authorize.";
                break;
            case IndexOutOfRangeException:
                statusCode = HttpStatusCode.BadRequest;
                message = "The index is out of range. Please check the input and try again.";
                break;
            case NullReferenceException:
                statusCode = HttpStatusCode.InternalServerError;
                message = "A null reference occurred. Please try again later.";
                break;
            case Microsoft.EntityFrameworkCore.DbUpdateException:
                statusCode = HttpStatusCode.InternalServerError;
                message = "An error occurred while updating the database. Please try again later.";
                break;
            case BadHttpRequestException:
                statusCode = HttpStatusCode.BadRequest;
                message = "The request is invalid. Please check the input and try again.";
                break;
            case SqlException:
                statusCode = HttpStatusCode.InternalServerError;
                message = "A database error occurred. Please try again later.";
                break;
            default:
                statusCode = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred. Please try again later.";
                break;
        }

        var result = JsonSerializer.Serialize(new { error = message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(result);
    }
}
