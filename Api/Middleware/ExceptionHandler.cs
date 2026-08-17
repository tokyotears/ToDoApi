namespace Api.Middleware;

public class ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger) {
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandler> _logger = logger;

    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        } catch (Exception ex) {
            context.Response.StatusCode = 500;
            _logger.LogError(ex, "???");

            await context.Response.WriteAsJsonAsync(new {
                error = "internal_server_error",
                message = ex.Message
            });
        }
    }
}