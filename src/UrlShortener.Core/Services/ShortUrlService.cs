using Microsoft.Extensions.Options;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Interfaces.Helpers;
using UrlShortener.Core.Models;
using UrlShortener.Core.Models.Entities;
using UrlShortener.Core.Services.Helpers.Extensions;

namespace UrlShortener.Core.Services
{
	internal class ShortUrlService : IShortUrlService
	{
		private readonly IUrlRepository _urlRepository;
		private readonly ITokenGenerator _tokenGenerator;
		private readonly IQrCodeGenerator _qrCodeGenerator;

		public ShortUrlService(IUrlRepository linkRepository, 
			ITokenGenerator tokenGenerator, 
			IQrCodeGenerator qrCodeGenerator)
		{
			_urlRepository = linkRepository;
			_tokenGenerator = tokenGenerator;
			_qrCodeGenerator = qrCodeGenerator;
		}

		public Task<UrlEntity?> GetOriginalUrlAsync(string token)
		{
			return _urlRepository.FindByTokenAsync(token);
		}

		public async Task<UrlEntity> GetShortUrlAsync(string originalUrl)
		{
			originalUrl = originalUrl.AddSchema();

			var shortUrl = await _urlRepository.FindByOriginalUrlAsync(originalUrl);

			if (shortUrl == null)
			{
				shortUrl = await CreateShortUrl(originalUrl);

				await _urlRepository.SaveAsync(shortUrl);
			}

			return shortUrl;
		}

		private async Task<UrlEntity> CreateShortUrl(string originalUrl)
		{
			var token = await _tokenGenerator.GenerateAsync();

			var qrCode = _qrCodeGenerator.Generate(token);

			return new UrlEntity(originalUrl, token, qrCode);
		}
	}
}
