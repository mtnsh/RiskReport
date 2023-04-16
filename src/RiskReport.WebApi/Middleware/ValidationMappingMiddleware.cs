using FluentValidation;
using RiskReport.Contracts.Responses;

namespace RiskReport.WebApi.Middleware;

public class ValidationMappingMiddleware
{
    private readonly RequestDelegate _next;

    public ValidationMappingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext ctx)
    {
        try
        {
            await _next(ctx);
        }
        catch (ValidationException e)
        {
           ctx.Response.StatusCode = StatusCodes.Status400BadRequest;
           var validationFailureResponse = new ValidationFailureResponse
           {
               Errors = e.Errors.Select(x => new ValidationResponse()
               {
                   PropertyName = x.PropertyName,
                   ErrorMessage = x.ErrorMessage
               }).ToList()
           };

           await ctx.Response.WriteAsJsonAsync(validationFailureResponse);
        }
    }
}