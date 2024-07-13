
using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddlware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddlware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddlware(
            RequestDelegate next, 
            ILogger<ExceptionMiddlware> logger, 
            IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try 
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                int internalServerErrorCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = internalServerErrorCode;

                var response = _env.IsDevelopment()
                    ? new ApiException(internalServerErrorCode, ex.Message, ex.StackTrace.ToString())
                    : new ApiException(internalServerErrorCode);

                var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}