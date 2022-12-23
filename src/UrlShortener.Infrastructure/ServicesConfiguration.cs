using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Infrastructure.Repositories;

namespace UrlShortener.Infrastructure
{
	public static class ServicesConfiguration
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionstring)
		{
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionstring));

			services.AddScoped<IUrlRepository, UrlRepository>();

			services.AddScoped<ITokenRepository, TokenRepository>();

			return services;
		}
	}
}
