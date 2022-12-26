using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Interfaces.Helpers;
using UrlShortener.Core.Models.Entities;
using UrlShortener.Core.Models.Exceptions;
using UrlShortener.Core.Models.Settings;
using UrlShortener.Core.Services;
using Xunit;

namespace UrlShortener.Core.UnitTests.Services
{
	public class ShortUrlServiceTests
	{
		private readonly Mock<ITokenGenerator> _tockenGenerator;

		private readonly Mock<IQrCodeGenerator> _qrCodeGenerator;

		public ShortUrlServiceTests()
		{
			_tockenGenerator = new Mock<ITokenGenerator>();
			_qrCodeGenerator = new Mock<IQrCodeGenerator>();
		}

		[Fact]
		public async Task GetShortUrlAsync_IfUrlIsNotValid_ShouldThrowException()
		{
			// Arrange
			var originalUrl = "google.com";
			var token = "token";
			var shortUrl = "bit.ly/token";
			var qrCode = "qrCode";

			var validUrl = "http://google.com";

			var existingUrlEntity = new UrlEntity(originalUrl, token, shortUrl, qrCode);

			var options = new Mock<IOptions<UrlSettings>>();

			var uriHelper = new Mock<IUriHelper>();
			uriHelper.Setup(x => x.TryCreateValidUrl(originalUrl, out validUrl)).Returns(false);

			var repository = new Mock<IUrlRepository>();

			var shortUrlService = new ShortUrlService(options.Object, repository.Object, _tockenGenerator.Object,
				_qrCodeGenerator.Object,
				uriHelper.Object);

			// Assert
			await Assert.ThrowsAsync<NotValidUrlException>(() => shortUrlService.GetShortUrlAsync(originalUrl));
		}

		[Fact]
		public async Task GetShortUrlAsync_IfValidUrlAlreadyInDb_ShouldReturnIt()
		{
			// Arrange
			var originalUrl = "google.com";
			var token = "token";
			var shortUrl = "bit.ly/token";
			var qrCode = "qrCode";

			var validUrl = "http://google.com";

			var options = Options.Create(new UrlSettings { BaseShortUrl = It.IsAny<string>() });

			var uriHelper = new Mock<IUriHelper>();
			uriHelper.Setup(x => x.TryCreateValidUrl(originalUrl, out validUrl)).Returns(true);

			var existingUrlEntity = new UrlEntity(originalUrl, token, shortUrl, qrCode);

			var repository = new Mock<IUrlRepository>();
			repository.Setup(x => x.FindByOriginalUrlAsync(validUrl)).ReturnsAsync(() => existingUrlEntity);

			var shortUrlService = new ShortUrlService(options, repository.Object, _tockenGenerator.Object,
				_qrCodeGenerator.Object,
				uriHelper.Object);

			// Act
			var shortUrlEntity = await shortUrlService.GetShortUrlAsync(originalUrl);

			// Assert
			Assert.Equal(existingUrlEntity, shortUrlEntity);
		}


		[Fact]
		public async Task GetShortUrlAsync_IfValidUrlNotInDb_CreatesIt()
		{
			// Arrange
			var originalUrl = "google.com";

			var validUrl = "http://google.com";

			var options = Options.Create(new UrlSettings { BaseShortUrl = It.IsAny<string>() });

			var uriHelper = new Mock<IUriHelper>();
			uriHelper.Setup(x => x.TryCreateValidUrl(originalUrl, out validUrl)).Returns(true);

			var repository = new Mock<IUrlRepository>();
			repository.Setup(x => x.FindByOriginalUrlAsync(validUrl)).ReturnsAsync(() => null);

			var shortUrlService = new ShortUrlService(options, repository.Object, _tockenGenerator.Object,
				_qrCodeGenerator.Object,
				uriHelper.Object);

			// Act
			var shortUrlEntity = await shortUrlService.GetShortUrlAsync(originalUrl);

			// Assert
			repository.Verify(x => x.SaveAsync(It.IsAny<UrlEntity>()), Times.Once);
		}
	}
}
