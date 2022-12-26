using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Models.Entities;
using UrlShortener.WebApi.Controllers;
using Xunit;

namespace UrlShortener.WebApi.UnitTests.Controllers
{
	public class UrlShortenerControllerTests
	{
		private UrlShortenerController _controller;
		private readonly IMapper _mapper;
		private readonly ILogger<UrlShortenerController> _logger;

		public UrlShortenerControllerTests()
		{
			_mapper = new Mock<IMapper>().Object;

			_logger = new Mock<ILogger<UrlShortenerController>>().Object;
		}

		[Fact]
		public async Task GetOriginalUrl_IfTokenNotFound_ShouldReturn404()
		{
			//Arrange
			var token = It.IsAny<string>();

			var shortUrlService = new Mock<IShortUrlService>();
			shortUrlService.Setup(x => x.GetOriginalUrlAsync(token)).ReturnsAsync(() => null);

			_controller = new UrlShortenerController(shortUrlService.Object, _mapper, _logger);

			//Act
			var response = await _controller.GetOriginalUrl(token);
			var responseStatusCode = response as NotFoundObjectResult;

			//Assert
			Assert.NotNull(responseStatusCode);
			Assert.Equal(404, responseStatusCode?.StatusCode);
		}

		[Fact]
		public async Task GetOriginalUrl_IfTokenIsFound_RedirectsToOriginalUrl()
		{
			//Arrange
			var token = It.IsAny<string>();
			var originalUrl = "https://google.com";

			var shortUrlService = new Mock<IShortUrlService>();
			shortUrlService.Setup(x => x.GetOriginalUrlAsync(token)).ReturnsAsync(() => new UrlEntity(originalUrl, token, "", ""));

			_controller = new UrlShortenerController(shortUrlService.Object, _mapper, _logger);

			//Act
			var response = await _controller.GetOriginalUrl(token);
			var responseStatusCode = response as RedirectResult;

			//Assert
			Assert.NotNull(responseStatusCode);
		}
	}
}
