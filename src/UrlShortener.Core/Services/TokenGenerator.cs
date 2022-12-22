using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Services
{
	internal class TokenGenerator : ITokenGenerator
	{
		public async Task<Token> GenerateTokenAsync(string url)
		{
			return new Token();
		}
	}
}
