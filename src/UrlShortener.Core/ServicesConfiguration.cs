using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Interfaces.Helpers;
using UrlShortener.Core.Services;

namespace UrlShortener.Core
{
	public static class ServicesConfiguration
	{
		public static IServiceCollection AddCore(this IServiceCollection services)
		{ 
			services.AddTransient<IShortUrlService, ShortUrlService>();

			return services;
		}
	}
}
