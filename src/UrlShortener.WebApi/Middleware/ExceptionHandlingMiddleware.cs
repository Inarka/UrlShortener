using System.Net;
using System.Text.Json;

namespace UrlShortener.WebApi.Middleware
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ExceptionHandlingMiddleware> _logger;

		public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}

			catch(Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			_logger.LogError(ex, $"Произошла ошибка {ex.Message}");

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

			await context.Response.WriteAsync(JsonSerializer.Serialize(new
			{
				StatusCode = context.Response.StatusCode,
				Message = ex.Message
			}));
		}
	}
}
