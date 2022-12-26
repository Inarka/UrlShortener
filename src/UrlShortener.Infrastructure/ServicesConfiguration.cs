using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Services.Helpers.Validators;
using UrlShortener.Core.Services.Helpers;
using UrlShortener.Infrastructure.Repositories;
using UrlShortener.Core.Interfaces.Helpers;

namespace UrlShortener.Infrastructure
{
	public static class ServicesConfiguration
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionstring)
		{
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionstring));

			services.AddScoped<IUrlRepository, UrlRepository>();

			services.AddScoped<ITokenRepository, TokenRepository>();

			services.AddTransient<IUriHelper, UriHelper>();

			services.AddTransient<ITokenGenerator, TokenGenerator>();

			services.AddTransient<IQrCodeGenerator, QrCodeGenerator>();

			return services;
		}
	}
}
