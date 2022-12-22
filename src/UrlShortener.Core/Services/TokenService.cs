using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Services
{
	internal class TokenService : ITokenService
	{
		private readonly ITokenRepository _tokenRepository;
		private readonly ITokenGenerator _tokenGenerator;

		public TokenService(ITokenRepository tokenRepository, ITokenGenerator tokenGenerator)
		{
			_tokenRepository = tokenRepository;
			_tokenGenerator = tokenGenerator;
		}

		public async Task<Token> GetTokenAsync(string url)
		{
			var token = await _tokenRepository.GetTokenAsync(url);

			if (token != null)
			{
				return token;
			}

			token = await _tokenGenerator.GenerateTokenAsync(url);

			await _tokenRepository.SaveTokenAsync(token);

			return token;
		}
	}
}
