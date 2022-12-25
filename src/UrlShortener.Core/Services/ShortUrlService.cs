using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Interfaces.Helpers;
using UrlShortener.Core.Models.Entities;
using UrlShortener.Core.Models.Exceptions;

namespace UrlShortener.Core.Services
{
	internal class ShortUrlService : IShortUrlService
	{
		private readonly IUriHelper _uriHelper;
		private readonly IUrlRepository _urlRepository;
		private readonly ITokenGenerator _tokenGenerator;
		private readonly IQrCodeGenerator _qrCodeGenerator;

		public ShortUrlService(IUrlRepository linkRepository,
			ITokenGenerator tokenGenerator,
			IQrCodeGenerator qrCodeGenerator,
			IUriHelper validator)
		{
			_urlRepository = linkRepository;
			_tokenGenerator = tokenGenerator;
			_qrCodeGenerator = qrCodeGenerator;
			_uriHelper = validator;
		}

		public Task<UrlEntity?> GetOriginalUrlAsync(string token)
		{
			return _urlRepository.FindByTokenAsync(token);
		}

		public async Task<UrlEntity> GetShortUrlAsync(string originalUrl)
		{
			if (!_uriHelper.TryCreateValidUrl(originalUrl, out var validUrl))
			{
				throw new NotValidUrlException();
			}

			var shortUrl = await _urlRepository.FindByOriginalUrlAsync(validUrl);

			if (shortUrl == null)
			{
				shortUrl = await CreateShortUrl(validUrl);

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
