namespace UrlShortener.WebApi.Middleware
{
	public static class ExceptionHandlingMiddlewareExtension
	{
		public static void ConfigureExceptionHandlingMiddleware(this WebApplication app)
		{
			app.UseMiddleware<ExceptionHandlingMiddleware>();
		}
	}
}
