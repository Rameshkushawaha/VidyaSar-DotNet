using VidyaSar.Application.DTOs;
using VidyaSar.Application.Interfaces;

namespace VidyaSar.API.Middleware;

/// <summary>
/// Populates HttpContext.Items["LoggedInUser"] from the Bearer token on every request.
/// </summary>
public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, IJwtService jwtService)
    {
        var authHeader = context.Request.Headers.Authorization.FirstOrDefault();

        if (authHeader is not null && authHeader.StartsWith("Bearer "))
        {
            var token = authHeader[7..];
            var user  = jwtService.GetLoggedInUser(token);
            if (user is not null)
                context.Items["LoggedInUser"] = user;
        }

        await _next(context);
    }
}

/// <summary>
/// Extension helpers used by controllers.
/// </summary>
public static class HttpContextExtensions
{
    public static LoggedInUserDto? GetLoggedInUser(this HttpContext context) =>
        context.Items["LoggedInUser"] as LoggedInUserDto;
}
