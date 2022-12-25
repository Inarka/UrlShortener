namespace UrlShortener.WebApi.Middleware
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public static class ExceptionHandlingMiddlewareExtension
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public static void ConfigureExceptionHandlingMiddleware(this WebApplication app)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		{
			app.UseMiddleware<ExceptionHandlingMiddleware>();
		}
	}
}
