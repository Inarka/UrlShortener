using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Interfaces.Helpers;
using UrlShortener.Core.Services;
using UrlShortener.Core.Services.Helpers;
using UrlShortener.Core.Services.Helpers.Validators;

namespace UrlShortener.Core
{
	public static class ServicesConfiguration
	{
		public static IServiceCollection AddCore(this IServiceCollection services)
		{
			services.AddTransient<IUriHelper, UriHelper>();

			services.AddTransient<ITokenGenerator, TokenGenerator>();

			services.AddTransient<IQrCodeGenerator, QrCodeGenerator>();

			services.AddTransient<IShortUrlService, ShortUrlService>();

			return services;
		}
	}
}
