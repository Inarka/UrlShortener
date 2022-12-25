using System.Net;
using System.Text.Json;

namespace UrlShortener.WebApi.Middleware
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class ExceptionHandlingMiddleware
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
		private readonly RequestDelegate _next;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public ExceptionHandlingMiddleware(RequestDelegate next)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		{
			_next = next;
		}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public async Task InvokeAsync(HttpContext context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
