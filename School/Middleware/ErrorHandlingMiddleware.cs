using School.Domain;
namespace School.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _net;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate net, ILogger<ErrorHandlingMiddleware> logger)
        {
            _net = net;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        { 
            var traceId = Guid.NewGuid().ToString();

            try
            {

                context.Items["TraceId"] = traceId;
                await _net(context);

            }catch (Exception ex)
            {
                _logger.LogError(
                    ex, 
                    "Error | TraceId :{TraceId} | Path: {Path} | Method: {Method} ",
                    traceId,
                    context.Request.Path,
                    context.Request.Method
                    );

                context.Response.StatusCode = ex switch
                {
                    BusinessException => 400, 
                    _ => 500
                };

                var message = ex is  BusinessException
                    ? ex.Message
                    : "Internal Server Error";

                await context.Response.WriteAsJsonAsync(new
                {
                    error = message,
                    traceId
                });
            }
        }
}
}
