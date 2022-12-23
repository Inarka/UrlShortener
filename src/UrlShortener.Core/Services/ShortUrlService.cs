using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Interfaces.Helpers;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Services
{
	internal class ShortUrlService : IShortUrlService
	{
		private readonly IUrlRepository _urlRepository;
		private readonly ITokenGenerator _tokenGenerator;
		private readonly IQrCodeGenerator _qrCodeGenerator;

		public ShortUrlService(IUrlRepository linkRepository, ITokenGenerator tokenGenerator, IQrCodeGenerator qrCodeGenerator)
		{
			_urlRepository = linkRepository;
			_tokenGenerator = tokenGenerator;
			_qrCodeGenerator = qrCodeGenerator;
		}

		public Task<UrlEntity?> GetUrlAsync(string link)
		{
			return _urlRepository.GetAsync(link);
		}

		public async Task<UrlEntity> GenerateShortUrlAsync(string link)
		{
			var shortUrl = await GetUrlAsync(link);

			if (shortUrl != null)
			{
				return shortUrl;
			}

			shortUrl = await CreateShortUrl(link);

			await _urlRepository.SaveAsync(shortUrl);

			return shortUrl;
		}

		private async Task<UrlEntity> CreateShortUrl(string link)
		{
			var token = await _tokenGenerator.GenerateTokenAsync();

			var qrCode = await _qrCodeGenerator.Generate(token);

			return new UrlEntity(link, token, qrCode);
		}
	}
}
