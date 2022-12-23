using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces.Helpers;
using UrlShortener.Core.Services.Helpers;

namespace UrlShortener.Core
{
	public static class ServicesConfiguration
	{
		public static IServiceCollection AddCore(this IServiceCollection services)
		{
			services.AddTransient<IEncoder, Base62Encoder>();

			services.AddTransient<ITokenGenerator, TokenGenerator>();

			services.AddTransient<IQrCodeGenerator, QrCodeGenerator>();

			return services;
		}
	}
}
