using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Models;

namespace UrlShortener.Infrastructure.Repositories
{
	internal class TokenRepository : ITokenRepository
	{
		public async Task<Token?> GetTokenAsync(string url)
		{
			return new Token();
		}
		public async Task SaveTokenAsync(Token token)
		{
			return Task.CompletedTask;
		}
	}
}
